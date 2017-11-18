using osu_meme.Extensions;
using System;
using System.Collections.Generic;
using System.IO;

namespace osu_meme.osu
{
	public class DatabaseReader
	{
		public int UniqueSongCount;
		public int NumberOfBeatmaps;

		private const string OSU_DB_NAME = "osu!.db";

		public List<Beatmap> Beatmaps;

		public DatabaseReader( )
		{
			Beatmaps = new List<Beatmap>( );
		}

		public void ReadOsuGameDatabase( )
		{
			var osuBasePath = Path.Combine( Game.GetOsuBasePath( ), OSU_DB_NAME );

			if ( !File.Exists( osuBasePath ) )
			{
				throw new Exception( "osu!.db doesnt exist in game directory" );
			}

			using ( var sr = new BinaryReaderEx( new StreamReader( osuBasePath ).BaseStream ) )
			{	
				// skip db version
				sr.ReadInt32( );
				UniqueSongCount = sr.ReadInt32( );
				// skip banned user shit
				sr.ReadBoolean( );
				sr.ReadInt64( );
				sr.ReadString( );

				NumberOfBeatmaps = sr.ReadInt32( );

				Logger.Instance.Info( $"Found {NumberOfBeatmaps} beatmaps in {OSU_DB_NAME}, parsing db..." );

				for ( int i = 0; i < NumberOfBeatmaps; i++ )
				{
					long endOffset = sr.BaseStream.Position + sr.ReadInt32( ) + 4;

					var bm = new Beatmap( );
					bm.ParseDatabaseBeatmapData( sr );
					Beatmaps.Add( bm );

					sr.BaseStream.Seek( endOffset, SeekOrigin.Begin );
				}

				Logger.Instance.Info( $"Read {Beatmaps.Count} beatmaps from game database" );
			}
		}
	}
}
