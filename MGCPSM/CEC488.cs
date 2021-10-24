// cec488.cs
//
//  Interface from C# to CEC488 GPIB library
//
//    Include this module in your project, and call functions from
//    class CEC488.  For example:
//
//         int len,status;
//         string r;
//         CEC488.initialize( 21, 0 );
//         CEC488.send( 16, "*IDN?", out status );
//	   CEC488.enter( out r, 100, out len, 16, out status );
//
//    Note that some parameters require the "out" keyword, since they
//    return values.
//


using System.Runtime.InteropServices;
using System.Text;

public class CEC488 
{
    // ----------------
    // initialize
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_initialize@8")]
	public static extern 
	void initialize(
								[MarshalAs(UnmanagedType.I4),In]	
		int myaddr,
								[MarshalAs(UnmanagedType.I4),In]	
		int level );

    // ----------------
	// send
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_send@16")]
								static extern int cec488send(
								[MarshalAs(UnmanagedType.I4),In]	int addr,
								[MarshalAs(UnmanagedType.LPStr),In] string s,
								[MarshalAs(UnmanagedType.I4),In]	int len,
								[MarshalAs(UnmanagedType.I4),Out]   out int status);
	public static 
	int send( 
		int addr, 
		string s, 
		out int status )
			{
				int st,r;
				r = cec488send(addr,s,65535,out st);
				status = st;
				return r;
			}

    // ----------------
	// enter
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_enter@20")]
								static extern int cec488enter(
								[MarshalAs(UnmanagedType.LPStr),In,Out] StringBuilder r,
								[MarshalAs(UnmanagedType.U4),In] int maxlen,
								[MarshalAs(UnmanagedType.U4),Out] out int len,
								[MarshalAs(UnmanagedType.I4),In] int addr,
								[MarshalAs(UnmanagedType.I4),Out] out int status);
	public static 
		int enter(
		out string r,
		int maxlen,
		out int len,
		int addr,
		out int status )
		{
			int st,l,retval;
			StringBuilder sb = new StringBuilder( maxlen );
			retval = cec488enter( sb, maxlen, out l, addr, out st );
			status = st;
			len =l;
			r = sb.ToString();
			return retval;
		}


    // ----------------
	// spoll
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_spoll@12")]
	public static extern 
	int spoll(
								[MarshalAs(UnmanagedType.I4),In]	
		int addr,
								[MarshalAs(UnmanagedType.U1),Out]
		out byte poll,
								[MarshalAs(UnmanagedType.I4),Out]   
		out int status);

    // ----------------
	// ppoll
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_ppoll@4")]
	public static extern 
	int ppoll(
								[MarshalAs(UnmanagedType.U1),Out]	
		out byte poll );

    // ----------------
	// transmit
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_transmit@12")]
								static extern int cec488xmit(
								[MarshalAs(UnmanagedType.LPStr),In] string s,
								[MarshalAs(UnmanagedType.I4),In]	int len,
								[MarshalAs(UnmanagedType.I4),Out]   out int status);
	public static 
	int transmit( 
		string s, 
		out int status )
			{
				int st,r;
				r = cec488xmit(s,65535,out st);
				status = st;
				return r;
			}

    // ----------------
	// receive
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_receive@16")]
								static extern int cec488receive(
								[MarshalAs(UnmanagedType.LPStr),In,Out] StringBuilder r,
								[MarshalAs(UnmanagedType.U4),In] int maxlen,
								[MarshalAs(UnmanagedType.U4),Out] out int len,
								[MarshalAs(UnmanagedType.I4),Out] out int status );
	public static
		int receive(
		out string r,
		int maxlen,
		out int len,
		out int status )
		{
			int l,st,retval;
			StringBuilder sb = new StringBuilder( maxlen );
			retval = cec488receive( sb, maxlen, out l, out st );
			status = st;
			len =l;
			r = sb.ToString();
			return retval;
		}

    // ----------------
	// tarray
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_tarray@16")]
	public static extern 
	int tarray(
								[MarshalAs(UnmanagedType.LPArray,SizeParamIndex=1),In] 
		byte[] r,
								[MarshalAs(UnmanagedType.U4),In]	
		int len,
								[MarshalAs(UnmanagedType.I4),In]	
		int eoi,
								[MarshalAs(UnmanagedType.I4),Out]   
		out int status);

    // ----------------
	// rarray
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_rarray@16")]
								static extern int cec488rarray(
								[MarshalAs(UnmanagedType.LPArray,SizeParamIndex=2),In,Out] byte[] r,
								[MarshalAs(UnmanagedType.U4),In] int maxlen,
								[MarshalAs(UnmanagedType.U4),Out] out int actuallen,
								[MarshalAs(UnmanagedType.I4),Out] out int status);
	public static 
		int rarray(
		out byte[] r,
		int maxlen,
		out int len,
		out int status)
		{
			int l,st,retval;
		    r = new byte [maxlen];
		    l = maxlen;
			retval = cec488rarray( r, maxlen, out l, out st );
			status = st;
			len = l;
			return retval;
		}

    // ----------------
	// srq
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_srq@0")]
	public static extern 
	bool srq( );

    // ----------------
	// boardselect
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_boardselect@4")]
	public static extern 
	int boardselect(
								[MarshalAs(UnmanagedType.I4),In]	
		int boardnum );

    // ----------------
	// settimeout
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_settimeout@4")]
	public static extern 
	int settimeout(
								[MarshalAs(UnmanagedType.I4),In]	
		int timeout );

    // ----------------
	// setinputEOS
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_setinputEOS@4")]
	public static extern 
	int setinputEOS(
								[MarshalAs(UnmanagedType.I4),In]	
		int eos  );

    // ----------------
	// setoutputEOS
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_setoutputEOS@8")]
	public static extern 
	int setoutputEOS(
								[MarshalAs(UnmanagedType.I4),In]	
		int eos1,
								[MarshalAs(UnmanagedType.I4),In]	
		int eos2 );

    // ----------------
	// gpib_board_present
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_board_present@0")]
	public static extern 
	bool gpib_board_present( );

    // ----------------
	// gpib_feature
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_feature@4")]
	public static extern 
	int gpib_feature(
								[MarshalAs(UnmanagedType.I4),In]	
		int index  );

    // ----------------
	// listener_present
    // ----------------
								[DllImport("ieee_32m.dll",
									 CallingConvention=CallingConvention.StdCall,
									 EntryPoint="_ieee_listener_present@4")]
	public static extern 
	bool listener_present(
								[MarshalAs(UnmanagedType.I4),In]	
		int addr );


}