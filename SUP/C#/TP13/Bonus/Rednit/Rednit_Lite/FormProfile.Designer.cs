using System.Drawing;
using System.Windows.Forms;

namespace Rednit_Lite
{
    partial class FormProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfile));
            this.Background = new System.Windows.Forms.PictureBox();
            this.HackButton = new System.Windows.Forms.Button();
            this.MatchButton = new System.Windows.Forms.Button();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.Firstname = new System.Windows.Forms.TextBox();
            this.Lastname = new System.Windows.Forms.TextBox();
            this.Age = new System.Windows.Forms.TextBox();
            this.Animes = new System.Windows.Forms.CheckBox();
            this.Books = new System.Windows.Forms.CheckBox();
            this.Games = new System.Windows.Forms.CheckBox();
            this.Mangas = new System.Windows.Forms.CheckBox();
            this.Movies = new System.Windows.Forms.CheckBox();
            this.LoadPicture = new System.Windows.Forms.OpenFileDialog();
            this.Message = new System.Windows.Forms.Label();
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            this.defaultPicture = new System.Windows.Forms.PictureBox();
            this.Login = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.BackColor = System.Drawing.Color.White;
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(497, 603);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // HackButton
            // 
            this.HackButton.BackColor = System.Drawing.Color.White;
            this.HackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HackButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.HackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HackButton.ForeColor = System.Drawing.Color.Red;
            this.HackButton.Location = new System.Drawing.Point(12, 0);
            this.HackButton.Name = "HackButton";
            this.HackButton.Size = new System.Drawing.Size(138, 80);
            this.HackButton.TabIndex = 1;
            this.HackButton.Text = "<  Hack";
            this.HackButton.UseVisualStyleBackColor = true;
            this.HackButton.Click += new System.EventHandler(this.HackButton_Click);
            // 
            // MatchButton
            // 
            this.MatchButton.BackColor = System.Drawing.Color.White;
            this.MatchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MatchButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MatchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MatchButton.ForeColor = System.Drawing.Color.Red;
            this.MatchButton.Location = new System.Drawing.Point(347, 0);
            this.MatchButton.Name = "MatchButton";
            this.MatchButton.Size = new System.Drawing.Size(141, 80);
            this.MatchButton.TabIndex = 2;
            this.MatchButton.Text = "Match >";
            this.MatchButton.UseVisualStyleBackColor = false;
            this.MatchButton.Click += new System.EventHandler(this.MatchButton_Click);
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Picture.Location = new System.Drawing.Point(12, 117);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(211, 230);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 3;
            this.Picture.TabStop = false;
            this.Picture.Click += new System.EventHandler(this.Picture_Click);
            // 
            // Description
            // 
            this.Description.AcceptsReturn = true;
            this.Description.BackColor = System.Drawing.Color.White;
            this.Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description.CausesValidation = false;
            this.Description.Cursor = System.Windows.Forms.Cursors.Default;
            this.Description.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(242, 151);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Description.Size = new System.Drawing.Size(246, 195);
            this.Description.TabIndex = 3;
            this.Description.Text = "Description";
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.White;
            this.Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.Lime;
            this.Save.Location = new System.Drawing.Point(250, 462);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(238, 126);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Firstname
            // 
            this.Firstname.BackColor = System.Drawing.Color.White;
            this.Firstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Firstname.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Firstname.Location = new System.Drawing.Point(12, 352);
            this.Firstname.Name = "Firstname";
            this.Firstname.Size = new System.Drawing.Size(476, 29);
            this.Firstname.TabIndex = 4;
            this.Firstname.Text = "Firstname";
            // 
            // Lastname
            // 
            this.Lastname.BackColor = System.Drawing.Color.White;
            this.Lastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lastname.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lastname.Location = new System.Drawing.Point(12, 387);
            this.Lastname.Name = "Lastname";
            this.Lastname.Size = new System.Drawing.Size(476, 29);
            this.Lastname.TabIndex = 5;
            this.Lastname.Text = "Lastname";
            // 
            // Age
            // 
            this.Age.BackColor = System.Drawing.Color.White;
            this.Age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Age.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Age.Location = new System.Drawing.Point(12, 422);
            this.Age.Name = "Age";
            this.Age.Size = new System.Drawing.Size(138, 29);
            this.Age.TabIndex = 6;
            this.Age.Text = "Age";
            // 
            // Animes
            // 
            this.Animes.Appearance = System.Windows.Forms.Appearance.Button;
            this.Animes.AutoSize = true;
            this.Animes.BackColor = System.Drawing.Color.Transparent;
            this.Animes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Animes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Animes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Animes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Animes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Animes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Animes.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Animes.Location = new System.Drawing.Point(12, 475);
            this.Animes.Name = "Animes";
            this.Animes.Size = new System.Drawing.Size(129, 29);
            this.Animes.TabIndex = 7;
            this.Animes.Text = "Animes / Series";
            this.Animes.UseVisualStyleBackColor = false;
            // 
            // Books
            // 
            this.Books.Appearance = System.Windows.Forms.Appearance.Button;
            this.Books.AutoSize = true;
            this.Books.BackColor = System.Drawing.Color.Transparent;
            this.Books.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Books.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Books.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Books.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Books.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Books.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Books.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Books.Location = new System.Drawing.Point(162, 510);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(61, 29);
            this.Books.TabIndex = 10;
            this.Books.Text = "Books";
            this.Books.UseVisualStyleBackColor = false;
            // 
            // Games
            // 
            this.Games.Appearance = System.Windows.Forms.Appearance.Button;
            this.Games.AutoSize = true;
            this.Games.BackColor = System.Drawing.Color.Transparent;
            this.Games.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Games.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Games.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Games.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Games.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Games.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Games.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Games.Location = new System.Drawing.Point(156, 475);
            this.Games.Name = "Games";
            this.Games.Size = new System.Drawing.Size(67, 29);
            this.Games.TabIndex = 8;
            this.Games.Text = "Games";
            this.Games.UseVisualStyleBackColor = false;
            // 
            // Mangas
            // 
            this.Mangas.Appearance = System.Windows.Forms.Appearance.Button;
            this.Mangas.AutoSize = true;
            this.Mangas.BackColor = System.Drawing.Color.Transparent;
            this.Mangas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Mangas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Mangas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Mangas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Mangas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Mangas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Mangas.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mangas.Location = new System.Drawing.Point(12, 510);
            this.Mangas.Name = "Mangas";
            this.Mangas.Size = new System.Drawing.Size(144, 29);
            this.Mangas.TabIndex = 9;
            this.Mangas.Text = "Mangas / Comics";
            this.Mangas.UseVisualStyleBackColor = false;
            // 
            // Movies
            // 
            this.Movies.Appearance = System.Windows.Forms.Appearance.Button;
            this.Movies.AutoSize = true;
            this.Movies.BackColor = System.Drawing.Color.Transparent;
            this.Movies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Movies.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Movies.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.Movies.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Movies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Movies.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Movies.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Movies.Location = new System.Drawing.Point(12, 545);
            this.Movies.Name = "Movies";
            this.Movies.Size = new System.Drawing.Size(70, 29);
            this.Movies.TabIndex = 11;
            this.Movies.Text = "Movies";
            this.Movies.UseVisualStyleBackColor = false;
            // 
            // LoadPicture
            // 
            this.LoadPicture.FileName = "Picture";
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(12, 83);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 19);
            this.Message.TabIndex = 13;
            this.Message.TextChanged += new System.EventHandler(this.Message_TextChanged);
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // defaultPicture
            // 
            this.defaultPicture.Image = ((System.Drawing.Image)(resources.GetObject("defaultPicture.Image")));
            this.defaultPicture.Location = new System.Drawing.Point(400, 280);
            this.defaultPicture.Name = "defaultPicture";
            this.defaultPicture.Size = new System.Drawing.Size(100, 50);
            this.defaultPicture.TabIndex = 14;
            this.defaultPicture.TabStop = false;
            this.defaultPicture.Visible = false;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.Color.White;
            this.Login.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(237, 117);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(0, 24);
            this.Login.TabIndex = 15;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.defaultPicture);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Movies);
            this.Controls.Add(this.Mangas);
            this.Controls.Add(this.Games);
            this.Controls.Add(this.Books);
            this.Controls.Add(this.Animes);
            this.Controls.Add(this.Age);
            this.Controls.Add(this.Lastname);
            this.Controls.Add(this.Firstname);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.MatchButton);
            this.Controls.Add(this.HackButton);
            this.Controls.Add(this.Background);
            this.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "FormProfile";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProfile_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormProfile_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Button HackButton;
        private System.Windows.Forms.Button MatchButton;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox Firstname;
        private System.Windows.Forms.TextBox Lastname;
        private System.Windows.Forms.TextBox Age;
        private System.Windows.Forms.CheckBox Animes;
        private System.Windows.Forms.CheckBox Books;
        private System.Windows.Forms.CheckBox Games;
        private System.Windows.Forms.CheckBox Mangas;
        private System.Windows.Forms.CheckBox Movies;
        private System.Windows.Forms.OpenFileDialog LoadPicture;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer messageTimeout;
        private PictureBox defaultPicture;
        private Label Login;
    }
}