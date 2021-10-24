using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using ZedGraph;
using System.Threading;
using System.Diagnostics;
using NationalInstruments.NI4882;   // This namespace must be included to reference the .NET language interface


namespace MGCPSM
{
    public partial class Form1 : Form
    {
        Device device_2636 = new Device(0, 20, 0);
        Device device_2400 = new Device(0, 19, 0);

        DateTime vreme;
        long proteklo;
        long proteklo2;

        PointPairList listPrag = new PointPairList();
        PointPairList listRC = new PointPairList();
        TextWriter pisiRC;
        TextWriter pisiRC2;
        GraphPane novo;

        int status;

        double pocetna_struja;
        double krajnja_struja;
        double broj_koraka;
        double brojac;
        double konstanta;
        string naponn = "";
        string naponn2 = "";
        string trenutni_korak;
        string trenutni_korak2;
        string trenutni_korak3;
        string trenutni_korak4;

        double osetljivost;
        double Vth_pocetni_a;
        double Vth_pocetni_b;
        double Vth_pocetni_a0;
        double Vth_pocetni_b0;

        double Vth_struja; //dodatak za Vth
        double ZTC_struja; //dodatak za ZTC
        double Vth0_a;
        double ZTC_a;
        double Vth0_b;
        double ZTC_b;
        double Delta_a;
        double Delta_b;

        double doza;
        double TID; //mGy
        double brzina_doze; // mGy/s

        Stopwatch sw = new Stopwatch();     //EPAD1
        Stopwatch sw2 = new Stopwatch();    //EPAD2
        Stopwatch sw3 = new Stopwatch();    //millis

        int Zastavica = 0;
        int ZastavicaPrva = 0;
        int ZastavicaHighsens = 0;
        double usporivac = 1;
        double usporivac_stari = 1;
        int brojac_highsens = 1;

        //int broj_merenja = 1;
        //int broj_fajla = 1;
        double vremeObrade;  // TID, zeljena doza
        double ukupanBrojMerenja; //Brzina doze

        double ZadatiNaponPrag;
        int brojAcharging = 1;
        int brojAmonitoring = 1;
        int brojBcharging = 1;
        int brojBmonitoring = 1;
        int a; // vreme programiranja
        int suma = 0; //ukupno vreme programiranja
        double[] niz = { 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25, 2.5, 2.75, 3.0, 3.2, 3.3, 3.4, 3.5 }; //niz sa DeltaVth tackama
        double Vth0;
        double Vth;
        double t1;
        double t2;
        double Dt;
        TextWriter pisiVth;

        private delegate void delegat();
        private delegate void delProg();
        private delegate void delPrag();
        private delegate void delIspisMerenja();
        private delegate void delIspisZadatNapon();
        private delegate void delCistiGrafik();
        private delegate void delBrojKoraka();
        private delegate void delBrojKoraka2();
        private delegate void delBrojKoraka3();
        private delegate void delBrojKoraka4();
        int iteratorZaMerenja = 1;
        //int progresBarVrednost = 0;
        const int hronoloskoMerenjeUkupanBrojIteracija = 8;
        Boolean terminacija = false;
        int choose = 0;

        public Form1()
        {
            InitializeComponent();


            novo = zedRC.GraphPane;
            novo.YAxis.Type = AxisType.Linear;
            zedRC.GraphPane.Title.Text = "Samo eksperiment (PMOS)";
            zedRC.GraphPane.XAxis.Title.Text = "Napon (V)";
            zedRC.GraphPane.YAxis.Title.Text = "Struja (A)";
            zedRC.GraphPane.XAxis.MajorGrid.IsVisible = true; //Set the grid
            zedRC.GraphPane.YAxis.MajorGrid.IsVisible = true; //Set the grid
            zedRC.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedRC.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedRC.AxisChange();
            zedRC.Refresh();

            zedPrag.GraphPane.Title.Text = "EPAD2: highsens";
            zedPrag.GraphPane.XAxis.Title.Text = "Vreme (s)";
            zedPrag.GraphPane.YAxis.Title.Text = "Promena napona praga (V)";
            zedPrag.Refresh();
        }


        private void save_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }


