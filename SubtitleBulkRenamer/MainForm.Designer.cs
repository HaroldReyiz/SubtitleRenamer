namespace SubtitleBulkRenamer 
{ 
    partial class MainForm 
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.DragFileLabel = new System.Windows.Forms.Label();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.MainTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Filter = "SRT & SUB files| *.srt; *.sub";
			this.OpenFileDialog.Multiselect = true;
			this.OpenFileDialog.SupportMultiDottedExtensions = true;
			// 
			// MainTableLayoutPanel
			// 
			this.MainTableLayoutPanel.ColumnCount = 1;
			this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainTableLayoutPanel.Controls.Add(this.DragFileLabel, 0, 0);
			this.MainTableLayoutPanel.Controls.Add(this.BrowseButton, 0, 1);
			this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
			this.MainTableLayoutPanel.RowCount = 2;
			this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.8419F));
			this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.1581F));
			this.MainTableLayoutPanel.Size = new System.Drawing.Size(428, 339);
			this.MainTableLayoutPanel.TabIndex = 9;
			// 
			// DragFileLabel
			// 
			this.DragFileLabel.AllowDrop = true;
			this.DragFileLabel.AutoSize = true;
			this.DragFileLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DragFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DragFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.DragFileLabel.ForeColor = System.Drawing.Color.Yellow;
			this.DragFileLabel.Location = new System.Drawing.Point(3, 0);
			this.DragFileLabel.Name = "DragFileLabel";
			this.DragFileLabel.Size = new System.Drawing.Size(422, 270);
			this.DragFileLabel.TabIndex = 7;
			this.DragFileLabel.Text = "You can drag files here.";
			this.DragFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DragFileLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
			this.DragFileLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
			// 
			// BrowseButton
			// 
			this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowseButton.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
			this.BrowseButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
			this.BrowseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
			this.BrowseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
			this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.BrowseButton.ForeColor = System.Drawing.Color.Yellow;
			this.BrowseButton.Location = new System.Drawing.Point(3, 273);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(422, 63);
			this.BrowseButton.TabIndex = 6;
			this.BrowseButton.Text = "Or Browse...";
			this.BrowseButton.UseVisualStyleBackColor = false;
			this.BrowseButton.Click += new System.EventHandler(this.OnBrowseButtonClicked);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(428, 339);
			this.Controls.Add(this.MainTableLayoutPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "BulkSubtitleRenamer";
			this.MainTableLayoutPanel.ResumeLayout(false);
			this.MainTableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);

        } 
 
        #endregion 
 
        private System.Windows.Forms.OpenFileDialog OpenFileDialog; 
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel; 
        private System.Windows.Forms.Label DragFileLabel; 
        private System.Windows.Forms.Button BrowseButton; 
    } 
} 