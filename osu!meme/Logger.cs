using System;
using System.Diagnostics;
using System.IO;

namespace osu_meme
{
	public class Logger
	{
		public enum LogLevel
		{
			Info,
			Warning,
			Error
		}

		public void Error( string text )
		{
			Log( text, LogLevel.Error );
		}

		public void Warning( string text )
		{
			Log( text, LogLevel.Warning );
		}

		[Conditional( "DEBUG" )]
		public void Info( string text )
		{
			Log( text, LogLevel.Info );
		}

		public void Profile(Action func, string profileName = "")
		{
			var sw = new Stopwatch( );
			sw.Start( );
			func( );
			sw.Stop( );

			Info( $"Profile finished on function in {sw.ElapsedMilliseconds}ms ({profileName})" );
		}

		protected void Log( string text, LogLevel level = LogLevel.Info )
		{
			switch ( level )
			{
				case LogLevel.Warning:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;
				case LogLevel.Error:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
			}

			var dt = DateTime.Now;
			var dts = string.Format( "[{0}:{1}:{2}.{3}] ", dt.Hour.ToString( "#00" ), dt.Minute.ToString( "#00" ), dt.Second.ToString( "#00" ), dt.Millisecond.ToString( "#000" ) );
			Console.Write( dts );

			var loglevel = string.Format( "[{0}] ", level.ToString( ) );
			Console.Write( loglevel );
			Console.WriteLine( text );

			File.AppendAllText(
				"./logs/" + dt.Date.Year + dt.Date.Month.ToString( "#00" ) + dt.Date.Day.ToString( "#00" ) + ".log",
				string.Format( "{0}{1}{2}\n", dts, loglevel, text )
			);
		}

		private static Logger _Instance = null;
		public static Logger Instance
		{
			get
			{
				if ( _Instance == null )
				{
					_Instance = new Logger( );
				}

				return _Instance;
			}
		}
	}
}
