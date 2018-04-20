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
    public partial class FormList : Form
    {
        public FormList()
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
        private void MatchButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Match";
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
        private void FormList_FormClosing(object sender, FormClosingEventArgs e)
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
        private void FormList_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            Data.NextForm = string.Empty;
            UpdateList();
        }

        private void UpdateList()
        {
            try
            {
                FriendList.Items.Clear();
                string[] list = Network.AskFriends();
                if (list == null)
                    DisplayMessage("Error: Could not get friends list, it may be empty.", true);
                else
                    FriendList.Items.AddRange(list);
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

        private void FriendList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = FriendList.SelectedIndex;
                if (index < 0 || index >= FriendList.Items.Count)
                {
                    DisplayMessage("Error: A valid friend must be selected.", true);
                    return;
                }
                Data.Friend = (string)FriendList.Items[index];

            }
            catch (Exception ex)
            {
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
                return;
            }
            Data.NextForm = "Chat";
            Close();
        }
    }
}
