using osu_meme.osu;
using System;
using System.Windows.Forms;

namespace osu_meme
{
	public partial class Form1 : Form
	{
		Game OsuGame;

		public Form1( )
		{
			InitializeComponent( );

			OsuGame = new Game( );
			OsuGame.ReadGameDatabase( );

			var timer = new Timer( );
			timer.Tick += Timer_Tick;
			timer.Interval = 5;
			timer.Start( );
		}

		private void Timer_Tick( object sender, EventArgs e )
		{
			label1.Text = $"{OsuGame.DumpData( )}\n\n{OsuGame.GetPlayingBeatmap( ).DumpData( )}";
		}
	}
}
