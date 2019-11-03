namespace CaroGame
{
    partial class CaroGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaroGame));
            this.pnl_BangDieuKhien = new System.Windows.Forms.Panel();
            this.btn_replay = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioO = new System.Windows.Forms.RadioButton();
            this.radioX = new System.Windows.Forms.RadioButton();
            this.btn_PvM = new System.Windows.Forms.Button();
            this.btn_PvP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_BanCo = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.luậtChơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lawMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xinĐiLạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLuotDi = new System.Windows.Forms.Label();
            this.pnl_BangDieuKhien.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_BangDieuKhien
            // 
            this.pnl_BangDieuKhien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.pnl_BangDieuKhien.Controls.Add(this.lblLuotDi);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_replay);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_huy);
            this.pnl_BangDieuKhien.Controls.Add(this.groupBox1);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_PvM);
            this.pnl_BangDieuKhien.Controls.Add(this.btn_PvP);
            this.pnl_BangDieuKhien.Controls.Add(this.label1);
            this.pnl_BangDieuKhien.Controls.Add(this.pictureBox1);
            this.pnl_BangDieuKhien.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_BangDieuKhien.Location = new System.Drawing.Point(0, 24);
            this.pnl_BangDieuKhien.Name = "pnl_BangDieuKhien";
            this.pnl_BangDieuKhien.Size = new System.Drawing.Size(206, 417);
            this.pnl_BangDieuKhien.TabIndex = 0;
            // 
            // btn_replay
            // 
            this.btn_replay.Location = new System.Drawing.Point(106, 382);
            this.btn_replay.Name = "btn_replay";
            this.btn_replay.Size = new System.Drawing.Size(75, 23);
            this.btn_replay.TabIndex = 3;
            this.btn_replay.Text = "Chơi Lại";
            this.btn_replay.UseVisualStyleBackColor = true;
            this.btn_replay.Click += new System.EventHandler(this.btn_replay_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(15, 382);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(75, 23);
            this.btn_huy.TabIndex = 4;
            this.btn_huy.Text = "Hủy Ván";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioO);
            this.groupBox1.Controls.Add(this.radioX);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bạn chọn:";
            // 
            // radioO
            // 
            this.radioO.AutoSize = true;
            this.radioO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioO.ForeColor = System.Drawing.Color.Red;
            this.radioO.Location = new System.Drawing.Point(37, 42);
            this.radioO.Name = "radioO";
            this.radioO.Size = new System.Drawing.Size(35, 19);
            this.radioO.TabIndex = 1;
            this.radioO.Text = "O";
            this.radioO.UseVisualStyleBackColor = true;
            // 
            // radioX
            // 
            this.radioX.AutoSize = true;
            this.radioX.Checked = true;
            this.radioX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioX.ForeColor = System.Drawing.Color.Green;
            this.radioX.Location = new System.Drawing.Point(37, 19);
            this.radioX.Name = "radioX";
            this.radioX.Size = new System.Drawing.Size(34, 19);
            this.radioX.TabIndex = 0;
            this.radioX.TabStop = true;
            this.radioX.Text = "X";
            this.radioX.UseVisualStyleBackColor = true;
            // 
            // btn_PvM
            // 
            this.btn_PvM.Location = new System.Drawing.Point(12, 338);
            this.btn_PvM.Name = "btn_PvM";
            this.btn_PvM.Size = new System.Drawing.Size(86, 23);
            this.btn_PvM.TabIndex = 2;
            this.btn_PvM.Text = "Người - Máy";
            this.btn_PvM.UseVisualStyleBackColor = true;
            this.btn_PvM.Click += new System.EventHandler(this.btn_PvM_Click);
            // 
            // btn_PvP
            // 
            this.btn_PvP.Location = new System.Drawing.Point(12, 309);
            this.btn_PvP.Name = "btn_PvP";
            this.btn_PvP.Size = new System.Drawing.Size(86, 23);
            this.btn_PvP.TabIndex = 1;
            this.btn_PvP.Text = "Người - Người";
            this.btn_PvP.UseVisualStyleBackColor = true;
            this.btn_PvP.Click += new System.EventHandler(this.btn_PvP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lượt đi của:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::CaroGame.Properties.Resources.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnl_BanCo
            // 
            this.pnl_BanCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_BanCo.Location = new System.Drawing.Point(206, 24);
            this.pnl_BanCo.Name = "pnl_BanCo";
            this.pnl_BanCo.Size = new System.Drawing.Size(418, 417);
            this.pnl_BanCo.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(188)))), ((int)(((byte)(196)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luậtChơiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // luậtChơiToolStripMenuItem
            // 
            this.luậtChơiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lawMenuItem,
            this.aboutMenuItem,
            this.xinĐiLạiToolStripMenuItem});
            this.luậtChơiToolStripMenuItem.Name = "luậtChơiToolStripMenuItem";
            this.luậtChơiToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.luậtChơiToolStripMenuItem.Text = "Option";
            // 
            // lawMenuItem
            // 
            this.lawMenuItem.Name = "lawMenuItem";
            this.lawMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lawMenuItem.Text = "Luật Chơi";
            this.lawMenuItem.Click += new System.EventHandler(this.lawMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // xinĐiLạiToolStripMenuItem
            // 
            this.xinĐiLạiToolStripMenuItem.Name = "xinĐiLạiToolStripMenuItem";
            this.xinĐiLạiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xinĐiLạiToolStripMenuItem.Text = "Xin đi lại";
            // 
            // lblLuotDi
            // 
            this.lblLuotDi.AutoSize = true;
            this.lblLuotDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuotDi.Location = new System.Drawing.Point(78, 260);
            this.lblLuotDi.Name = "lblLuotDi";
            this.lblLuotDi.Size = new System.Drawing.Size(0, 24);
            this.lblLuotDi.TabIndex = 5;
            // 
            // CaroGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pnl_BanCo);
            this.Controls.Add(this.pnl_BangDieuKhien);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "CaroGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Cờ Caro";
            this.Load += new System.EventHandler(this.CaroGame_Load);
            this.pnl_BangDieuKhien.ResumeLayout(false);
            this.pnl_BangDieuKhien.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_BangDieuKhien;
        private System.Windows.Forms.Button btn_PvM;
        private System.Windows.Forms.Button btn_PvP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem luậtChơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lawMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.Button btn_replay;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.ToolStripMenuItem xinĐiLạiToolStripMenuItem;
        public System.Windows.Forms.Panel pnl_BanCo;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioO;
        public System.Windows.Forms.RadioButton radioX;
        public System.Windows.Forms.Label lblLuotDi;
    }
}

