namespace osu_meme
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
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.osuMemeTab = new System.Windows.Forms.TabPage();
			this.gameDataDumpTab = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.gameDataDumpTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.osuMemeTab);
			this.tabControl1.Controls.Add(this.gameDataDumpTab);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1246, 714);
			this.tabControl1.TabIndex = 1;
			// 
			// osuMemeTab
			// 
			this.osuMemeTab.Location = new System.Drawing.Point(4, 22);
			this.osuMemeTab.Name = "osuMemeTab";
			this.osuMemeTab.Padding = new System.Windows.Forms.Padding(3);
			this.osuMemeTab.Size = new System.Drawing.Size(1238, 688);
			this.osuMemeTab.TabIndex = 0;
			this.osuMemeTab.Text = "osu!meme";
			this.osuMemeTab.UseVisualStyleBackColor = true;
			// 
			// gameDataDumpTab
			// 
			this.gameDataDumpTab.Controls.Add(this.label1);
			this.gameDataDumpTab.Location = new System.Drawing.Point(4, 22);
			this.gameDataDumpTab.Name = "gameDataDumpTab";
			this.gameDataDumpTab.Padding = new System.Windows.Forms.Padding(3);
			this.gameDataDumpTab.Size = new System.Drawing.Size(1238, 688);
			this.gameDataDumpTab.TabIndex = 1;
			this.gameDataDumpTab.Text = "Raw Data";
			this.gameDataDumpTab.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1246, 714);
			this.Controls.Add(this.tabControl1);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.gameDataDumpTab.ResumeLayout(false);
			this.gameDataDumpTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage osuMemeTab;
		private System.Windows.Forms.TabPage gameDataDumpTab;
		private System.Windows.Forms.Label label1;
	}
}

