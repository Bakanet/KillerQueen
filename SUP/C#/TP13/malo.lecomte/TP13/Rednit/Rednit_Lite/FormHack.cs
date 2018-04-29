using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rednit_Lite
{
    public partial class FormHack : Form
    {
        public FormHack()
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
            if (error)
                Message.ForeColor = Color.DarkOrange;
            else
                Message.ForeColor = Color.Lime;
            Message.Text = message;
            Message.Show();
        }
        /// <summary>
        /// Actions to do when profile button is clicked.
        /// Go to the profile form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Profile";
            Close();
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
        private void FormHack_FormClosing(object sender, FormClosingEventArgs e)
        {
            Loading.Hide();
            if (Data.NextForm == string.Empty)
                Application.Exit();
            else
            {
                Hide();
                Data.Forms[Data.NextForm].Activate();
                Data.Forms[Data.NextForm].Show();
            }
        }
        /// <summary>
        /// Actions to do when opening the Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHack_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            Data.NextForm = string.Empty;
        }
        /// <summary>
        /// Action to do when clicking Brute Force button.
        /// Start bruteforcing the password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BruteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Login.Text))
                {
                    DisplayMessage("Error: Login cannot be empty.", true);
                    return;
                }
                Loading.Show();
                Loading.Refresh();
                Password.Text = Network.HackBruteForce(Login.Text);
                Loading.Hide();
            }
            catch (NotImplementedException)
            {
                Loading.Hide();
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            catch (Exception ex)
            {
                Loading.Hide();
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Action to do when clicking Intelligent button.
        /// Start intelligent hack of the password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntelligentButton_Click(object sender, EventArgs e)
        {
            Loading.Hide();
            try
            {
                if (string.IsNullOrEmpty(Login.Text))
                {
                    DisplayMessage("Error: Login cannot be empty.", true);
                    return;
                }
                Password.Text = Network.HackIntelligent(Login.Text);
            }
            catch (NotImplementedException)
            {
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            catch (Exception ex)
            {
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
    }
}
