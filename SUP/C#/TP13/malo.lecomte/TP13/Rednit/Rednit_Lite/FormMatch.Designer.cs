using System.Drawing;

namespace Rednit_Lite
{
    partial class FormMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMatch));
            this.Background = new System.Windows.Forms.PictureBox();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.TalkButton = new System.Windows.Forms.Button();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Firstname = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.Lastname = new System.Windows.Forms.Label();
            this.Age = new System.Windows.Forms.Label();
            this.Dislike = new System.Windows.Forms.Button();
            this.Like = new System.Windows.Forms.Button();
            this.LoadPicture = new System.Windows.Forms.OpenFileDialog();
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            this.defaultPicture = new System.Windows.Forms.PictureBox();
            this.Message = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(497, 603);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.White;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProfileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.ForeColor = System.Drawing.Color.Red;
            this.ProfileButton.Location = new System.Drawing.Point(12, 0);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(138, 80);
            this.ProfileButton.TabIndex = 1;
            this.ProfileButton.Text = "<  Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // TalkButton
            // 
            this.TalkButton.BackColor = System.Drawing.Color.White;
            this.TalkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TalkButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TalkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TalkButton.ForeColor = System.Drawing.Color.Red;
            this.TalkButton.Location = new System.Drawing.Point(347, 0);
            this.TalkButton.Name = "TalkButton";
            this.TalkButton.Size = new System.Drawing.Size(141, 80);
            this.TalkButton.TabIndex = 2;
            this.TalkButton.Text = "Friends >";
            this.TalkButton.UseVisualStyleBackColor = false;
            this.TalkButton.Click += new System.EventHandler(this.TalkButton_Click);
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.Location = new System.Drawing.Point(12, 120);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(234, 260);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 3;
            this.Picture.TabStop = false;
            // 
            // Firstname
            // 
            this.Firstname.AutoSize = true;
            this.Firstname.BackColor = System.Drawing.Color.White;
            this.Firstname.Font = new System.Drawing.Font("Calisto MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Firstname.Location = new System.Drawing.Point(12, 392);
            this.Firstname.Name = "Firstname";
            this.Firstname.Size = new System.Drawing.Size(0, 24);
            this.Firstname.TabIndex = 4;
            // 
            // Description
            // 
            this.Description.AcceptsReturn = true;
            this.Description.BackColor = System.Drawing.Color.White;
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description.CausesValidation = false;
            this.Description.Cursor = System.Windows.Forms.Cursors.Default;
            this.Description.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(252, 150);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description.Size = new System.Drawing.Size(236, 230);
            this.Description.TabIndex = 3;
            this.Description.TabStop = false;
            // 
            // Lastname
            // 
            this.Lastname.AutoSize = true;
            this.Lastname.BackColor = System.Drawing.Color.White;
            this.Lastname.Font = new System.Drawing.Font("Calisto MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lastname.Location = new System.Drawing.Point(12, 423);
            this.Lastname.Name = "Lastname";
            this.Lastname.Size = new System.Drawing.Size(0, 24);
            this.Lastname.TabIndex = 5;
            // 
            // Age
            // 
            this.Age.AutoSize = true;
            this.Age.BackColor = System.Drawing.Color.White;
            this.Age.Font = new System.Drawing.Font("Calisto MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Age.Location = new System.Drawing.Point(12, 454);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(0, 24);
            this.Age.TabIndex = 6;
            // 
            // Dislike
            // 
            this.Dislike.BackColor = System.Drawing.Color.White;
            this.Dislike.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Dislike.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Dislike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dislike.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dislike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Dislike.Location = new System.Drawing.Point(16, 481);
            this.Dislike.Name = "Dislike";
            this.Dislike.Size = new System.Drawing.Size(230, 107);
            this.Dislike.TabIndex = 4;
            this.Dislike.Text = "Dislike";
            this.Dislike.UseVisualStyleBackColor = true;
            this.Dislike.Click += new System.EventHandler(this.Dislike_Click);
            // 
            // Like
            // 
            this.Like.BackColor = System.Drawing.Color.White;
            this.Like.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Like.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Like.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Like.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Like.ForeColor = System.Drawing.Color.Lime;
            this.Like.Location = new System.Drawing.Point(263, 481);
            this.Like.Name = "Like";
            this.Like.Size = new System.Drawing.Size(225, 107);
            this.Like.TabIndex = 5;
            this.Like.Text = "Like";
            this.Like.UseVisualStyleBackColor = true;
            this.Like.Click += new System.EventHandler(this.Like_Click);
            // 
            // LoadPicture
            // 
            this.LoadPicture.FileName = "Picture";
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // defaultPicture
            // 
            this.defaultPicture.Image = ((System.Drawing.Image)(resources.GetObject("defaultPicture.Image")));
            this.defaultPicture.InitialImage = null;
            this.defaultPicture.Location = new System.Drawing.Point(397, 386);
            this.defaultPicture.Name = "defaultPicture";
            this.defaultPicture.Size = new System.Drawing.Size(100, 50);
            this.defaultPicture.TabIndex = 9;
            this.defaultPicture.TabStop = false;
            this.defaultPicture.Visible = false;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(8, 83);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 19);
            this.Message.TabIndex = 10;
            this.Message.TextChanged += new System.EventHandler(this.Message_TextChanged);
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(252, 120);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(64, 21);
            this.Login.TabIndex = 11;
            this.Login.Text = "Login";
            // 
            // FormMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.defaultPicture);
            this.Controls.Add(this.Like);
            this.Controls.Add(this.Dislike);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.Lastname);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Firstname);
            this.Controls.Add(this.TalkButton);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.Background);
            this.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "FormMatch";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMatch_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormMatch_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button TalkButton;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.Label Firstname;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label Lastname;
        private System.Windows.Forms.Label Age;
        private System.Windows.Forms.Button Dislike;
        private System.Windows.Forms.OpenFileDialog LoadPicture;
        private System.Windows.Forms.Button Like;
        private System.Windows.Forms.Timer messageTimeout;
        private System.Windows.Forms.PictureBox defaultPicture;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Label Login;
    }
}