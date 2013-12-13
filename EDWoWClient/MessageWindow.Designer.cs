namespace EDWoWClient
{
    partial class MessageWindow
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSay = new System.Windows.Forms.TabPage();
            this.richTextBoxSendSay = new System.Windows.Forms.RichTextBox();
            this.richTextBoxReceiveSay = new System.Windows.Forms.RichTextBox();
            this.tabPageYell = new System.Windows.Forms.TabPage();
            this.richTextBoxSendYell = new System.Windows.Forms.RichTextBox();
            this.richTextBoxReceiveYell = new System.Windows.Forms.RichTextBox();
            this.tabPageTextEmote = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveTextEmote = new System.Windows.Forms.RichTextBox();
            this.tabPageChannel = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveChannel = new System.Windows.Forms.RichTextBox();
            this.tabPageSystem = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveSystemMsg = new System.Windows.Forms.RichTextBox();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveInfo = new System.Windows.Forms.RichTextBox();
            this.tabPageWarning = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveWarning = new System.Windows.Forms.RichTextBox();
            this.tabPageError = new System.Windows.Forms.TabPage();
            this.richTextBoxReceiveError = new System.Windows.Forms.RichTextBox();
            this.MessagingTheme = new GGenTheme();
            this.closeBtn = new GButton();
            this.minBtn = new GButton();
            this.tabControl.SuspendLayout();
            this.tabPageSay.SuspendLayout();
            this.tabPageYell.SuspendLayout();
            this.tabPageTextEmote.SuspendLayout();
            this.tabPageChannel.SuspendLayout();
            this.tabPageSystem.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageWarning.SuspendLayout();
            this.tabPageError.SuspendLayout();
            this.MessagingTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSay);
            this.tabControl.Controls.Add(this.tabPageYell);
            this.tabControl.Controls.Add(this.tabPageTextEmote);
            this.tabControl.Controls.Add(this.tabPageChannel);
            this.tabControl.Controls.Add(this.tabPageSystem);
            this.tabControl.Controls.Add(this.tabPageInfo);
            this.tabControl.Controls.Add(this.tabPageWarning);
            this.tabControl.Controls.Add(this.tabPageError);
            this.tabControl.Location = new System.Drawing.Point(0, 33);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(705, 386);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSay
            // 
            this.tabPageSay.Controls.Add(this.richTextBoxSendSay);
            this.tabPageSay.Controls.Add(this.richTextBoxReceiveSay);
            this.tabPageSay.Location = new System.Drawing.Point(4, 22);
            this.tabPageSay.Name = "tabPageSay";
            this.tabPageSay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSay.Size = new System.Drawing.Size(697, 360);
            this.tabPageSay.TabIndex = 0;
            this.tabPageSay.Text = "Say";
            this.tabPageSay.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSendSay
            // 
            this.richTextBoxSendSay.Location = new System.Drawing.Point(0, 303);
            this.richTextBoxSendSay.Name = "richTextBoxSendSay";
            this.richTextBoxSendSay.Size = new System.Drawing.Size(697, 57);
            this.richTextBoxSendSay.TabIndex = 1;
            this.richTextBoxSendSay.Text = "Send Msg..";
            this.richTextBoxSendSay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxSendSay_KeyDown);
            // 
            // richTextBoxReceiveSay
            // 
            this.richTextBoxReceiveSay.BackColor = System.Drawing.Color.Gray;
            this.richTextBoxReceiveSay.ForeColor = System.Drawing.Color.White;
            this.richTextBoxReceiveSay.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveSay.Name = "richTextBoxReceiveSay";
            this.richTextBoxReceiveSay.Size = new System.Drawing.Size(697, 297);
            this.richTextBoxReceiveSay.TabIndex = 0;
            this.richTextBoxReceiveSay.Text = "";
            // 
            // tabPageYell
            // 
            this.tabPageYell.Controls.Add(this.richTextBoxSendYell);
            this.tabPageYell.Controls.Add(this.richTextBoxReceiveYell);
            this.tabPageYell.Location = new System.Drawing.Point(4, 22);
            this.tabPageYell.Name = "tabPageYell";
            this.tabPageYell.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageYell.Size = new System.Drawing.Size(697, 360);
            this.tabPageYell.TabIndex = 1;
            this.tabPageYell.Text = "Yell";
            this.tabPageYell.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSendYell
            // 
            this.richTextBoxSendYell.Location = new System.Drawing.Point(-1, 300);
            this.richTextBoxSendYell.Name = "richTextBoxSendYell";
            this.richTextBoxSendYell.Size = new System.Drawing.Size(697, 57);
            this.richTextBoxSendYell.TabIndex = 2;
            this.richTextBoxSendYell.Text = "Send Msg..";
            this.richTextBoxSendYell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxSendYell_KeyDown);
            // 
            // richTextBoxReceiveYell
            // 
            this.richTextBoxReceiveYell.BackColor = System.Drawing.Color.Gray;
            this.richTextBoxReceiveYell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.richTextBoxReceiveYell.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveYell.Name = "richTextBoxReceiveYell";
            this.richTextBoxReceiveYell.Size = new System.Drawing.Size(697, 294);
            this.richTextBoxReceiveYell.TabIndex = 1;
            this.richTextBoxReceiveYell.Text = "";
            // 
            // tabPageTextEmote
            // 
            this.tabPageTextEmote.Controls.Add(this.richTextBoxReceiveTextEmote);
            this.tabPageTextEmote.Location = new System.Drawing.Point(4, 22);
            this.tabPageTextEmote.Name = "tabPageTextEmote";
            this.tabPageTextEmote.Size = new System.Drawing.Size(697, 360);
            this.tabPageTextEmote.TabIndex = 2;
            this.tabPageTextEmote.Text = "TextEmote";
            this.tabPageTextEmote.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveTextEmote
            // 
            this.richTextBoxReceiveTextEmote.BackColor = System.Drawing.Color.Gray;
            this.richTextBoxReceiveTextEmote.ForeColor = System.Drawing.Color.DarkOrange;
            this.richTextBoxReceiveTextEmote.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveTextEmote.Name = "richTextBoxReceiveTextEmote";
            this.richTextBoxReceiveTextEmote.Size = new System.Drawing.Size(697, 283);
            this.richTextBoxReceiveTextEmote.TabIndex = 1;
            this.richTextBoxReceiveTextEmote.Text = "";
            // 
            // tabPageChannel
            // 
            this.tabPageChannel.Controls.Add(this.richTextBoxReceiveChannel);
            this.tabPageChannel.Location = new System.Drawing.Point(4, 22);
            this.tabPageChannel.Name = "tabPageChannel";
            this.tabPageChannel.Size = new System.Drawing.Size(697, 360);
            this.tabPageChannel.TabIndex = 3;
            this.tabPageChannel.Text = "Channel";
            this.tabPageChannel.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveChannel
            // 
            this.richTextBoxReceiveChannel.BackColor = System.Drawing.Color.Gray;
            this.richTextBoxReceiveChannel.ForeColor = System.Drawing.Color.Moccasin;
            this.richTextBoxReceiveChannel.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveChannel.Name = "richTextBoxReceiveChannel";
            this.richTextBoxReceiveChannel.Size = new System.Drawing.Size(697, 283);
            this.richTextBoxReceiveChannel.TabIndex = 1;
            this.richTextBoxReceiveChannel.Text = "";
            // 
            // tabPageSystem
            // 
            this.tabPageSystem.Controls.Add(this.richTextBoxReceiveSystemMsg);
            this.tabPageSystem.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystem.Name = "tabPageSystem";
            this.tabPageSystem.Size = new System.Drawing.Size(697, 360);
            this.tabPageSystem.TabIndex = 7;
            this.tabPageSystem.Text = "System";
            this.tabPageSystem.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveSystemMsg
            // 
            this.richTextBoxReceiveSystemMsg.BackColor = System.Drawing.Color.Gray;
            this.richTextBoxReceiveSystemMsg.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveSystemMsg.Name = "richTextBoxReceiveSystemMsg";
            this.richTextBoxReceiveSystemMsg.Size = new System.Drawing.Size(697, 360);
            this.richTextBoxReceiveSystemMsg.TabIndex = 1;
            this.richTextBoxReceiveSystemMsg.Text = "";
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.richTextBoxReceiveInfo);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Size = new System.Drawing.Size(697, 360);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveInfo
            // 
            this.richTextBoxReceiveInfo.BackColor = System.Drawing.Color.White;
            this.richTextBoxReceiveInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.richTextBoxReceiveInfo.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveInfo.Name = "richTextBoxReceiveInfo";
            this.richTextBoxReceiveInfo.Size = new System.Drawing.Size(697, 360);
            this.richTextBoxReceiveInfo.TabIndex = 1;
            this.richTextBoxReceiveInfo.Text = "";
            // 
            // tabPageWarning
            // 
            this.tabPageWarning.Controls.Add(this.richTextBoxReceiveWarning);
            this.tabPageWarning.Location = new System.Drawing.Point(4, 22);
            this.tabPageWarning.Name = "tabPageWarning";
            this.tabPageWarning.Size = new System.Drawing.Size(697, 360);
            this.tabPageWarning.TabIndex = 5;
            this.tabPageWarning.Text = "Warning";
            this.tabPageWarning.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveWarning
            // 
            this.richTextBoxReceiveWarning.BackColor = System.Drawing.Color.White;
            this.richTextBoxReceiveWarning.ForeColor = System.Drawing.Color.Orange;
            this.richTextBoxReceiveWarning.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveWarning.Name = "richTextBoxReceiveWarning";
            this.richTextBoxReceiveWarning.Size = new System.Drawing.Size(697, 360);
            this.richTextBoxReceiveWarning.TabIndex = 1;
            this.richTextBoxReceiveWarning.Text = "";
            // 
            // tabPageError
            // 
            this.tabPageError.Controls.Add(this.richTextBoxReceiveError);
            this.tabPageError.Location = new System.Drawing.Point(4, 22);
            this.tabPageError.Name = "tabPageError";
            this.tabPageError.Size = new System.Drawing.Size(697, 360);
            this.tabPageError.TabIndex = 6;
            this.tabPageError.Text = "Error";
            this.tabPageError.UseVisualStyleBackColor = true;
            // 
            // richTextBoxReceiveError
            // 
            this.richTextBoxReceiveError.BackColor = System.Drawing.Color.White;
            this.richTextBoxReceiveError.ForeColor = System.Drawing.Color.Red;
            this.richTextBoxReceiveError.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxReceiveError.Name = "richTextBoxReceiveError";
            this.richTextBoxReceiveError.Size = new System.Drawing.Size(697, 360);
            this.richTextBoxReceiveError.TabIndex = 1;
            this.richTextBoxReceiveError.Text = "";
            // 
            // MessagingTheme
            // 
            this.MessagingTheme.Controls.Add(this.closeBtn);
            this.MessagingTheme.Controls.Add(this.minBtn);
            this.MessagingTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagingTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MessagingTheme.Image = null;
            this.MessagingTheme.Location = new System.Drawing.Point(0, 0);
            this.MessagingTheme.MoveHeight = 28;
            this.MessagingTheme.Name = "MessagingTheme";
            this.MessagingTheme.Resizable = true;
            this.MessagingTheme.Size = new System.Drawing.Size(704, 420);
            this.MessagingTheme.TabIndex = 1;
            this.MessagingTheme.Text = "Messaging";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.closeBtn.Image = null;
            this.closeBtn.Location = new System.Drawing.Point(675, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(24, 23);
            this.closeBtn.TabIndex = 10;
            this.closeBtn.Text = "x";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            // 
            // minBtn
            // 
            this.minBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.minBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.minBtn.Image = null;
            this.minBtn.Location = new System.Drawing.Point(652, 4);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(24, 23);
            this.minBtn.TabIndex = 9;
            this.minBtn.Text = "-";
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            this.minBtn.MouseEnter += new System.EventHandler(this.minBtn_MouseEnter);
            this.minBtn.MouseLeave += new System.EventHandler(this.minBtn_MouseLeave);
            // 
            // MessageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 420);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MessagingTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Messaging";
            this.tabControl.ResumeLayout(false);
            this.tabPageSay.ResumeLayout(false);
            this.tabPageYell.ResumeLayout(false);
            this.tabPageTextEmote.ResumeLayout(false);
            this.tabPageChannel.ResumeLayout(false);
            this.tabPageSystem.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageWarning.ResumeLayout(false);
            this.tabPageError.ResumeLayout(false);
            this.MessagingTheme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSay;
        private System.Windows.Forms.TabPage tabPageYell;
        private System.Windows.Forms.TabPage tabPageTextEmote;
        private System.Windows.Forms.TabPage tabPageChannel;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageWarning;
        private System.Windows.Forms.TabPage tabPageError;
        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveSay;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveYell;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveTextEmote;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveChannel;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveInfo;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveWarning;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveError;
        private System.Windows.Forms.RichTextBox richTextBoxSendSay;
        private GGenTheme MessagingTheme;
        private GButton closeBtn;
        private GButton minBtn;
        private System.Windows.Forms.TabPage tabPageSystem;
        public System.Windows.Forms.RichTextBox richTextBoxReceiveSystemMsg;
        private System.Windows.Forms.RichTextBox richTextBoxSendYell;
    }
}