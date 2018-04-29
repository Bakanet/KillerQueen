namespace Rednit_Lite
{
    partial class FormHack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHack));
            this.Background = new System.Windows.Forms.PictureBox();
            this.HideTriangle = new System.Windows.Forms.PictureBox();
            this.Message = new System.Windows.Forms.Label();
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.BruteButton = new System.Windows.Forms.Button();
            this.IntelligentButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.Loading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideTriangle)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(482, 564);
            this.Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // HideTriangle
            // 
            this.HideTriangle.BackColor = System.Drawing.Color.White;
            this.HideTriangle.Location = new System.Drawing.Point(12, 0);
            this.HideTriangle.Name = "HideTriangle";
            this.HideTriangle.Size = new System.Drawing.Size(116, 83);
            this.HideTriangle.TabIndex = 1;
            this.HideTriangle.TabStop = false;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(12, 107);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 19);
            this.Message.TabIndex = 2;
            this.Message.Visible = false;
            this.Message.TextChanged += new System.EventHandler(this.Message_TextChanged);
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(62, 194);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(355, 41);
            this.Login.TabIndex = 3;
            this.Login.Text = "Login";
            // 
            // Password
            // 
            this.Password.Enabled = false;
            this.Password.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(62, 256);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(355, 41);
            this.Password.TabIndex = 4;
            // 
            // BruteButton
            // 
            this.BruteButton.BackColor = System.Drawing.Color.White;
            this.BruteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BruteButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BruteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BruteButton.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BruteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BruteButton.Location = new System.Drawing.Point(62, 340);
            this.BruteButton.Name = "BruteButton";
            this.BruteButton.Size = new System.Drawing.Size(355, 53);
            this.BruteButton.TabIndex = 5;
            this.BruteButton.Text = "Brute Force";
            this.BruteButton.UseVisualStyleBackColor = false;
            this.BruteButton.Click += new System.EventHandler(this.BruteButton_Click);
            // 
            // IntelligentButton
            // 
            this.IntelligentButton.BackColor = System.Drawing.Color.White;
            this.IntelligentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IntelligentButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.IntelligentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IntelligentButton.Font = new System.Drawing.Font("Cooper Black", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IntelligentButton.ForeColor = System.Drawing.Color.Lime;
            this.IntelligentButton.Location = new System.Drawing.Point(62, 414);
            this.IntelligentButton.Name = "IntelligentButton";
            this.IntelligentButton.Size = new System.Drawing.Size(355, 53);
            this.IntelligentButton.TabIndex = 6;
            this.IntelligentButton.Text = "Intelligent";
            this.IntelligentButton.UseVisualStyleBackColor = false;
            this.IntelligentButton.Click += new System.EventHandler(this.IntelligentButton_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.White;
            this.ProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ProfileButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.Red;
            this.ProfileButton.Location = new System.Drawing.Point(332, 0);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(140, 80);
            this.ProfileButton.TabIndex = 7;
            this.ProfileButton.Text = "Profile >";
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // Loading
            // 
            this.Loading.AutoSize = true;
            this.Loading.BackColor = System.Drawing.Color.White;
            this.Loading.Font = new System.Drawing.Font("Cooper Black", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loading.ForeColor = System.Drawing.Color.Goldenrod;
            this.Loading.Location = new System.Drawing.Point(13, 151);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(462, 17);
            this.Loading.TabIndex = 8;
            this.Loading.Text = "HACKING: Please wait a few seconds/minutes/hours/years.";
            this.Loading.Visible = false;
            // 
            // FormHack
            //
            this.AcceptButton = this.IntelligentButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.Loading);
            this.Controls.Add(this.ProfileButton);
            this.Controls.Add(this.IntelligentButton);
            this.Controls.Add(this.BruteButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.HideTriangle);
            this.Controls.Add(this.Background);
            this.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormHack";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHack_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormHack_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HideTriangle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.PictureBox HideTriangle;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer messageTimeout;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button BruteButton;
        private System.Windows.Forms.Button IntelligentButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Label Loading;
    }
}