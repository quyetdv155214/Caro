namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelChessBoard = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btLan = new System.Windows.Forms.Button();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.playerMark = new System.Windows.Forms.PictureBox();
            this.pbCoolDown = new System.Windows.Forms.ProgressBar();
            this.playerName = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerMark)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChessBoard
            // 
            this.panelChessBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelChessBoard.Location = new System.Drawing.Point(3, 12);
            this.panelChessBoard.Name = "panelChessBoard";
            this.panelChessBoard.Size = new System.Drawing.Size(693, 568);
            this.panelChessBoard.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Tic_Tac_Toe_Game_red;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(704, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(304, 304);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btLan);
            this.panel2.Controls.Add(this.tbIP);
            this.panel2.Controls.Add(this.playerMark);
            this.panel2.Controls.Add(this.pbCoolDown);
            this.panel2.Controls.Add(this.playerName);
            this.panel2.Location = new System.Drawing.Point(704, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 215);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // btLan
            // 
            this.btLan.Location = new System.Drawing.Point(50, 164);
            this.btLan.Name = "btLan";
            this.btLan.Size = new System.Drawing.Size(75, 23);
            this.btLan.TabIndex = 4;
            this.btLan.Text = "Connect";
            this.btLan.UseVisualStyleBackColor = true;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(3, 121);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(172, 20);
            this.tbIP.TabIndex = 3;
            // 
            // playerMark
            // 
            this.playerMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerMark.Location = new System.Drawing.Point(194, 18);
            this.playerMark.Name = "playerMark";
            this.playerMark.Size = new System.Drawing.Size(100, 90);
            this.playerMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerMark.TabIndex = 2;
            this.playerMark.TabStop = false;
            // 
            // pbCoolDown
            // 
            this.pbCoolDown.Location = new System.Drawing.Point(3, 65);
            this.pbCoolDown.Name = "pbCoolDown";
            this.pbCoolDown.Size = new System.Drawing.Size(172, 23);
            this.pbCoolDown.TabIndex = 1;
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(3, 18);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(172, 20);
            this.playerName.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelChessBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game Caro";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChessBoard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLan;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.PictureBox playerMark;
        private System.Windows.Forms.ProgressBar pbCoolDown;
        private System.Windows.Forms.TextBox playerName;
    }
}

