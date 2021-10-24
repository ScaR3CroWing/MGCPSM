namespace MGCPSM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.zedRC = new ZedGraph.ZedGraphControl();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.LinearnaRC = new System.Windows.Forms.RadioButton();
            this.LogoritamskaRC = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.gumica = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.filenameRC = new System.Windows.Forms.TextBox();
            this.displej = new System.Windows.Forms.RichTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.rc_group = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnVreme = new System.Windows.Forms.Button();
            this.txtVreme = new System.Windows.Forms.TextBox();
            this.btnUkupanBrojMerenja = new System.Windows.Forms.Button();
            this.txtUkupanBrojMerenja = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.zedPrag = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filenameRC2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_trenutni_korak = new System.Windows.Forms.Label();
            this.lab_trenutni_korak2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_trenutni_korak3 = new System.Windows.Forms.Label();
            this.lab_trenutni_korak4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.rc_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedRC
            // 
            this.zedRC.Location = new System.Drawing.Point(3, 148);
            this.zedRC.Margin = new System.Windows.Forms.Padding(4);
            this.zedRC.Name = "zedRC";
            this.zedRC.ScrollGrace = 0D;
            this.zedRC.ScrollMaxX = 0D;
            this.zedRC.ScrollMaxY = 0D;
            this.zedRC.ScrollMaxY2 = 0D;
            this.zedRC.ScrollMinX = 0D;
            this.zedRC.ScrollMinY = 0D;
            this.zedRC.ScrollMinY2 = 0D;
            this.zedRC.Size = new System.Drawing.Size(1006, 547);
            this.zedRC.TabIndex = 126;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.LinearnaRC);
            this.groupBox12.Controls.Add(this.LogoritamskaRC);
            this.groupBox12.ForeColor = System.Drawing.Color.Black;
            this.groupBox12.Location = new System.Drawing.Point(12, 84);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(180, 36);
            this.groupBox12.TabIndex = 126;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Izaberite tip skale MG k-ke";
            // 
            // LinearnaRC
            // 
            this.LinearnaRC.AutoSize = true;
            this.LinearnaRC.Checked = true;
            this.LinearnaRC.Location = new System.Drawing.Point(6, 14);
            this.LinearnaRC.Name = "LinearnaRC";
            this.LinearnaRC.Size = new System.Drawing.Size(66, 17);
            this.LinearnaRC.TabIndex = 1;
            this.LinearnaRC.TabStop = true;
            this.LinearnaRC.Text = "Linearna";
            this.LinearnaRC.UseVisualStyleBackColor = true;
            this.LinearnaRC.CheckedChanged += new System.EventHandler(this.LinearnaRC_CheckedChanged_1);
            // 
            // LogoritamskaRC
            // 
            this.LogoritamskaRC.AutoSize = true;
            this.LogoritamskaRC.Location = new System.Drawing.Point(89, 14);
            this.LogoritamskaRC.Name = "LogoritamskaRC";
            this.LogoritamskaRC.Size = new System.Drawing.Size(88, 17);
            this.LogoritamskaRC.TabIndex = 0;
            this.LogoritamskaRC.Text = "Logoritamska";
            this.LogoritamskaRC.UseVisualStyleBackColor = true;
            this.LogoritamskaRC.CheckedChanged += new System.EventHandler(this.LogoritamskaRC_CheckedChanged_1);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Lime;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(1016, 16);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(132, 80);
            this.start.TabIndex = 100;
            this.start.Text = "POKRENITE MERENJE";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Red;
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stop.Location = new System.Drawing.Point(1016, 186);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(132, 74);
            this.stop.TabIndex = 88;
            this.stop.Text = "TERMINACIJA";
            this.stop.UseVisualStyleBackColor = false;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // gumica
            // 
            this.gumica.BackColor = System.Drawing.Color.Yellow;
            this.gumica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gumica.Location = new System.Drawing.Point(1016, 104);
            this.gumica.Name = "gumica";
            this.gumica.Size = new System.Drawing.Size(132, 76);
            this.gumica.TabIndex = 1;
            this.gumica.Text = "CISCENJE GRAFIKA";
            this.gumica.UseVisualStyleBackColor = false;
            this.gumica.Click += new System.EventHandler(this.gumica_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 58);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 17);
            this.label26.TabIndex = 40;
            this.label26.Text = "Ime fajla1:";
            this.label26.UseCompatibleTextRendering = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 28;
            this.label25.Text = "Direktorijum:";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(77, 15);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(290, 20);
            this.path.TabIndex = 36;
            this.path.Text = "C:\\Users\\PC\\Desktop\\Petak 17_9\\";
            this.path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 115);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 13);
            this.label24.TabIndex = 38;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(373, 13);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(64, 23);
            this.save.TabIndex = 44;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.save);
            this.groupBox5.Controls.Add(this.path);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(442, 38);
            this.groupBox5.TabIndex = 200;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Snimanje k-ke";
            // 
            // filenameRC
            // 
            this.filenameRC.Location = new System.Drawing.Point(68, 58);
            this.filenameRC.Name = "filenameRC";
            this.filenameRC.Size = new System.Drawing.Size(115, 20);
            this.filenameRC.TabIndex = 45;
            this.filenameRC.Text = "P";
            this.filenameRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // displej
            // 
            this.displej.BackColor = System.Drawing.Color.Black;
            this.displej.ForeColor = System.Drawing.Color.Lime;
            this.displej.Location = new System.Drawing.Point(779, 16);
            this.displej.Name = "displej";
            this.displej.Size = new System.Drawing.Size(232, 124);
            this.displej.TabIndex = 129;
            this.displej.Text = "";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(863, -1);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(50, 13);
            this.label27.TabIndex = 130;
            this.label27.Text = "DISPLEJ";
            // 
            // rc_group
            // 
            this.rc_group.Controls.Add(this.label35);
            this.rc_group.Controls.Add(this.label32);
            this.rc_group.Controls.Add(this.label47);
            this.rc_group.Controls.Add(this.label34);
            this.rc_group.Controls.Add(this.textBox1);
            this.rc_group.Controls.Add(this.textBox2);
            this.rc_group.Controls.Add(this.label38);
            this.rc_group.Controls.Add(this.textBox3);
            this.rc_group.ForeColor = System.Drawing.Color.Black;
            this.rc_group.Location = new System.Drawing.Point(460, 16);
            this.rc_group.Name = "rc_group";
            this.rc_group.Size = new System.Drawing.Size(193, 99);
            this.rc_group.TabIndex = 195;
            this.rc_group.TabStop = false;
            this.rc_group.Text = "RC podesavanja:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(164, 80);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(20, 13);
            this.label35.TabIndex = 26;
            this.label35.Text = "pA";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(164, 48);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(20, 13);
            this.label32.TabIndex = 25;
            this.label32.Text = "pA";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(4, 21);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(61, 13);
            this.label47.TabIndex = 24;
            this.label47.Text = "Broj koraka";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(4, 74);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 13);
            this.label34.TabIndex = 21;
            this.label34.Text = "Krajnja struja:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(73, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "-100000000000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "300";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(5, 47);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 13);
            this.label38.TabIndex = 10;
            this.label38.Text = "Pocetna struja:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(73, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "-10";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnVreme
            // 
            this.btnVreme.Location = new System.Drawing.Point(1023, 585);
            this.btnVreme.Name = "btnVreme";
            this.btnVreme.Size = new System.Drawing.Size(124, 32);
            this.btnVreme.TabIndex = 206;
            this.btnVreme.Text = "Potvrdite zeljenu dozu";
            this.btnVreme.UseVisualStyleBackColor = true;
            this.btnVreme.Click += new System.EventHandler(this.btnVreme_Click);
            // 
            // txtVreme
            // 
            this.txtVreme.Location = new System.Drawing.Point(1024, 549);
            this.txtVreme.Multiline = true;
            this.txtVreme.Name = "txtVreme";
            this.txtVreme.Size = new System.Drawing.Size(125, 30);
            this.txtVreme.TabIndex = 207;
            // 
            // btnUkupanBrojMerenja
            // 
            this.btnUkupanBrojMerenja.Location = new System.Drawing.Point(1022, 461);
            this.btnUkupanBrojMerenja.Name = "btnUkupanBrojMerenja";
            this.btnUkupanBrojMerenja.Size = new System.Drawing.Size(124, 35);
            this.btnUkupanBrojMerenja.TabIndex = 208;
            this.btnUkupanBrojMerenja.Text = "Potvrdite brzinu doze";
            this.btnUkupanBrojMerenja.UseVisualStyleBackColor = true;
            this.btnUkupanBrojMerenja.Click += new System.EventHandler(this.btnUkupanBrojMerenja_Click);
            // 
            // txtUkupanBrojMerenja
            // 
            this.txtUkupanBrojMerenja.Location = new System.Drawing.Point(1022, 426);
            this.txtUkupanBrojMerenja.Multiline = true;
            this.txtUkupanBrojMerenja.Name = "txtUkupanBrojMerenja";
            this.txtUkupanBrojMerenja.Size = new System.Drawing.Size(126, 29);
            this.txtUkupanBrojMerenja.TabIndex = 209;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM20";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // zedPrag
            // 
            this.zedPrag.Location = new System.Drawing.Point(3, 127);
            this.zedPrag.Margin = new System.Windows.Forms.Padding(4);
            this.zedPrag.Name = "zedPrag";
            this.zedPrag.ScrollGrace = 0D;
            this.zedPrag.ScrollMaxX = 0D;
            this.zedPrag.ScrollMaxY = 0D;
            this.zedPrag.ScrollMaxY2 = 0D;
            this.zedPrag.ScrollMinX = 0D;
            this.zedPrag.ScrollMinY = 0D;
            this.zedPrag.ScrollMinY2 = 0D;
            this.zedPrag.Size = new System.Drawing.Size(754, 13);
            this.zedPrag.TabIndex = 212;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1019, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 214;
            this.label1.Text = "Unesite zeljenu dozu (mGy)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1021, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 215;
            this.label2.Text = "Unesite brzinu doze (mGy/s)";
            // 
            // filenameRC2
            // 
            this.filenameRC2.Location = new System.Drawing.Point(286, 58);
            this.filenameRC2.Name = "filenameRC2";
            this.filenameRC2.Size = new System.Drawing.Size(115, 20);
            this.filenameRC2.TabIndex = 217;
            this.filenameRC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 216;
            this.label3.Text = "Ime fajla2:";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(189, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 223;
            this.label10.Text = "EPAD1:";
            // 
            // lab_trenutni_korak
            // 
            this.lab_trenutni_korak.AutoSize = true;
            this.lab_trenutni_korak.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_trenutni_korak.Location = new System.Drawing.Point(235, 80);
            this.lab_trenutni_korak.Name = "lab_trenutni_korak";
            this.lab_trenutni_korak.Size = new System.Drawing.Size(0, 19);
            this.lab_trenutni_korak.TabIndex = 222;
            // 
            // lab_trenutni_korak2
            // 
            this.lab_trenutni_korak2.AutoSize = true;
            this.lab_trenutni_korak2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_trenutni_korak2.Location = new System.Drawing.Point(235, 101);
            this.lab_trenutni_korak2.Name = "lab_trenutni_korak2";
            this.lab_trenutni_korak2.Size = new System.Drawing.Size(0, 19);
            this.lab_trenutni_korak2.TabIndex = 225;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(189, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 226;
            this.label4.Text = "EPAD2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(659, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 227;
            this.label5.Text = "Doza (mGy):";
            // 
            // lab_trenutni_korak3
            // 
            this.lab_trenutni_korak3.AutoSize = true;
            this.lab_trenutni_korak3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_trenutni_korak3.Location = new System.Drawing.Point(659, 37);
            this.lab_trenutni_korak3.Name = "lab_trenutni_korak3";
            this.lab_trenutni_korak3.Size = new System.Drawing.Size(0, 19);
            this.lab_trenutni_korak3.TabIndex = 228;
            // 
            // lab_trenutni_korak4
            // 
            this.lab_trenutni_korak4.AutoSize = true;
            this.lab_trenutni_korak4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_trenutni_korak4.Location = new System.Drawing.Point(659, 92);
            this.lab_trenutni_korak4.Name = "lab_trenutni_korak4";
            this.lab_trenutni_korak4.Size = new System.Drawing.Size(0, 19);
            this.lab_trenutni_korak4.TabIndex = 229;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(659, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 230;
            this.label6.Text = "Osetljivost (mV/Gy):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 698);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lab_trenutni_korak4);
            this.Controls.Add(this.lab_trenutni_korak3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_trenutni_korak2);
            this.Controls.Add(this.zedRC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.zedPrag);
            this.Controls.Add(this.lab_trenutni_korak);
            this.Controls.Add(this.filenameRC2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.filenameRC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.txtUkupanBrojMerenja);
            this.Controls.Add(this.btnUkupanBrojMerenja);
            this.Controls.Add(this.txtVreme);
            this.Controls.Add(this.btnVreme);
            this.Controls.Add(this.rc_group);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.displej);
            this.Controls.Add(this.gumica);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merenje niskih nivoa struje";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.rc_group.ResumeLayout(false);
            this.rc_group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button gumica;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox displej;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox rc_group;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox filenameRC;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.RadioButton LinearnaRC;
        private System.Windows.Forms.RadioButton LogoritamskaRC;
        private ZedGraph.ZedGraphControl zedRC;
        private System.Windows.Forms.Button btnVreme;
        private System.Windows.Forms.TextBox txtVreme;
        private System.Windows.Forms.Button btnUkupanBrojMerenja;
        private System.Windows.Forms.TextBox txtUkupanBrojMerenja;
        private System.IO.Ports.SerialPort serialPort1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ZedGraph.ZedGraphControl zedPrag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filenameRC2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_trenutni_korak;
        private System.Windows.Forms.Label lab_trenutni_korak2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_trenutni_korak3;
        private System.Windows.Forms.Label lab_trenutni_korak4;
        private System.Windows.Forms.Label label6;
    }
}

