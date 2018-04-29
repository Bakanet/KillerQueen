using System.Windows.Forms;

namespace Rednit_Lite
{
    partial class FormConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnect));
            this.messageTimeout = new System.Windows.Forms.Timer(this.components);
            this.CreateButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginText = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.Label();
            this.Background = new System.Windows.Forms.PictureBox();
            this.Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // messageTimeout
            // 
            this.messageTimeout.Interval = 5000;
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.Red;
            this.CreateButton.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.ForeColor = System.Drawing.Color.White;
            this.CreateButton.Location = new System.Drawing.Point(100, 500);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(300, 50);
            this.CreateButton.TabIndex = 4;
            this.CreateButton.Text = "Create account";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackColor = System.Drawing.Color.Red;
            this.ConnectButton.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.ForeColor = System.Drawing.Color.White;
            this.ConnectButton.Location = new System.Drawing.Point(100, 425);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(300, 50);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.Black;
            this.Login.Location = new System.Drawing.Point(100, 250);
            this.Login.MaxLength = 50;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(300, 35);
            this.Login.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(100, 350);
            this.Password.MaxLength = 50;
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(300, 35);
            this.Password.TabIndex = 2;
            this.Password.UseSystemPasswordChar = true;
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.BackColor = System.Drawing.Color.White;
            this.LoginText.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginText.ForeColor = System.Drawing.Color.Red;
            this.LoginText.Location = new System.Drawing.Point(100, 210);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(80, 27);
            this.LoginText.TabIndex = 5;
            this.LoginText.Text = "Login";
            // 
            // PasswordText
            // 
            this.PasswordText.AutoSize = true;
            this.PasswordText.BackColor = System.Drawing.Color.White;
            this.PasswordText.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordText.ForeColor = System.Drawing.Color.Red;
            this.PasswordText.Location = new System.Drawing.Point(100, 310);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PasswordText.Size = new System.Drawing.Size(131, 27);
            this.PasswordText.TabIndex = 6;
            this.PasswordText.Text = "Password";
            // 
            // Background
            // 
            this.Background.Image = ((System.Drawing.Image)(resources.GetObject("Background.Image")));
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(500, 603);
            this.Background.TabIndex = 7;
            this.Background.TabStop = false;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.White;
            this.Message.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Message.Location = new System.Drawing.Point(36, 175);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(0, 21);
            this.Message.TabIndex = 8;
            this.Message.TextChanged += new System.EventHandler(this.Message_TextChanged);
            // 
            // FormConnect
            // 
            this.AcceptButton = this.ConnectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.Background);
            this.Name = "FormConnect";
            this.Text = "Rednit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConnect_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.Label PasswordText;
        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Label Message;
        private System.Windows.Forms.Timer messageTimeout;
    }
}