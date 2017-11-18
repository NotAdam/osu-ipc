using osu_meme.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace osu_meme.osu
{
	// defined as sequential so that fields can be ordered by MetadataToken and returned in the order they're defined
	[StructLayout( LayoutKind.Sequential )]
	public class Beatmap
	{
		// beatmap db data
		public string Artist, ArtistUnicode;
		public string Title, TitleUnicode;
		public string Creator;
		public string Difficulty;
		public string AudioFileName;
		public string BeatmapChecksum;
		public string BeatmapFilename;

		// internals
		protected string ResolvedBeatmapPath;

		public IEnumerable<FieldInfo> GetOrderedBeatmapFields( )
		{
			return GetType( ).GetFields( BindingFlags.Instance | BindingFlags.Public ).OrderBy( field => field.MetadataToken );
		}

		public MethodInfo GetMatchingReadMethod( Type type )
		{
			var methods = typeof( BinaryReaderEx ).GetMethods( BindingFlags.Instance | BindingFlags.Public );

			return methods.First( method => method.ReturnType == type );
		}

		public void ParseDatabaseBeatmapData( BinaryReaderEx br ) // hue hue
		{
			foreach ( var field in GetOrderedBeatmapFields( ) )
			{
				var parser = GetMatchingReadMethod( field.FieldType );

				field.SetValue( this, parser.Invoke( br, new object[ ] { } ) );
			}
		}

		public string ResolveAbsoluteBeatmapPath( )
		{
			// return cached value if we've already found the path
			if (!string.IsNullOrEmpty(ResolvedBeatmapPath))
			{
				return ResolvedBeatmapPath;
			}

			foreach ( var dir in Directory.GetDirectories( Path.Combine( Game.GetOsuBasePath( ), "Songs" ) ) )
			{
				var path = Directory.GetFiles( dir ).FirstOrDefault( f => Path.GetFileName( f ) == BeatmapFilename );

				if ( !string.IsNullOrEmpty( path ) )
				{
					return ResolvedBeatmapPath = path;
				}
			}

			return string.Empty;
		}

		public override string ToString( )
		{
			return $"Beatmap hash: {BeatmapChecksum}, filename: {BeatmapFilename}";
		}

		public string DumpData( )
		{
			var sb = new StringBuilder( );
			sb.AppendLine( "Beatmap data:" );
			foreach ( var field in GetType( ).GetFields( ) )
			{
				sb.AppendLine( $" - {field.Name.PadRight( 20 )} -> {field.GetValue( this )}" );
			}

			sb.AppendLine( $" - {"Resolved path".PadRight( 20 )} -> {ResolveAbsoluteBeatmapPath( )}" );

			return sb.ToString( );
		}
	}
}
