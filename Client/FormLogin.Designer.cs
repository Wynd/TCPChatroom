namespace Client
{
    partial class formLogin
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
            this.labelTitleBar = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.fieldIpToConnect = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.fieldLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelTitleBar
            // 
            this.labelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.labelTitleBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelTitleBar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitleBar.Location = new System.Drawing.Point(-1, -1);
            this.labelTitleBar.Name = "labelTitleBar";
            this.labelTitleBar.Size = new System.Drawing.Size(305, 46);
            this.labelTitleBar.TabIndex = 12;
            this.labelTitleBar.Text = "  Login";
            this.labelTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitleBar_MouseDown);
            // 
            // buttonQuit
            // 
            this.buttonQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(27)))), ((int)(((byte)(58)))));
            this.buttonQuit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonQuit.FlatAppearance.BorderSize = 0;
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonQuit.ForeColor = System.Drawing.Color.Red;
            this.buttonQuit.Location = new System.Drawing.Point(256, -3);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(48, 43);
            this.buttonQuit.TabIndex = 13;
            this.buttonQuit.Text = "X";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // fieldIpToConnect
            // 
            this.fieldIpToConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(154)))));
            this.fieldIpToConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldIpToConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fieldIpToConnect.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.fieldIpToConnect.Location = new System.Drawing.Point(57, 171);
            this.fieldIpToConnect.MaxLength = 30;
            this.fieldIpToConnect.Name = "fieldIpToConnect";
            this.fieldIpToConnect.Size = new System.Drawing.Size(190, 30);
            this.fieldIpToConnect.TabIndex = 16;
            this.fieldIpToConnect.Enter += new System.EventHandler(this.fieldIPToConnect_Enter);
            this.fieldIpToConnect.Leave += new System.EventHandler(this.fieldIPToConnect_Leave);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelVersion.Location = new System.Drawing.Point(254, 353);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(5);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(35, 17);
            this.labelVersion.TabIndex = 20;
            this.labelVersion.Text = "v2.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(27)))), ((int)(((byte)(58)))));
            this.buttonConnect.FlatAppearance.BorderSize = 0;
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonConnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonConnect.Location = new System.Drawing.Point(76, 234);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(141, 52);
            this.buttonConnect.TabIndex = 17;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // fieldLogin
            // 
            this.fieldLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(154)))));
            this.fieldLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fieldLogin.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.fieldLogin.Location = new System.Drawing.Point(57, 110);
            this.fieldLogin.MaxLength = 30;
            this.fieldLogin.Name = "fieldLogin";
            this.fieldLogin.Size = new System.Drawing.Size(190, 30);
            this.fieldLogin.TabIndex = 14;
            this.fieldLogin.Enter += new System.EventHandler(this.fieldLogin_Enter);
            this.fieldLogin.Leave += new System.EventHandler(this.fieldLogin_Leave);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(303, 384);
            this.Controls.Add(this.fieldIpToConnect);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.fieldLogin);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.labelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formLogin";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleBar;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.TextBox fieldIpToConnect;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox fieldLogin;
    }
}