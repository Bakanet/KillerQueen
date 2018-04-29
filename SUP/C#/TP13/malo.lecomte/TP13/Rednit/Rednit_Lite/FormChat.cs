using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rednit_Lite
{
    public partial class FormChat : Form
    {
        public FormChat()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Display an error message in label Message.
        /// The color is set to green if error is false (it is not an error).
        /// The color is set the orange if error is true (it is an error).
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendsButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Friends";
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
        /// Actions to do when closing the Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        private void FormChat_VisibleChanged(object sender, EventArgs e)
        {
            Conv.Text = string.Empty;
            SendMessage.Text = string.Empty;
            if (!Visible)
                return;
            Data.NextForm = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = Network.MessageFrom(Data.Friend);
                if (!string.IsNullOrEmpty(msg))
                    msg += '\n';
                Conv.Text += msg;
                if (string.IsNullOrEmpty(SendMessage.Text))
                    return;
                if (!Network.MessageTo(Data.Friend, SendMessage.Text))
                {
                    DisplayMessage("Error: An error occured while sending the message.", true);
                    return;
                }
                else
                {
                    Conv.Text += SendMessage.Text + "\n";
                    SendMessage.Text = string.Empty;
                }
            }
            catch (NotImplementedException)
            {
                DisplayMessage("Error: A required method is not implemented.", true);
                return;
            }
            catch (Exception ex)
            {
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
    }
}
