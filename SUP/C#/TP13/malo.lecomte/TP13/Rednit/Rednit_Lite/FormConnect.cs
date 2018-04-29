using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rednit_Lite
{
    public partial class FormConnect : Form
    {
        /// <summary>
        /// Constructor.
        /// Initializes the form.
        /// </summary>
        public FormConnect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Display an error message in label Message.
        /// </summary>
        /// <param name="message">The message to print.</param>
        /// <param name="error">If it is an error or a success, influences color.</param>
        private void DisplayMessage(string message, bool error)
        {
            Message.ForeColor = error ? Color.DarkOrange : Color.Lime;
            Message.Text = message;
            Message.Show();
        }
        /// <summary>
        /// Actions to do when connection button is clicked.
        /// Check if login is not empty.
        /// Send a connection request to server.
        /// If no error occured, save the login and go to next form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                DisplayMessage("Error: Login cannot be empty.", true);
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(Password.Text))
                    Password.Text = string.Empty;
                if (Network.ConnectAccount(Login.Text, Password.Text))
                {
                    Data.Login = Login.Text;
                    Data.NextForm = "Match";
                    Close();
                }
                else
                    DisplayMessage("Error: Could not authenticate.", true);
            }
            catch (Exception ex)
            {
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Actions to do when account creation button is clicked.
        /// Check if login is not empty.
        /// Send a creation request to server with the login and password.
        /// If no error occured, tells the success.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (Login.Text.Equals(string.Empty))
            {
                DisplayMessage("Error: Login cannot be empty.", true);
                return;
            }
            try
            {
                if (Network.CreateAccount(Login.Text, Password.Text))
                    DisplayMessage("Success: Account successfully created.", false);
                else
                    DisplayMessage("Error: Could not create account.", true);
            }
            catch (Exception ex)
            {
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Actions to do when the text of the Message label is changed.
        /// Restart the timer messageTimeout.
        /// Once the timer ends, hide the Message label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Message_TextChanged(object sender, EventArgs e)
        {
            messageTimeout.Tick += (sender2, e2) =>
            {
                Message.Hide();
                messageTimeout.Stop();
            };
            messageTimeout.Start();
        }

        /// <summary>
        /// Actions to do when closing the form.
        /// Exit the application if asked.
        /// Else, go to the next form, hide this one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Data.NextForm == string.Empty)
                Application.Exit();
            else
            {
                Hide();
                Data.Forms[Data.NextForm].Show();
            }
        }
    }
}
