using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubtitleBulkRenamer
{
	public partial class EpisodeNoSelectionForm : Form
	{
		private MainForm mainForm;

		public EpisodeNoSelectionForm( MainForm mainForm, string fileName, List< string > matchesList )
		{
			this.mainForm = mainForm;

			InitializeComponent();

			ButtonsTableLayoutPanel.ColumnCount = 0;
			ButtonsTableLayoutPanel.ColumnStyles.Clear();

			PrepareForm( fileName, matchesList );
		}

		private void PrepareForm( string fileName, List< string > matchesList )
		{
			FileNameLabel.Text = "What is the episode number of this file?\n" + fileName;

			foreach( string episodeNumberString in matchesList )
			{
				// Create a new button.
				Button button = new Button();

				button.Name = episodeNumberString;
				button.Text = episodeNumberString;

				button.AutoSize                          = true;
				button.BackColor                         = System.Drawing.Color.FromArgb( 64, 64, 64 );
				button.Dock                              = System.Windows.Forms.DockStyle.Fill;
				button.FlatAppearance.BorderColor        = System.Drawing.Color.Yellow;
				button.FlatAppearance.CheckedBackColor   = System.Drawing.Color.Black;
				button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
				button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
				button.FlatStyle                         = System.Windows.Forms.FlatStyle.Flat;
				button.Font                              = new System.Drawing.Font( "Microsoft Sans Serif", 10F );
				button.ForeColor                         = System.Drawing.Color.Yellow;
				button.UseVisualStyleBackColor           = false;
				button.Click                            += new System.EventHandler( this.OnBrowseButtonClicked );

				// Add a new column.
				ButtonsTableLayoutPanel.ColumnCount++;
				ButtonsTableLayoutPanel.Controls.Add( button );
			}

			// Resize all columns of ButtonsTableLayoutPanel so that every column has equal width.
			for( int controlIndex = 0 ; controlIndex < ButtonsTableLayoutPanel.Controls.Count ; controlIndex++ )
			{
				ButtonsTableLayoutPanel.ColumnStyles.Add( new ColumnStyle( SizeType.Percent,
					( float )ButtonsTableLayoutPanel.Size.Width / ButtonsTableLayoutPanel.ColumnCount ) );
			}
		}

		private void OnBrowseButtonClicked( object sender, EventArgs e )
		{
			mainForm.userSelection = Int32.Parse( ( ( Button )sender ).Text );
			
			this.Close();
		}

		private void OnFormClosed( object sender, FormClosedEventArgs e )
		{
			mainForm.Show();
		}
	}
}
