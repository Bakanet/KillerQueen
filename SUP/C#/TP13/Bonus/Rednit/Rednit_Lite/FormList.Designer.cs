namespace Rednit_Lite
{
    partial class FormList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormList));
            this.Background = new System.Windows.Forms.PictureBox();
            this.MatchButton = new System.Windows.Forms.Button();
            this.NoneButton = new System.Windows.Forms.Button();
            this.FriendList = new System.Windows.Forms.ListBox();
            this.Message = new System.Windows.Forms.Label();
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(500, 601);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // MatchButton
            // 
            this.MatchButton.BackColor = System.Drawing.Color.White;
            this.MatchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MatchButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MatchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MatchButton.ForeColor = System.Drawing.Color.Red;
            this.MatchButton.Location = new System.Drawing.Point(0, 0);
            this.MatchButton.Name = "MatchButton";
            this.MatchButton.Size = new System.Drawing.Size(138, 80);
            this.MatchButton.TabIndex = 2;
            this.MatchButton.Text = "<  Match";
            this.MatchButton.UseVisualStyleBackColor = true;
            this.MatchButton.Click += new System.EventHandler(this.MatchButton_Click);
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
            this.NoneButton.Location = new System.Drawing.Point(362, 0);
            this.NoneButton.Name = "NoneButton";
            this.NoneButton.Size = new System.Drawing.Size(138, 80);
            this.NoneButton.TabIndex = 3;
            this.NoneButton.TabStop = false;
            this.NoneButton.UseVisualStyleBackColor = false;
            // 
            // FriendList
            // 
            this.FriendList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FriendList.FormattingEnabled = true;
            this.FriendList.ItemHeight = 27;
            this.FriendList.Location = new System.Drawing.Point(48, 155);
            this.FriendList.Name = "FriendList";
            this.FriendList.Size = new System.Drawing.Size(402, 405);
            this.FriendList.Sorted = true;
            this.FriendList.TabIndex = 5;
            this.FriendList.DoubleClick += new System.EventHandler(this.FriendList_DoubleClick);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(12, 95);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 19);
            this.Message.TabIndex = 11;
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // FormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.FriendList);
            this.Controls.Add(this.NoneButton);
            this.Controls.Add(this.MatchButton);
            this.Controls.Add(this.Background);
            this.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "FormList";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormList_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormList_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Button MatchButton;
        private System.Windows.Forms.Button NoneButton;
        private System.Windows.Forms.ListBox FriendList;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer messageTimeout;
    }
}