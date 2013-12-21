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
            this.comboBoxTicketActions = new System.Windows.Forms.ComboBox();
            this.labelTicketActions = new System.Windows.Forms.Label();
            this.groupBoxPlayer = new System.Windows.Forms.GroupBox();
            this.comboBoxPlayerActions = new System.Windows.Forms.ComboBox();
            this.labelPlayerActions = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.lblPlayerGUID = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.textBoxPlayerGUID = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.textBoxTicketId = new System.Windows.Forms.TextBox();
            this.lblTicketId = new System.Windows.Forms.Label();
            this.closeBtn = new GButton();
            this.minBtn = new GButton();
            this.TicketsTheme.SuspendLayout();
            this.groupBoxPlayer.SuspendLayout();
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
            this.listBoxTickets.SelectedIndexChanged += new System.EventHandler(this.listBoxTickets_SelectedIndexChanged);
            // 
            // TicketsTheme
            // 
            this.TicketsTheme.Controls.Add(this.comboBoxTicketActions);
            this.TicketsTheme.Controls.Add(this.labelTicketActions);
            this.TicketsTheme.Controls.Add(this.groupBoxPlayer);
            this.TicketsTheme.Controls.Add(this.textBoxTicketId);
            this.TicketsTheme.Controls.Add(this.lblTicketId);
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
            // comboBoxTicketActions
            // 
            this.comboBoxTicketActions.FormattingEnabled = true;
            this.comboBoxTicketActions.Items.AddRange(new object[] {
            "None"});
            this.comboBoxTicketActions.Location = new System.Drawing.Point(95, 278);
            this.comboBoxTicketActions.Name = "comboBoxTicketActions";
            this.comboBoxTicketActions.Size = new System.Drawing.Size(95, 21);
            this.comboBoxTicketActions.Sorted = true;
            this.comboBoxTicketActions.TabIndex = 23;
            this.comboBoxTicketActions.Text = "None";
            // 
            // labelTicketActions
            // 
            this.labelTicketActions.AutoSize = true;
            this.labelTicketActions.BackColor = System.Drawing.Color.Transparent;
            this.labelTicketActions.ForeColor = System.Drawing.Color.White;
            this.labelTicketActions.Location = new System.Drawing.Point(104, 263);
            this.labelTicketActions.Name = "labelTicketActions";
            this.labelTicketActions.Size = new System.Drawing.Size(75, 13);
            this.labelTicketActions.TabIndex = 22;
            this.labelTicketActions.Text = "Ticket Actions";
            // 
            // groupBoxPlayer
            // 
            this.groupBoxPlayer.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPlayer.Controls.Add(this.comboBoxPlayerActions);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerActions);
            this.groupBoxPlayer.Controls.Add(this.textBoxMessage);
            this.groupBoxPlayer.Controls.Add(this.textBoxPlayerName);
            this.groupBoxPlayer.Controls.Add(this.lblPlayerGUID);
            this.groupBoxPlayer.Controls.Add(this.lblMessage);
            this.groupBoxPlayer.Controls.Add(this.textBoxPlayerGUID);
            this.groupBoxPlayer.Controls.Add(this.lblPlayerName);
            this.groupBoxPlayer.ForeColor = System.Drawing.Color.White;
            this.groupBoxPlayer.Location = new System.Drawing.Point(216, 251);
            this.groupBoxPlayer.Name = "groupBoxPlayer";
            this.groupBoxPlayer.Size = new System.Drawing.Size(464, 229);
            this.groupBoxPlayer.TabIndex = 21;
            this.groupBoxPlayer.TabStop = false;
            this.groupBoxPlayer.Text = "Player";
            // 
            // comboBoxPlayerActions
            // 
            this.comboBoxPlayerActions.FormattingEnabled = true;
            this.comboBoxPlayerActions.Items.AddRange(new object[] {
            "None"});
            this.comboBoxPlayerActions.Location = new System.Drawing.Point(211, 32);
            this.comboBoxPlayerActions.Name = "comboBoxPlayerActions";
            this.comboBoxPlayerActions.Size = new System.Drawing.Size(135, 21);
            this.comboBoxPlayerActions.Sorted = true;
            this.comboBoxPlayerActions.TabIndex = 25;
            this.comboBoxPlayerActions.Text = "None";
            // 
            // labelPlayerActions
            // 
            this.labelPlayerActions.AutoSize = true;
            this.labelPlayerActions.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerActions.ForeColor = System.Drawing.Color.White;
            this.labelPlayerActions.Location = new System.Drawing.Point(239, 17);
            this.labelPlayerActions.Name = "labelPlayerActions";
            this.labelPlayerActions.Size = new System.Drawing.Size(74, 13);
            this.labelPlayerActions.TabIndex = 24;
            this.labelPlayerActions.Text = "Player Actions";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Location = new System.Drawing.Point(6, 145);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(452, 78);
            this.textBoxMessage.TabIndex = 20;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Location = new System.Drawing.Point(27, 32);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(80, 20);
            this.textBoxPlayerName.TabIndex = 16;
            // 
            // lblPlayerGUID
            // 
            this.lblPlayerGUID.AutoSize = true;
            this.lblPlayerGUID.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerGUID.ForeColor = System.Drawing.Color.White;
            this.lblPlayerGUID.Location = new System.Drawing.Point(133, 17);
            this.lblPlayerGUID.Name = "lblPlayerGUID";
            this.lblPlayerGUID.Size = new System.Drawing.Size(34, 13);
            this.lblPlayerGUID.TabIndex = 13;
            this.lblPlayerGUID.Text = "GUID";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(208, 129);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 19;
            this.lblMessage.Text = "Message";
            // 
            // textBoxPlayerGUID
            // 
            this.textBoxPlayerGUID.Location = new System.Drawing.Point(127, 32);
            this.textBoxPlayerGUID.Name = "textBoxPlayerGUID";
            this.textBoxPlayerGUID.Size = new System.Drawing.Size(47, 20);
            this.textBoxPlayerGUID.TabIndex = 12;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayerName.ForeColor = System.Drawing.Color.White;
            this.lblPlayerName.Location = new System.Drawing.Point(49, 16);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerName.TabIndex = 15;
            this.lblPlayerName.Text = "Name";
            // 
            // textBoxTicketId
            // 
            this.textBoxTicketId.Location = new System.Drawing.Point(25, 279);
            this.textBoxTicketId.Name = "textBoxTicketId";
            this.textBoxTicketId.Size = new System.Drawing.Size(47, 20);
            this.textBoxTicketId.TabIndex = 14;
            // 
            // lblTicketId
            // 
            this.lblTicketId.AutoSize = true;
            this.lblTicketId.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketId.ForeColor = System.Drawing.Color.White;
            this.lblTicketId.Location = new System.Drawing.Point(25, 263);
            this.lblTicketId.Name = "lblTicketId";
            this.lblTicketId.Size = new System.Drawing.Size(48, 13);
            this.lblTicketId.TabIndex = 11;
            this.lblTicketId.Text = "TicketID";
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
            this.TicketsTheme.PerformLayout();
            this.groupBoxPlayer.ResumeLayout(false);
            this.groupBoxPlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTickets;
        private GGenTheme TicketsTheme;
        private GButton closeBtn;
        private GButton minBtn;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox textBoxTicketId;
        private System.Windows.Forms.Label lblPlayerGUID;
        private System.Windows.Forms.TextBox textBoxPlayerGUID;
        private System.Windows.Forms.Label lblTicketId;
        private System.Windows.Forms.GroupBox groupBoxPlayer;
        private System.Windows.Forms.Label labelTicketActions;
        private System.Windows.Forms.ComboBox comboBoxTicketActions;
        private System.Windows.Forms.ComboBox comboBoxPlayerActions;
        private System.Windows.Forms.Label labelPlayerActions;
    }
}