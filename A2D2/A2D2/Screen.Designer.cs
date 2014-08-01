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
            this.button0 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.messageSent = new System.Windows.Forms.TextBox();
            this.messageReceived = new System.Windows.Forms.TextBox();
            this.buttonSay = new System.Windows.Forms.Button();
            this.buttonListen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(368, 397);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(50, 50);
            this.button0.TabIndex = 1;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click);
            // 
            // messageSent
            // 
            this.messageSent.Location = new System.Drawing.Point(84, 57);
            this.messageSent.MaxLength = 160;
            this.messageSent.Multiline = true;
            this.messageSent.Name = "messageSent";
            this.messageSent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageSent.Size = new System.Drawing.Size(470, 60);
            this.messageSent.TabIndex = 3;
            // 
            // messageReceived
            // 
            this.messageReceived.Location = new System.Drawing.Point(84, 123);
            this.messageReceived.MaxLength = 160;
            this.messageReceived.Multiline = true;
            this.messageReceived.Name = "messageReceived";
            this.messageReceived.ReadOnly = true;
            this.messageReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageReceived.Size = new System.Drawing.Size(470, 60);
            this.messageReceived.TabIndex = 4;
            // 
            // buttonSay
            // 
            this.buttonSay.Location = new System.Drawing.Point(226, 220);
            this.buttonSay.Name = "buttonSay";
            this.buttonSay.Size = new System.Drawing.Size(150, 50);
            this.buttonSay.TabIndex = 5;
            this.buttonSay.Text = "Say";
            this.buttonSay.UseVisualStyleBackColor = true;
            this.buttonSay.Click += new System.EventHandler(this.buttonSay_Click);
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(225, 276);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(150, 50);
            this.buttonListen.TabIndex = 6;
            this.buttonListen.Text = "Listen";
            this.buttonListen.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 478);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.buttonSay);
            this.Controls.Add(this.messageReceived);
            this.Controls.Add(this.messageSent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Screen";
            this.Text = "A2D2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox messageSent;
        private System.Windows.Forms.TextBox messageReceived;
        private System.Windows.Forms.Button buttonSay;
        private System.Windows.Forms.Button buttonListen;
        private System.Windows.Forms.Button button1;

    }
}

