using osu;
using osu.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using static osu.Helpers.InterProcessOsu;

namespace osu_meme.osu
{
	public class Interprocess
	{
		protected InterProcessOsu SharedObject;

		public Interprocess( )
		{
			var osuProcess = Process.GetProcessesByName( "osu!" ).First( );

			if ( osuProcess == null )
			{
				throw new Exception( "Unable to find osu! process." );
			}

			Logger.Instance.Info( $@"Found osu!.exe with pid {osuProcess.Id}" );

			SharedObject = Activator.GetObject( typeof( InterProcessOsu ), "ipc://osu!/loader" ) as InterProcessOsu;
		}

		public ClientData GetBulkClientData( )
		{
			return SharedObject.GetBulkClientData( );
		}

		public OsuModes GetCurrentMode( )
		{
			return SharedObject.GetCurrentMode( );
		}

		public void Quit( )
		{
			SharedObject.Quit( );
		}

		public void PlayAudio( )
		{
			SharedObject.PlayAudio( );
		}

		public int GetSpectatingId( )
		{
			return SharedObject.GetSpectatingId( );
		}
	}
}
