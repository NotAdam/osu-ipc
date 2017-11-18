using System.IO;

namespace osu_meme.Extensions
{
	public class BinaryReaderEx : BinaryReader
	{
		public BinaryReaderEx( Stream input ) : base(input) { }

		public override string ReadString()
		{
			byte b = ReadByte( );
			if ( b == 0x0B )
				return base.ReadString( );
			else if ( b == 0x00 )
				return string.Empty;
			else
				throw new InvalidDataException( $"unknown byte {b.ToString( "X2" )} at offset {BaseStream.Position}" );
		}
	}
}
