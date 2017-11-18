using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace osu_meme.osu
{
	public class Game
	{
		private DatabaseReader databaseReader;
		private Interprocess interprocess;

		public Game( )
		{
			databaseReader = new DatabaseReader( );
			interprocess = new Interprocess( );
		}

		public static string GetOsuBasePath( )
		{
			var proc = Process.GetProcessesByName( "osu!" ).First( );

			if ( proc == null )
			{
				throw new Exception( "osu!.exe isn't running" );
			}

			return Path.GetDirectoryName( proc.MainModule.FileName );
		}

		public void ReadGameDatabase( )
		{
			databaseReader.ReadOsuGameDatabase( );
		}

		public Beatmap GetPlayingBeatmap( )
		{
			var data = interprocess.GetBulkClientData( );

			return databaseReader.Beatmaps.First( bm => bm.BeatmapChecksum == data.BeatmapChecksum );
		}

		public string DumpData( )
		{
			var data = interprocess.GetBulkClientData( );
			var sb = new StringBuilder( );
			sb.AppendLine( "Game data:" );
			foreach ( var field in data.GetType( ).GetFields( ) )
			{
				if ( !field.Name.StartsWith( "#" ) )
				{
					sb.AppendLine( $" - {field.Name.PadRight(20)} -> {field.GetValue( data )}" );
				}
			}

			return sb.ToString( );
		}
	}
}
