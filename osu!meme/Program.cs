using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace osu_meme
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( )
		{
			if ( !Directory.Exists( "./logs" ) )
			{
				Directory.CreateDirectory( "./logs" );
			}

			ShowDebugConsole( );

			Application.EnableVisualStyles( );
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new Form1( ) );
		}

		[Conditional( "DEBUG" )]
		static void ShowDebugConsole( )
		{
			// pasta: https://stackoverflow.com/questions/15578540/allocconsole-not-printing-when-in-visual-studio

			AllocConsole( );

			var hOut = GetStdHandle( STD_OUTPUT_HANDLE );
			var hRealOut = CreateFile( "CONOUT$", GENERIC_READ | GENERIC_WRITE, FileShare.Write, IntPtr.Zero, FileMode.OpenOrCreate, 0, IntPtr.Zero );
			if ( hRealOut != hOut )
			{
				SetStdHandle( STD_OUTPUT_HANDLE, hRealOut );
				Console.SetOut( new StreamWriter( Console.OpenStandardOutput( ), Console.OutputEncoding ) { AutoFlush = true } );
			}
		}

		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern IntPtr GetStdHandle( int nStdHandle );

		[DllImport( "kernel32.dll", SetLastError = true )]
		public static extern bool SetStdHandle( int nStdHandle, IntPtr hHandle );

		public const int STD_OUTPUT_HANDLE = -11;
		public const int STD_INPUT_HANDLE = -10;
		public const int STD_ERROR_HANDLE = -12;

		[DllImport( "kernel32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		public static extern IntPtr CreateFile(
			[MarshalAs( UnmanagedType.LPTStr )] string filename,
			[MarshalAs( UnmanagedType.U4 )]		uint access,
			[MarshalAs( UnmanagedType.U4 )]		FileShare share,
												IntPtr securityAttributes,
			[MarshalAs( UnmanagedType.U4 )]		FileMode creationDisposition,
			[MarshalAs( UnmanagedType.U4 )]		FileAttributes flagsAndAttributes,
												IntPtr templateFile
		);

		public const uint GENERIC_WRITE = 0x40000000;
		public const uint GENERIC_READ = 0x80000000;

		[DllImport( "kernel32" )]
		static extern bool AllocConsole( );
	}
}
