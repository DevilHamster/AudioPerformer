namespace AudioPerformer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.stripSystem = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearPlayListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.varispeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPlayList = new System.Windows.Forms.Label();
            this.listboxPlaylist = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSpeedDown = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelVol = new System.Windows.Forms.Label();
            this.btnSpeedUp = new System.Windows.Forms.Button();
            this.lblSpeedMani = new System.Windows.Forms.Label();
            this.barVol = new AudioPerformer.EH_TrackBar();
            this.txtboxPlaying = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblProcess = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblArtists = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblSorts = new System.Windows.Forms.Label();
            this.barProcess = new AudioPerformer.EH_TrackBar();
            this.stripSystem.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // stripSystem
            // 
            this.stripSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stripSystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.stripSystem.Location = new System.Drawing.Point(0, 0);
            this.stripSystem.Name = "stripSystem";
            this.stripSystem.Size = new System.Drawing.Size(769, 24);
            this.stripSystem.TabIndex = 0;
            this.stripSystem.Text = "System";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.clearPlayListToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // clearPlayListToolStripMenuItem
            // 
            this.clearPlayListToolStripMenuItem.Name = "clearPlayListToolStripMenuItem";
            this.clearPlayListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearPlayListToolStripMenuItem.Text = "Clear PlayList";
            this.clearPlayListToolStripMenuItem.Click += new System.EventHandler(this.clearPlayListToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.varispeedToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // varispeedToolStripMenuItem
            // 
            this.varispeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.speedToolStripMenuItem,
            this.tempoToolStripMenuItem});
            this.varispeedToolStripMenuItem.Name = "varispeedToolStripMenuItem";
            this.varispeedToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.varispeedToolStripMenuItem.Text = "Varispeed";
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            this.speedToolStripMenuItem.Click += new System.EventHandler(this.speedToolStripMenuItem_Click);
            // 
            // tempoToolStripMenuItem
            // 
            this.tempoToolStripMenuItem.Name = "tempoToolStripMenuItem";
            this.tempoToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.tempoToolStripMenuItem.Text = "Tempo";
            this.tempoToolStripMenuItem.Click += new System.EventHandler(this.tempoToolStripMenuItem_Click);
            // 
            // labelPlayList
            // 
            this.labelPlayList.AutoSize = true;
            this.labelPlayList.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.labelPlayList.ForeColor = System.Drawing.Color.Silver;
            this.labelPlayList.Location = new System.Drawing.Point(12, 103);
            this.labelPlayList.Name = "labelPlayList";
            this.labelPlayList.Size = new System.Drawing.Size(50, 17);
            this.labelPlayList.TabIndex = 1;
            this.labelPlayList.Text = "Playlist:";
            // 
            // listboxPlaylist
            // 
            this.listboxPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listboxPlaylist.FormattingEnabled = true;
            this.listboxPlaylist.ItemHeight = 12;
            this.listboxPlaylist.Location = new System.Drawing.Point(12, 124);
            this.listboxPlaylist.Name = "listboxPlaylist";
            this.listboxPlaylist.Size = new System.Drawing.Size(529, 168);
            this.listboxPlaylist.TabIndex = 2;
            this.listboxPlaylist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listboxPlaylist_MouseDoubleClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrev, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlay, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(193, 28);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(147, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(43, 22);
            this.btnNext.TabIndex = 6;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNext_MouseDown);
            // 
            // btnPrev
            // 
            this.btnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.BackgroundImage")));
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(51, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(42, 22);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnPrev.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPrev_MouseDown);
            // 
            // btnMode
            // 
            this.btnMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.Image = global::AudioPerformer.Properties.Resources.modeButton1;
            this.btnMode.Location = new System.Drawing.Point(3, 3);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(42, 22);
            this.btnMode.TabIndex = 4;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click_1);
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = global::AudioPerformer.Properties.Resources.playButton;
            this.btnPlay.Location = new System.Drawing.Point(99, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(42, 22);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPlay_MouseDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.09174F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.8471F));
            this.tableLayoutPanel2.Controls.Add(this.btnSpeedDown, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelSpeed, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelVol, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSpeedUp, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblSpeedMani, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.barVol, 5, 0);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Arial Narrow", 11F);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(214, 36);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 28);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnSpeedDown
            // 
            this.btnSpeedDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSpeedDown.BackgroundImage")));
            this.btnSpeedDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpeedDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpeedDown.FlatAppearance.BorderSize = 0;
            this.btnSpeedDown.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSpeedDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeedDown.Location = new System.Drawing.Point(61, 3);
            this.btnSpeedDown.Name = "btnSpeedDown";
            this.btnSpeedDown.Size = new System.Drawing.Size(13, 22);
            this.btnSpeedDown.TabIndex = 4;
            this.btnSpeedDown.UseVisualStyleBackColor = true;
            this.btnSpeedDown.Click += new System.EventHandler(this.btnSpeedDown_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.labelSpeed.Location = new System.Drawing.Point(7, 5);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(43, 17);
            this.labelSpeed.TabIndex = 0;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelVol
            // 
            this.labelVol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVol.AutoSize = true;
            this.labelVol.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.labelVol.Location = new System.Drawing.Point(134, 5);
            this.labelVol.Name = "labelVol";
            this.labelVol.Size = new System.Drawing.Size(26, 17);
            this.labelVol.TabIndex = 0;
            this.labelVol.Text = "Vol:";
            // 
            // btnSpeedUp
            // 
            this.btnSpeedUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSpeedUp.BackgroundImage")));
            this.btnSpeedUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSpeedUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpeedUp.FlatAppearance.BorderSize = 0;
            this.btnSpeedUp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btnSpeedUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeedUp.Location = new System.Drawing.Point(115, 3);
            this.btnSpeedUp.Name = "btnSpeedUp";
            this.btnSpeedUp.Size = new System.Drawing.Size(13, 22);
            this.btnSpeedUp.TabIndex = 5;
            this.btnSpeedUp.UseVisualStyleBackColor = true;
            this.btnSpeedUp.Click += new System.EventHandler(this.btnSpeedUp_Click);
            // 
            // lblSpeedMani
            // 
            this.lblSpeedMani.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSpeedMani.AutoSize = true;
            this.lblSpeedMani.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.lblSpeedMani.Location = new System.Drawing.Point(80, 5);
            this.lblSpeedMani.Name = "lblSpeedMani";
            this.lblSpeedMani.Size = new System.Drawing.Size(29, 17);
            this.lblSpeedMani.TabIndex = 0;
            this.lblSpeedMani.Text = "1.00";
            // 
            // barVol
            // 
            this.barVol._BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.barVol._Max = 10;
            this.barVol._Min = 0;
            this.barVol._Radius = 2;
            this.barVol._Size = 6;
            this.barVol._SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.barVol._Value = 3;
            this.barVol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.barVol.IsRound = true;
            this.barVol.Location = new System.Drawing.Point(166, 11);
            this.barVol.Name = "barVol";
            this.barVol.Size = new System.Drawing.Size(158, 6);
            this.barVol.TabIndex = 6;
            this.barVol.Text = "eH_TrackBar1";
            this.barVol.ValueChanged += new AudioPerformer.EH_TrackBar.ValueChangedEventHandler(this.barVol_ValueChanged);
            // 
            // txtboxPlaying
            // 
            this.txtboxPlaying.BackColor = System.Drawing.SystemColors.Control;
            this.txtboxPlaying.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtboxPlaying.Location = new System.Drawing.Point(99, 106);
            this.txtboxPlaying.Name = "txtboxPlaying";
            this.txtboxPlaying.Size = new System.Drawing.Size(442, 14);
            this.txtboxPlaying.TabIndex = 5;
            this.txtboxPlaying.Text = "Playing:";
            this.txtboxPlaying.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "modeButton3.png");
            this.imageList1.Images.SetKeyName(1, "modeButton2.png");
            this.imageList1.Images.SetKeyName(2, "modeButton1.png");
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Location = new System.Drawing.Point(12, 81);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(107, 12);
            this.lblProcess.TabIndex = 6;
            this.lblProcess.Text = "00:00:00/00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblArtists
            // 
            this.lblArtists.AutoSize = true;
            this.lblArtists.Location = new System.Drawing.Point(557, 239);
            this.lblArtists.Name = "lblArtists";
            this.lblArtists.Size = new System.Drawing.Size(53, 12);
            this.lblArtists.TabIndex = 10;
            this.lblArtists.Text = "Artist: ";
            // 
            // picBox
            // 
            this.picBox.Image = global::AudioPerformer.Properties.Resources.disc;
            this.picBox.Location = new System.Drawing.Point(557, 36);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(200, 200);
            this.picBox.TabIndex = 9;
            this.picBox.TabStop = false;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(557, 259);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(41, 12);
            this.lblAlbum.TabIndex = 10;
            this.lblAlbum.Text = "Album:";
            // 
            // lblSorts
            // 
            this.lblSorts.AutoSize = true;
            this.lblSorts.Location = new System.Drawing.Point(557, 279);
            this.lblSorts.Name = "lblSorts";
            this.lblSorts.Size = new System.Drawing.Size(41, 12);
            this.lblSorts.TabIndex = 10;
            this.lblSorts.Text = "Sorts:";
            // 
            // barProcess
            // 
            this.barProcess._BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.barProcess._Max = 10;
            this.barProcess._Min = 0;
            this.barProcess._Radius = 2;
            this.barProcess._Size = 7;
            this.barProcess._SliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.barProcess._Value = 0;
            this.barProcess.IsRound = true;
            this.barProcess.Location = new System.Drawing.Point(139, 83);
            this.barProcess.Name = "barProcess";
            this.barProcess.Size = new System.Drawing.Size(402, 7);
            this.barProcess.TabIndex = 7;
            this.barProcess.Text = "eH_TrackBar1";
            this.barProcess.ValueChanged += new AudioPerformer.EH_TrackBar.ValueChangedEventHandler(this.barProcess_ValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 303);
            this.Controls.Add(this.lblSorts);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.lblArtists);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.barProcess);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.txtboxPlaying);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listboxPlaylist);
            this.Controls.Add(this.labelPlayList);
            this.Controls.Add(this.stripSystem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.stripSystem;
            this.Name = "frmMain";
            this.Text = " AudioPerformer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.stripSystem.ResumeLayout(false);
            this.stripSystem.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip stripSystem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearPlayListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label labelPlayList;
        private System.Windows.Forms.ListBox listboxPlaylist;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelVol;
        private System.Windows.Forms.Label lblSpeedMani;
        private System.Windows.Forms.Button btnSpeedDown;
        private System.Windows.Forms.Button btnSpeedUp;
        private System.Windows.Forms.TextBox txtboxPlaying;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.Timer timer1;
        private EH_TrackBar barProcess;
        private EH_TrackBar barVol;
        private System.Windows.Forms.ToolStripMenuItem varispeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempoToolStripMenuItem;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblArtists;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblSorts;
    }
}