        private void LogoritamskaRC_CheckedChanged_1(object sender, EventArgs e)
        {
            GraphPane novo = zedRC.GraphPane;
            novo.YAxis.Type = AxisType.Log;
            zedRC.GraphPane.Title.Text = "Prenosna karakteristika";
            zedRC.GraphPane.XAxis.Title.Text = "Vg (V)";
            zedRC.GraphPane.YAxis.Title.Text = "|Id| (A)";
            zedRC.AxisChange();
            zedRC.Refresh();
        }

        private void LinearnaRC_CheckedChanged_1(object sender, EventArgs e)
        {
            GraphPane novo = zedRC.GraphPane;
            novo.YAxis.Type = AxisType.Linear;
            zedRC.GraphPane.Title.Text = "Prenosna karakteristika";
            zedRC.GraphPane.XAxis.Title.Text = "Vg (V)";
            zedRC.GraphPane.YAxis.Title.Text = "|Id| (A)";
            zedRC.AxisChange();
            zedRC.Refresh();
        }


        private void gumica_Click(object sender, EventArgs e)
        {

            zedRC.Refresh();
            listRC.Clear();
            listPrag.Clear();
        }

        private void stop_Click(object sender, EventArgs e)
        {
            terminacija = true;
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                //progressBar1.Value = 0;


                //gasi_2636a();
                //gasi_2636b();
                gasi_2400();


                displej.Clear();
                displej.Refresh();

                this.Close();

            }

        }


        private void gasi_2636a()
        {
            //device_2636.Write("smua.reset()");
            //device_2636.Write("smua.source.output = smua.OUTPUT_OFF");
            //CEC488.send(20, "smua.reset()", out status);
            //CEC488.send(20, "smua.source.output = smua.OUTPUT_OFF", out status);
        }

        private void gasi_2636b()
        {
            //device_2636.Write("smub.reset()");
            //device_2636.Write("smub.source.output = smua.OUTPUT_OFF");
            //CEC488.send(20, "smub.reset()", out status);
            //CEC488.send(20, "smub.source.output = smub.OUTPUT_OFF", out status);
        }

        private void gasi_2400()
        {
            CEC488.send(18, "*RST", out status);
            CEC488.send(18, ":OUTP OFF", out status);
        }

        public void NMOS_snagas() //
        {
            device_2400.Write("*RST");
            device_2400.Write(":SOUR:FUNC CURR");
            device_2400.Write(":SOUR:CURR:MODE FIX");
            device_2400.Write(":SOUR:CURR:RANG:AUTO ON");
            device_2400.Write(":SOUR:CURR:LEV 0");
            device_2400.Write(":SENS:VOLT:PROT 50");
            device_2400.Write(":SENS:FUNC 'VOLT'");
            device_2400.Write(":SENS:VOLT:RANG:AUTO ON");
            device_2400.Write(":FORM:ELEM VOLT");
            device_2400.Write(":OUTP ON");






            /**
            device_2636.Write("smua.reset()");  //SMUA - kanal A
            device_2636.Write("smua.sense = smua.SENSE_LOCAL");
            device_2636.Write("smua.source.func = smua.OUTPUT_DCAMPS");
            device_2636.Write("smua.source.autorangei = smua.AUTORANGE_ON");
            device_2636.Write("smua.source.leveli = 0");
            device_2636.Write("smua.measure.autorangev = smua.AUTORANGE_ON");
            device_2636.Write("smua.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smua.source.limitv = 50");
            device_2636.Write("smua.measure.v()");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara
            device_2636.Write("smua.source.output = smua.OUTPUT_ON");

            
            device_2636.Write("smub.reset()"); //SMUB  kanal B
            device_2636.Write("smub.sense = smub.SENSE_LOCAL");
            device_2636.Write("smub.source.func = smub.OUTPUT_DCAMPS");
            device_2636.Write("smub.source.autorangei = smub.AUTORANGE_ON");
            device_2636.Write("smub.source.leveli = 0");
            device_2636.Write("smub.measure.autorangev = smub.AUTORANGE_ON");
            device_2636.Write("smub.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smub.source.limitv = 10");
            device_2636.Write("smub.measure.v()");
            device_2636.Write("smub.source.output = smub.OUTPUT_ON");

            
            device_2636.Write("sumb.reset()"); 
            device_2636.Write("sumb.sense = sumb.SENSE_LOCAL")
            **/

            // pisiRC = new StreamWriter(path.Text + filenameRC.Text + "_I-V_" + brojAcharging.ToString() + ".m"); //naziv fajla gde se upisuju vrednosti

            pisiRC = new StreamWriter(path.Text + filenameRC.Text + brojAcharging.ToString() + "_9" + ".m"); //naziv fajla gde se upisuju vrednosti
                brojAcharging++;

            vreme = DateTime.Now;

            pisiRC.WriteLine("% Vreme merenja : " + vreme);

            pisiRC.WriteLine("y = [");

            pocetna_struja = System.Double.Parse(textBox3.Text) / 1000000000000;
            krajnja_struja = System.Double.Parse(textBox1.Text) / 1000000000000;
            broj_koraka = System.Double.Parse(textBox2.Text);

            konstanta = Math.Pow(10, (Math.Abs(Math.Log10(Math.Abs(krajnja_struja)) - Math.Log10(Math.Abs(pocetna_struja))) / (broj_koraka - 1)));

            for (brojac = 0; brojac <= broj_koraka - 1; brojac = brojac + 1)
            {
                /**
                device_2636.Write("smua.source.leveli = " + (pocetna_struja * Math.Pow(konstanta, brojac)).ToString()); //kanalA zadaje struju
                device_2636.Write("print(smua.measure.v())"); //kanalA meri napon
                naponn = device_2636.ReadString();
             **/

                device_2400.Write(":SOUR:CURR:LEV " + (pocetna_struja * Math.Pow(konstanta, brojac)).ToString()); //zadaje struju
                device_2400.Write("SENS:FUNC 'VOLT'"); //meri napon
                
                naponn = device_2400.ReadString();

                pisiRC.Write((Math.Abs(pocetna_struja) * Math.Pow(konstanta, brojac)).ToString() + "\t" + naponn);
                listRC.Add(-System.Double.Parse(naponn), (Math.Abs(pocetna_struja) * Math.Pow(konstanta, brojac)));          // x y
            }

            pisiRC.WriteLine("];");
            pisiRC.WriteLine("");
            pisiRC.Close();

            device_2400.Write("*RST");
            device_2400.Write(":OUTP OFF");

            //device_2636.Write("smua.reset()");
            //device_2636.Write("smua.source.output = smua.OUTPUT_OFF");
           
            //device_2636.Write("smub.reset()");
           // device_2636.Write("smub.source.output = smub.OUTPUT_OFF"); //kraj, gasenje uredaja+*/
           
        }

        public void meri_epad_b()
        {
            device_2636.Write("smub.reset()");
            device_2636.Write("smub.sense = smub.SENSE_LOCAL");
            device_2636.Write("smub.source.func = smub.OUTPUT_DCAMPS");
            device_2636.Write("smub.source.autorangei = smub.AUTORANGE_ON");
            device_2636.Write("smub.source.leveli = 0");
            device_2636.Write("smub.measure.autorangev = smub.AUTORANGE_ON");
            device_2636.Write("smub.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smub.source.limitv = 10");
            device_2636.Write("smub.measure.v()");
            device_2636.Write("smub.source.output = smub.OUTPUT_ON");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara

            Vth_struja = 0.000001; // 1 uA
            ZTC_struja = 0.000068; // 68 uA

            if (choose == 1)
            {
                pisiRC = new StreamWriter(path.Text + filenameRC2.Text + "_Bcharging_" + brojBcharging.ToString() + ".m"); //merenje programirajuceg tranzistora
                brojBcharging++;
            }
            else
            {
                pisiRC = new StreamWriter(path.Text + filenameRC2.Text + "_Bmonitoring_" + brojBmonitoring.ToString() + ".m");
                brojBmonitoring++;
            }

            vreme = DateTime.Now;

            pisiRC.WriteLine("% Vreme merenja : " + vreme);

            device_2636.Write("smub.source.leveli = " + Vth_struja.ToString());
            device_2636.Write("print(smub.measure.v())");
            naponn = device_2636.ReadString();
            pisiRC.WriteLine("Vth = [" + naponn + "];");

            device_2636.Write("smub.source.leveli = " + ZTC_struja.ToString());
            device_2636.Write("print(smub.measure.v())");
            naponn = device_2636.ReadString();
            pisiRC.WriteLine("ZTC = [" + naponn + "];");

            device_2636.Write("smub.source.leveli = 0"); //da vrati karakteristiku na pocetak

            pisiRC.WriteLine("y = [");

            pocetna_struja = System.Double.Parse(textBox3.Text) / 1000000000000;
            //pocetna_struja = 0.000001; //A prilikom merenja ZTC-a
            krajnja_struja = System.Double.Parse(textBox1.Text) / 1000000000000;
            if (choose == 1)
            {
                krajnja_struja = 0.001; //merenje programirajuceg tranzistora
            }
            //krajnja_struja = 0.000150; //A prilikom merenja ZTC-a 
            broj_koraka = System.Double.Parse(textBox2.Text);

            konstanta = Math.Pow(10, (Math.Abs(Math.Log10(Math.Abs(krajnja_struja)) - Math.Log10(Math.Abs(pocetna_struja))) / (broj_koraka - 1)));

            for (brojac = 0; brojac <= broj_koraka - 1; brojac = brojac + 1)
            {
                device_2636.Write("smub.source.leveli = " + (pocetna_struja * Math.Pow(konstanta, brojac)).ToString());
                device_2636.Write("print(smub.measure.v())");
                naponn = device_2636.ReadString();
                pisiRC.WriteLine((Math.Abs(pocetna_struja) * Math.Pow(konstanta, brojac)).ToString() + "\t" + naponn);
                listRC.Add(System.Double.Parse(naponn), (Math.Abs(pocetna_struja) * Math.Pow(konstanta, brojac)));          // x y
            }

            pisiRC.WriteLine("];");
            pisiRC.WriteLine("");
            pisiRC.Close();

            device_2636.Write("smub.reset()");
            device_2636.Write("smub.source.output = smub.OUTPUT_OFF");
            device_2636.Write("smua.reset()");
            device_2636.Write("smua.source.output = smua.OUTPUT_OFF");
        }

        public void meri_Vth_ZTC_a()
        {
            Delegate delBrojac = new delBrojKoraka(TrenutnoBrojKoraka);
            device_2636.Write("smua.reset()");
            device_2636.Write("smua.sense = smua.SENSE_LOCAL");
            device_2636.Write("smua.source.func = smua.OUTPUT_DCAMPS");
            device_2636.Write("smua.source.autorangei = smua.AUTORANGE_ON");
            device_2636.Write("smua.source.leveli = 0");
            device_2636.Write("smua.measure.autorangev = smua.AUTORANGE_ON");
            device_2636.Write("smua.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smua.source.limitv = 10");
            device_2636.Write("smua.measure.v()");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara
            device_2636.Write("smua.source.output = smua.OUTPUT_ON");

            Vth_struja = 0.000001; // 1 uA
            ZTC_struja = 0.000068; // EPAD, savet: prethodno odrediti ZTC struju

            device_2636.Write("smua.source.leveli = " + Vth_struja.ToString());
            device_2636.Write("print(smua.measure.v())");
            naponn = device_2636.ReadString();

            Vth0_a = Convert.ToDouble(naponn);

            device_2636.Write("smua.source.leveli = " + ZTC_struja.ToString());
            device_2636.Write("print(smua.measure.v())");
            naponn = device_2636.ReadString();

            ZTC_a = Convert.ToDouble(naponn);

            device_2636.Write("smua.source.output = smua.OUTPUT_OFF");

            trenutni_korak = Convert.ToString(Vth0_a);
            this.Invoke(delBrojac);
        }

        public void meri_Vth_ZTC_b()
        {
            Delegate delBrojac = new delBrojKoraka(TrenutnoBrojKoraka);
            device_2636.Write("smub.reset()");
            device_2636.Write("smub.sense = smub.SENSE_LOCAL");
            device_2636.Write("smub.source.func = smub.OUTPUT_DCAMPS");
            device_2636.Write("smub.source.autorangei = smub.AUTORANGE_ON");
            device_2636.Write("smub.source.leveli = 0");
            device_2636.Write("smub.measure.autorangev = smub.AUTORANGE_ON");
            device_2636.Write("smub.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smub.source.limitv = 10");
            device_2636.Write("smub.measure.v()");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara
            device_2636.Write("smub.source.output = smub.OUTPUT_ON");

            Vth_struja = 0.000001; // 1 uA
            ZTC_struja = 0.000068; // EPAD, savet: prethodno odrediti ZTC struju

            device_2636.Write("smub.source.leveli = " + Vth_struja.ToString());
            device_2636.Write("print(smub.measure.v())");
            naponn2 = device_2636.ReadString();

            Vth0_b = Convert.ToDouble(naponn2);

            device_2636.Write("smub.source.leveli = " + ZTC_struja.ToString());
            device_2636.Write("print(smub.measure.v())");
            naponn2 = device_2636.ReadString();

            ZTC_b = Convert.ToDouble(naponn2);

            device_2636.Write("smub.source.output = smub.OUTPUT_OFF");

            trenutni_korak = Convert.ToString(Vth0_b);
            this.Invoke(delBrojac);
        }

        public void meri_ZTC_a()
        {
            Delegate delBrojac = new delBrojKoraka(TrenutnoBrojKoraka);
            Delegate del = new delegat(iscrtajGrafik);
            ZTC_struja = 0.000068; // EPAD, savet: prethodno odrediti ZTC struju

            device_2636.Write("smua.reset()");
            device_2636.Write("smua.sense = smua.SENSE_LOCAL");
            device_2636.Write("smua.source.func = smua.OUTPUT_DCAMPS");
            device_2636.Write("smua.source.autorangei = smua.AUTORANGE_ON");
            device_2636.Write("smua.source.leveli = " + ZTC_struja.ToString());  //device_2636.Write("smua.source.leveli = 0");
            device_2636.Write("smua.measure.autorangev = smua.AUTORANGE_ON");
            device_2636.Write("smua.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smua.source.limitv = 10");
            device_2636.Write("smua.measure.v()");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara

            if (Zastavica == 0)
            {
                sw.Start();
            }

            device_2636.Write("smua.source.output = smua.OUTPUT_ON");
            device_2636.Write("print(smua.measure.v())");
            device_2636.Write("smua.source.output = smua.OUTPUT_OFF");
            naponn = device_2636.ReadString();

            proteklo = sw.ElapsedMilliseconds;
            pisiRC.WriteLine(proteklo + "\t" + naponn);
            Vth0_a = Convert.ToDouble(naponn) - Delta_a;
            trenutni_korak = Convert.ToString(Vth0_a);
            this.Invoke(delBrojac); //ispisuje trenutnu vrednost napona EPAD1
            proteklo = proteklo / 1000;
            listRC.Add(proteklo, Vth0_a);
            this.Invoke(del); //iscrtavace tacku na grafiku EPAD1
        }

        public void meri_ZTC_b()
        {
            Delegate delBrojac2 = new delBrojKoraka2(TrenutnoBrojKoraka2);
            Delegate delGrafikTemp = new delPrag(iscrtajGrafikPrag);
            ZTC_struja = 0.000068; // EPAD, savet: prethodno odrediti ZTC struju

            device_2636.Write("smub.reset()");
            device_2636.Write("smub.sense = smub.SENSE_LOCAL");
            device_2636.Write("smub.source.func = smub.OUTPUT_DCAMPS");
            device_2636.Write("smub.source.autorangei = smub.AUTORANGE_ON");
            device_2636.Write("smub.source.leveli = " + ZTC_struja.ToString());  //device_2636.Write("smub.source.leveli = 0");
            device_2636.Write("smub.measure.autorangev = smub.AUTORANGE_ON");
            device_2636.Write("smub.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smub.source.limitv = 10");
            device_2636.Write("smub.measure.v()");
            device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara

            if (Zastavica == 0)
            {
                sw2.Start();
            }

            device_2636.Write("smub.source.output = smub.OUTPUT_ON");
            device_2636.Write("print(smub.measure.v())");
            device_2636.Write("smub.source.output = smub.OUTPUT_OFF");
            naponn2 = device_2636.ReadString();

            proteklo2 = sw2.ElapsedMilliseconds;
            pisiRC2.WriteLine(proteklo2 + "\t" + naponn2);
            Vth0_b = Convert.ToDouble(naponn2) - Delta_b;
            trenutni_korak2 = Convert.ToString(Vth0_b);
            this.Invoke(delBrojac2); //ispisuje trenutnu vrednost napona EPAD2
            proteklo2 = proteklo2 / 1000;
            listPrag.Add(proteklo2, Vth0_b);
            this.Invoke(delGrafikTemp); //iscrtavace tacku na grafiku EPAD2
        }

        public void meri_Vth_a()
        {
            Delegate delBrojac = new delBrojKoraka(TrenutnoBrojKoraka);
            device_2636.Write("smua.reset()");
            device_2636.Write("smua.sense = smua.SENSE_LOCAL");
            device_2636.Write("smua.source.func = smua.OUTPUT_DCAMPS");
            device_2636.Write("smua.source.autorangei = smua.AUTORANGE_ON");
            device_2636.Write("smua.source.leveli = 0");
            device_2636.Write("smua.measure.autorangev = smua.AUTORANGE_ON");
            device_2636.Write("smua.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smua.source.limitv = 10");
            device_2636.Write("smua.measure.v()");
            device_2636.Write("smua.source.output = smua.OUTPUT_ON");
            //device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara

            Vth_struja = 0.000001; // 1 uA

            device_2636.Write("smua.source.leveli = " + Vth_struja.ToString());
            device_2636.Write("print(smua.measure.v())");
            naponn = device_2636.ReadString();
            //pisiVth.WriteLine("Vth0 = [" + naponn + "];");  //moze se koristiti kao provera

            Vth0 = Convert.ToDouble(naponn);
            Vth0 = Vth0 - 1; // prebacivanje u delta Vth0

            device_2636.Write("smua.source.output = smua.OUTPUT_OFF");

            trenutni_korak = Convert.ToString(Vth0);
            this.Invoke(delBrojac);
        }

        public void meri_Vth_b()
        {
            Delegate delBrojac = new delBrojKoraka(TrenutnoBrojKoraka);
            device_2636.Write("smub.reset()");
            device_2636.Write("smub.sense = smub.SENSE_LOCAL");
            device_2636.Write("smub.source.func = smub.OUTPUT_DCAMPS");
            device_2636.Write("smub.source.autorangei = smub.AUTORANGE_ON");
            device_2636.Write("smub.source.leveli = 0");
            device_2636.Write("smub.measure.autorangev = smub.AUTORANGE_ON");
            device_2636.Write("smub.measure.nplc = 1"); //DODATAK BRZINA MERENJA
            device_2636.Write("smub.source.limitv = 10");
            device_2636.Write("smub.measure.v()");
            device_2636.Write("smub.source.output = smub.OUTPUT_ON");
            //device_2636.Write("format.asciiprecision = 16"); //vraca merene vrednosti sa 16 cifara

            Vth_struja = 0.000001; // 1 uA

            device_2636.Write("smub.source.leveli = " + Vth_struja.ToString());
            device_2636.Write("print(smub.measure.v())");
            naponn = device_2636.ReadString();
            //pisiVth.WriteLine("Vth0 = [" + naponn + "];");  //moze se koristiti kao provera

            Vth0 = Convert.ToDouble(naponn);
            Vth0 = Vth0 - 1; // prebacivanje u delta Vth0

            device_2636.Write("smub.source.output = smub.OUTPUT_OFF");

            trenutni_korak = Convert.ToString(Vth0);
            this.Invoke(delBrojac);
        }

        public void iscrtajGrafik()
        {
            zedRC.GraphPane.AddCurve("", listRC, Color.Black, SymbolType.Circle).Line.Color = Color.White; //Add the curve with using the data from list
            zedRC.GraphPane.Title.Text = "Strujno-naponska karakteristika"; //Add the graph title 
            zedRC.GraphPane.XAxis.Title.Text = "Mereni napon [V]"; //Add the XAxis label
            zedRC.GraphPane.YAxis.Title.Text = "Zadata struja [A]"; //Add the YAxis label
            zedRC.GraphPane.XAxis.MajorGrid.IsVisible = true; //Set the grid
            zedRC.GraphPane.YAxis.MajorGrid.IsVisible = true; //Set the grid
            zedRC.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedRC.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedRC.AxisChange();
            zedRC.Refresh(); //Refresh the graph
        }

        public void iscrtajGrafikPrag()
        {
            zedPrag.GraphPane.AddCurve("", listPrag, Color.Black, SymbolType.Circle).Line.Color = Color.White; //Add the curve with using the data from list
            zedPrag.GraphPane.Title.Text = "EPAD2: highsens"; //Add the graph title 
            zedPrag.GraphPane.XAxis.Title.Text = "Vreme (s)"; //Add the XAxis label
            zedPrag.GraphPane.YAxis.Title.Text = "Promena napona praga (V)"; //Add the YAxis label
            zedPrag.GraphPane.XAxis.MajorGrid.IsVisible = true; //Set the grid
            zedPrag.GraphPane.YAxis.MajorGrid.IsVisible = true; //Set the grid
            zedPrag.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedPrag.GraphPane.YAxis.MajorGrid.Color = Color.Black; //Set the grid color
            zedPrag.AxisChange();
            zedPrag.Refresh(); //Refresh the graph
        }

        //public void updateProgressBar()
        //{
        //    progressBar1.Value = progresBarVrednost;
        //    lblPercentage.Text = progresBarVrednost + "%";
        //}

        public void ocistiGrafikIIsprazniListu()
        {
            listRC.Clear();
            listPrag.Clear();

            zedPrag.GraphPane.CurveList.Clear();        //Cistimo gornji grafik
            zedPrag.GraphPane.GraphObjList.Clear();
            zedPrag.Refresh();

            zedRC.GraphPane.CurveList.Clear();        //Cistimo donji grafik
            zedRC.GraphPane.GraphObjList.Clear();
            zedRC.Refresh();
        }

        //public void obavestiMerenje()
        //{
        //    displej.Text += "Merenje: " + iteratorZaMerenja + "/" + ukupanBrojMerenja + "\n";
        //}

        public void obavestiProgramiranje()
        {
            //displej.Text += "P: " + Vth0 + "\t" + suma + "\n";
            displej.Text += "EPAD1: Highsens" + "\n";
        }

        public void obavestiZadatNapon()
        {
            //displej.Text += "Zadat Vth: " + Vth + "\n";
            displej.Text += "EPAD2: Highsens" + "\n";
        }

        public void TrenutnoBrojKoraka()
        {
            lab_trenutni_korak.Text = trenutni_korak;
        }

        public void TrenutnoBrojKoraka2()
        {
            lab_trenutni_korak2.Text = trenutni_korak2;
        }

        public void TrenutnoBrojKoraka3()
        {
            lab_trenutni_korak3.Text = trenutni_korak3;
        }

        public void TrenutnoBrojKoraka4()
        {
            lab_trenutni_korak4.Text = trenutni_korak4;
        }

        private void start_Click(object sender, EventArgs e)
        {
            displej.Text += "POCETAK MERENJA" + "\n";
            displej.Refresh();

            //progressBar1.Value = 0;

            if (path.Text == "")
            {
                System.IO.Directory.CreateDirectory(@"C:\Default");
                //path.Text = @"C:\Default\";
                path.Text = @"D:\Strahinja\";
            }


            for (int iter = 0; iter < 2; iter++)
            {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                Thread.Sleep(500);
                iscrtajGrafik();
                Thread.Sleep(500);
            }


        }

        private void btnVreme_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)txtVreme;
            this.vremeObrade = Convert.ToDouble(tb.Text);

            if (tb.Enabled)
            {
                displej.Text += "Zeljena doza unesena" + "\n";
                tb.Enabled = false;
            }
            else
            {
                tb.Enabled = true;
            }
        }

        private void btnUkupanBrojMerenja_Click(object sender, EventArgs e)
        {
            TextBox tb2 = (TextBox)txtUkupanBrojMerenja;
            this.ukupanBrojMerenja = Convert.ToDouble(tb2.Text);

            if (tb2.Enabled)
            {
                displej.Text += "Brzina doze unesena" + "\n";
                tb2.Enabled = false;
            }
            else
            {
                tb2.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (backgroundWorker1.CancellationPending)
                e.Cancel = true;

            Delegate del = new delegat(iscrtajGrafik);
            Delegate delCrtajFunkciju = new delPrag(iscrtajGrafikPrag);

            //serialPort1.Open(); //otvaranje komunikacija sa Arduinom
            //Thread.Sleep(2000);

            //OVDE POZIVAS FUNKCIJE KOJE RADE MERENJE
            NMOS_snagas(); //meri karakteristiku 
            this.Invoke(del); //crta grafik

            //gasi_2636a();
            //gasi_2636b();
            gasi_2400();

            //serialPort1.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
            //lblPercentage.Text = e.ProgressPercentage + "%";
            //progressBar1.PerformStep();
            displej.Text += "Merenje: " + (e.ProgressPercentage) / (100 / ukupanBrojMerenja) + "/" + ukupanBrojMerenja + "\n";
            //Application.DoEvents();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                displej.Text += "MERENJE PREKINUTO.\n";
            }
            else if (e.Error != null)
            {
                displej.Text += "KRAJ MERENJA.\n";
            }
            else
            {
                displej.Text += "KRAJ MERENJA.\n";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminacija)
            {
                DialogResult dialog = MessageBox.Show("Da li zaista zelite da napustite program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }

        }

        private void Path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}