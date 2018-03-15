namespace Client
{
    partial class formChat
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
            this.labelTitleBar = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.fieldInput = new System.Windows.Forms.TextBox();
            this.listBoxActiveChat = new System.Windows.Forms.ListBox();
            this.timerUpdateActiveChat = new System.Windows.Forms.Timer(this.components);
            this.listBoxOnline = new System.Windows.Forms.ListBox();
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
            this.labelTitleBar.Size = new System.Drawing.Size(745, 46);
            this.labelTitleBar.TabIndex = 12;
            this.labelTitleBar.Text = "  Chatroom";
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
            this.buttonQuit.Location = new System.Drawing.Point(696, -3);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(48, 43);
            this.buttonQuit.TabIndex = 13;
            this.buttonQuit.Text = "X";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonQuit.UseVisualStyleBackColor = false;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(27)))), ((int)(((byte)(58)))));
            this.buttonSend.FlatAppearance.BorderSize = 0;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.buttonSend.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSend.Location = new System.Drawing.Point(551, 515);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(73, 37);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // fieldInput
            // 
            this.fieldInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(154)))));
            this.fieldInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.fieldInput.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.fieldInput.Location = new System.Drawing.Point(12, 519);
            this.fieldInput.MaxLength = 256;
            this.fieldInput.Name = "fieldInput";
            this.fieldInput.Size = new System.Drawing.Size(533, 30);
            this.fieldInput.TabIndex = 1;
            this.fieldInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fieldInput_KeyPress);
            // 
            // listBoxActiveChat
            // 
            this.listBoxActiveChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(154)))));
            this.listBoxActiveChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxActiveChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.listBoxActiveChat.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.listBoxActiveChat.FormattingEnabled = true;
            this.listBoxActiveChat.HorizontalScrollbar = true;
            this.listBoxActiveChat.ItemHeight = 25;
            this.listBoxActiveChat.Location = new System.Drawing.Point(12, 59);
            this.listBoxActiveChat.Name = "listBoxActiveChat";
            this.listBoxActiveChat.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxActiveChat.Size = new System.Drawing.Size(533, 450);
            this.listBoxActiveChat.TabIndex = 18;
            // 
            // timerUpdateActiveChat
            // 
            this.timerUpdateActiveChat.Enabled = true;
            this.timerUpdateActiveChat.Interval = 10;
            this.timerUpdateActiveChat.Tick += new System.EventHandler(this.TimerUpdateActiveChat_Tick);
            // 
            // listBoxOnline
            // 
            this.listBoxOnline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(126)))), ((int)(((byte)(154)))));
            this.listBoxOnline.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.listBoxOnline.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.listBoxOnline.FormattingEnabled = true;
            this.listBoxOnline.ItemHeight = 25;
            this.listBoxOnline.Location = new System.Drawing.Point(551, 59);
            this.listBoxOnline.Name = "listBoxOnline";
            this.listBoxOnline.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxOnline.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxOnline.Size = new System.Drawing.Size(177, 450);
            this.listBoxOnline.TabIndex = 21;
            // 
            // formChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(740, 562);
            this.Controls.Add(this.listBoxOnline);
            this.Controls.Add(this.listBoxActiveChat);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.fieldInput);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.labelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formChat";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleBar;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox fieldInput;
        private System.Windows.Forms.ListBox listBoxActiveChat;
        private System.Windows.Forms.Timer timerUpdateActiveChat;
        private System.Windows.Forms.ListBox listBoxOnline;
    }
}