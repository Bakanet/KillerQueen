namespace Rednit_Lite
{
    partial class FormChat
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
        {}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FriendsButton = new System.Windows.Forms.Button();
            this.NoneButton = new System.Windows.Forms.Button();
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            this.Message = new System.Windows.Forms.Label();
            this.Conv = new System.Windows.Forms.RichTextBox();
            this.SendMessage = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(502, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FriendsButton
            // 
            this.FriendsButton.BackColor = System.Drawing.Color.White;
            this.FriendsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FriendsButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FriendsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FriendsButton.ForeColor = System.Drawing.Color.Red;
            this.FriendsButton.Location = new System.Drawing.Point(0, 0);
            this.FriendsButton.Name = "FriendsButton";
            this.FriendsButton.Size = new System.Drawing.Size(145, 80);
            this.FriendsButton.TabIndex = 3;
            this.FriendsButton.Text = "< Friends";
            this.FriendsButton.UseVisualStyleBackColor = true;
            this.FriendsButton.Click += new System.EventHandler(this.FriendsButton_Click);
            // 
            // NoneButton
            // 
            this.NoneButton.BackColor = System.Drawing.Color.White;
            this.NoneButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NoneButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.NoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.NoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.NoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoneButton.ForeColor = System.Drawing.Color.Red;
            this.NoneButton.Location = new System.Drawing.Point(349, 4);
            this.NoneButton.Name = "NoneButton";
            this.NoneButton.Size = new System.Drawing.Size(145, 80);
            this.NoneButton.TabIndex = 4;
            this.NoneButton.TabStop = false;
            this.NoneButton.UseVisualStyleBackColor = true;
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(12, 83);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 19);
            this.Message.TabIndex = 12;
            // 
            // Conv
            // 
            this.Conv.Location = new System.Drawing.Point(12, 114);
            this.Conv.Name = "Conv";
            this.Conv.Size = new System.Drawing.Size(476, 343);
            this.Conv.TabIndex = 13;
            this.Conv.Text = "";
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(12, 463);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(283, 110);
            this.SendMessage.TabIndex = 14;
            this.SendMessage.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.White;
            this.SendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SendButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Cooper Black", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.SendButton.Location = new System.Drawing.Point(301, 463);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(187, 110);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.Conv);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.NoneButton);
            this.Controls.Add(this.FriendsButton);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "FormChat";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormChat_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button FriendsButton;
        private System.Windows.Forms.Button NoneButton;
        private System.Windows.Forms.Timer messageTimeout;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.RichTextBox Conv;
        private System.Windows.Forms.RichTextBox SendMessage;
        private System.Windows.Forms.Button SendButton;
    }
}