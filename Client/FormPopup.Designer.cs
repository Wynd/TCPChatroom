namespace Client
{
    partial class formPopup
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
            this.labelError = new System.Windows.Forms.Label();
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
            this.labelTitleBar.Size = new System.Drawing.Size(284, 46);
            this.labelTitleBar.TabIndex = 12;
            this.labelTitleBar.Text = "  Popup";
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
            this.buttonQuit.Location = new System.Drawing.Point(235, -3);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(48, 43);
            this.buttonQuit.TabIndex = 13;
            this.buttonQuit.Text = "X";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelError
            // 
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.labelError.ForeColor = System.Drawing.Color.White;
            this.labelError.Location = new System.Drawing.Point(12, 78);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(257, 148);
            this.labelError.TabIndex = 19;
            this.labelError.Text = "Kick by ADMIN.           Reason : no reason";
            this.labelError.Visible = false;
            // 
            // formPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(281, 279);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.labelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formPopup";
            this.Load += new System.EventHandler(this.formPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleBar;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelError;
    }
}