namespace SubtitleBulkRenamer
{
	partial class EpisodeNoSelectionForm
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
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.FileNameLabel = new System.Windows.Forms.Label();
			this.ButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.MainTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainTableLayoutPanel
			// 
			this.MainTableLayoutPanel.AutoSize = true;
			this.MainTableLayoutPanel.ColumnCount = 1;
			this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.MainTableLayoutPanel.Controls.Add(this.FileNameLabel, 0, 0);
			this.MainTableLayoutPanel.Controls.Add(this.ButtonsTableLayoutPanel, 0, 1);
			this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
			this.MainTableLayoutPanel.RowCount = 2;
			this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.MainTableLayoutPanel.Size = new System.Drawing.Size(270, 180);
			this.MainTableLayoutPanel.TabIndex = 10;
			// 
			// FileNameLabel
			// 
			this.FileNameLabel.AutoSize = true;
			this.FileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.FileNameLabel.ForeColor = System.Drawing.Color.Yellow;
			this.FileNameLabel.Location = new System.Drawing.Point(3, 0);
			this.FileNameLabel.Name = "FileNameLabel";
			this.FileNameLabel.Size = new System.Drawing.Size(264, 135);
			this.FileNameLabel.TabIndex = 7;
			this.FileNameLabel.Text = "<File name here>";
			this.FileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ButtonsTableLayoutPanel
			// 
			this.ButtonsTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.ButtonsTableLayoutPanel.ColumnCount = 1;
			this.ButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonsTableLayoutPanel.Location = new System.Drawing.Point(3, 138);
			this.ButtonsTableLayoutPanel.Name = "ButtonsTableLayoutPanel";
			this.ButtonsTableLayoutPanel.RowCount = 1;
			this.ButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.ButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
			this.ButtonsTableLayoutPanel.Size = new System.Drawing.Size(264, 39);
			this.ButtonsTableLayoutPanel.TabIndex = 8;
			// 
			// EpisodeNoSelectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(270, 180);
			this.Controls.Add(this.MainTableLayoutPanel);
			this.Name = "EpisodeNoSelectionForm";
			this.Text = "Manual Episode Number Selection";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
			this.MainTableLayoutPanel.ResumeLayout(false);
			this.MainTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
		private System.Windows.Forms.Label FileNameLabel;
		private System.Windows.Forms.TableLayoutPanel ButtonsTableLayoutPanel;
	}
}