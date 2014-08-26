namespace A2D2
{
    partial class Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screen));
            this.interactionPanel = new System.Windows.Forms.GroupBox();
            this.buttonSpeak = new System.Windows.Forms.Button();
            this.messageSent = new System.Windows.Forms.TextBox();
            this.buttonListen = new System.Windows.Forms.Button();
            this.messageReceived = new System.Windows.Forms.TextBox();
            this.messagePanel = new System.Windows.Forms.GroupBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.interactionPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // interactionPanel
            // 
            this.interactionPanel.Controls.Add(this.buttonSpeak);
            this.interactionPanel.Controls.Add(this.messageSent);
            this.interactionPanel.Controls.Add(this.buttonListen);
            this.interactionPanel.Controls.Add(this.messageReceived);
            this.interactionPanel.Location = new System.Drawing.Point(50, 49);
            this.interactionPanel.Name = "interactionPanel";
            this.interactionPanel.Size = new System.Drawing.Size(500, 237);
            this.interactionPanel.TabIndex = 7;
            this.interactionPanel.TabStop = false;
            this.interactionPanel.Text = "Interaction Panel";
            // 
            // buttonSpeak
            // 
            this.buttonSpeak.BackColor = System.Drawing.Color.White;
            this.buttonSpeak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSpeak.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSpeak.Image = global::A2D2.Properties.Resources.speak;
            this.buttonSpeak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSpeak.Location = new System.Drawing.Point(358, 30);
            this.buttonSpeak.Name = "buttonSpeak";
            this.buttonSpeak.Size = new System.Drawing.Size(120, 82);
            this.buttonSpeak.TabIndex = 5;
            this.buttonSpeak.Text = "Speak  ";
            this.buttonSpeak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSpeak.UseVisualStyleBackColor = false;
            this.buttonSpeak.Click += new System.EventHandler(this.buttonSay_Click);
            // 
            // messageSent
            // 
            this.messageSent.Location = new System.Drawing.Point(22, 29);
            this.messageSent.MaxLength = 160;
            this.messageSent.Multiline = true;
            this.messageSent.Name = "messageSent";
            this.messageSent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageSent.Size = new System.Drawing.Size(330, 84);
            this.messageSent.TabIndex = 4;
            this.messageSent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.messageSent_KeyPress);
            this.messageSent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.messageSent_KeyUp);
            // 
            // buttonListen
            // 
            this.buttonListen.BackColor = System.Drawing.Color.White;
            this.buttonListen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonListen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonListen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListen.Image = ((System.Drawing.Image)(resources.GetObject("buttonListen.Image")));
            this.buttonListen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonListen.Location = new System.Drawing.Point(358, 135);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(120, 82);
            this.buttonListen.TabIndex = 7;
            this.buttonListen.Text = "Listen  ";
            this.buttonListen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonListen.UseVisualStyleBackColor = false;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // messageReceived
            // 
            this.messageReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.messageReceived.Location = new System.Drawing.Point(22, 134);
            this.messageReceived.MaxLength = 160;
            this.messageReceived.Multiline = true;
            this.messageReceived.Name = "messageReceived";
            this.messageReceived.ReadOnly = true;
            this.messageReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageReceived.Size = new System.Drawing.Size(330, 84);
            this.messageReceived.TabIndex = 6;
            // 
            // messagePanel
            // 
            this.messagePanel.Controls.Add(this.messageTextBox);
            this.messagePanel.Location = new System.Drawing.Point(50, 292);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(500, 70);
            this.messagePanel.TabIndex = 8;
            this.messagePanel.TabStop = false;
            this.messagePanel.Text = "Alerts";
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.messageTextBox.ForeColor = System.Drawing.Color.Red;
            this.messageTextBox.Location = new System.Drawing.Point(22, 28);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.Size = new System.Drawing.Size(456, 20);
            this.messageTextBox.TabIndex = 8;
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(599, 411);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.interactionPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Screen";
            this.Text = "A2D2";
            this.interactionPanel.ResumeLayout(false);
            this.interactionPanel.PerformLayout();
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox interactionPanel;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.TextBox messageReceived;
        private System.Windows.Forms.GroupBox messagePanel;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button buttonSpeak;
        private System.Windows.Forms.TextBox messageSent;


    }
}

