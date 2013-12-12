namespace EDWoWClient
{
    partial class TicketForm
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
            this.listBoxTickets = new System.Windows.Forms.ListBox();
            this.TicketsTheme = new GGenTheme();
            this.closeBtn = new GButton();
            this.minBtn = new GButton();
            this.TicketsTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTickets
            // 
            this.listBoxTickets.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxTickets.FormattingEnabled = true;
            this.listBoxTickets.Location = new System.Drawing.Point(0, 33);
            this.listBoxTickets.Name = "listBoxTickets";
            this.listBoxTickets.Size = new System.Drawing.Size(680, 212);
            this.listBoxTickets.TabIndex = 0;
            // 
            // TicketsTheme
            // 
            this.TicketsTheme.Controls.Add(this.closeBtn);
            this.TicketsTheme.Controls.Add(this.minBtn);
            this.TicketsTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TicketsTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TicketsTheme.Image = null;
            this.TicketsTheme.Location = new System.Drawing.Point(0, 0);
            this.TicketsTheme.MoveHeight = 28;
            this.TicketsTheme.Name = "TicketsTheme";
            this.TicketsTheme.Resizable = true;
            this.TicketsTheme.Size = new System.Drawing.Size(683, 492);
            this.TicketsTheme.TabIndex = 1;
            this.TicketsTheme.Text = "Tickets";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.closeBtn.Image = null;
            this.closeBtn.Location = new System.Drawing.Point(655, 4);
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
            this.minBtn.Location = new System.Drawing.Point(632, 4);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(24, 23);
            this.minBtn.TabIndex = 9;
            this.minBtn.Text = "-";
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            this.minBtn.MouseEnter += new System.EventHandler(this.minBtn_MouseEnter);
            this.minBtn.MouseLeave += new System.EventHandler(this.minBtn_MouseLeave);
            // 
            // TicketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 492);
            this.Controls.Add(this.listBoxTickets);
            this.Controls.Add(this.TicketsTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TicketForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicketForm";
            this.Load += new System.EventHandler(this.TicketForm_Load);
            this.TicketsTheme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTickets;
        private GGenTheme TicketsTheme;
        private GButton closeBtn;
        private GButton minBtn;
    }
}