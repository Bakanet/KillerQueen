using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rednit_Lite
{
    public partial class FormMatch : Form
    {
        /// <summary>
        /// Constructor.
        /// Initializes the form.
        /// </summary>
        public FormMatch()
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
        /// Go to the FormProfile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Profile";
            Close();
        }
        /// <summary>
        /// Got to the FormTalk.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TalkButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Friends";
            Close();
        }
        /// <summary>
        /// Send dislike to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dislike_Click(object sender, EventArgs e)
        {
            try
            {
                if (Network.SendLike(Login.Text, false))
                    DisplayMessage("Success: Dislike sent to server.", false);
                else
                    DisplayMessage("Error: Could not send dislike to the server.", true);
            }
            catch (NotImplementedException)
            {
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            UpdateMatch();
        }
        /// <summary>
        /// Send like to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Like_Click(object sender, EventArgs e)
        {
            try
            {
                if (Network.SendLike(Login.Text, true))
                    DisplayMessage("Success: Like sent to server.", false);
                else
                    DisplayMessage("Error: Could not send dislike to the server.", true);
            }
            catch (NotImplementedException)
            {
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            UpdateMatch();
        }
        /// <summary>
        /// Updates all the components of the user with param.
        /// </summary>
        /// <param name="user"></param>
        private void UpdateData(UserData user)
        {
            Picture.Image = user.Picture == null ? (Image)defaultPicture.Image.Clone() : ConvertImage.ByteArrayToImage(user.Picture);
            Picture.Update();

            Login.Text = user.Login;
            Description.Text = user.Description == string.Empty ? "Description" : user.Description;
            Firstname.Text = user.Firstname == string.Empty ? "Firstname" : user.Firstname;
            Lastname.Text = user.Lastname == string.Empty ? "Lastname" : user.Lastname;
            Age.Text = user.Age < 0 ? "Age" : user.Age.ToString();
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
        private void FormMatch_FormClosing(object sender, FormClosingEventArgs e)
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
        private void FormMatch_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            Data.NextForm = string.Empty;
            UpdateMatch();
        }
        /// <summary>
        /// Updates the data with a new user.
        /// Uses AskMatch();
        /// </summary>
        private void UpdateMatch()
        {
            try
            {
                UserData user = Network.AskMatch(Data.Login);
                if (user == null)
                {
                    DisplayMessage("Error: Could not find next match.", true);
                    UpdateData(Data.Default);
                }
                else
                    UpdateData(user);
            }
            catch (NotImplementedException)
            {
                UpdateData(Data.Default);
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            catch (Exception ex)
            {
                UpdateData(Data.Default);
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
    }
}
