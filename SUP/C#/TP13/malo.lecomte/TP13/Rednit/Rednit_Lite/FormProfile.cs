using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rednit_Lite
{
    public partial class FormProfile : Form
    {
        /// <summary>
        /// Constructor.
        /// Initializes the form.
        /// </summary>
        public FormProfile()
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
        /// Updates all the components of the user.
        /// </summary>
        private void UpdateData(UserData user)
        {
            Picture.Image = user.Picture == null ? (Image)defaultPicture.Image.Clone() : ConvertImage.ByteArrayToImage(user.Picture);
            Picture.Update();

            Login.Text = user.Login;
            Description.Text = user.Description == string.Empty ? "Description" : user.Description;
            Firstname.Text = user.Firstname == string.Empty ? "Firstname" : user.Firstname;
            Lastname.Text = user.Lastname == string.Empty ? "Lastname" : user.Lastname;
            Age.Text = user.Age < 0 ? "Age" : user.Age.ToString();
            Animes.Checked = user.AnimesSeries;
            Books.Checked = user.Books;
            Games.Checked = user.Games;
            Mangas.Checked = user.MangasComics;
            Movies.Checked = user.Movies;

        }
        /// <summary>
        /// Updates the user in Data.
        /// </summary>
        /// <returns></returns>
        private UserData UpdateUser()
        {
            if (!Int32.TryParse(Age.Text, out var age))
            {
                DisplayMessage("Error: Age must be a number.", true);
                return null;
            }
            if (age < 0 || age > 666)
            {
                DisplayMessage("Error: Age must be between 0 and 666.", true);
                return null;
            }

            byte[] picture = ConvertImage.ImageToByteArray(Picture.Image) == ConvertImage.ImageToByteArray(defaultPicture.Image) ? null : ConvertImage.ImageToByteArray((Image)Picture.Image.Clone());

            var user = new UserData
            {
                Login = Login.Text,
                Age = age,
                Firstname = Firstname.Text,
                Lastname = Lastname.Text,
                Description = Description.Text,
                Picture = picture,
                AnimesSeries = Animes.Checked,
                Books = Books.Checked,
                Games = Games.Checked,
                MangasComics = Mangas.Checked,
                Movies = Movies.Checked
            };
            UpdateData(user);
            return user;
        }
        /// <summary>
        /// Action to do when Hack button is clicked.
        /// Go to form hack.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HackButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Hack";
            Close();
        }
        /// <summary>
        /// Action to do when match button is clicked.
        /// Go to form match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MatchButton_Click(object sender, EventArgs e)
        {
            Data.NextForm = "Match";
            Close();
        }
        /// <summary>
        /// Action to do when Save button is clicked.
        /// Send the user data to server, call Network.SendData().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                var user = UpdateUser();
                if (user == null)
                    return;
                if(!Network.SendData(user))
                    DisplayMessage("Error: Could not send data.", true);
                else
                    DisplayMessage("Success: Profile saved.", false);
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
        /// <summary>
        /// Load the picture from computer's file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Picture_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoadPicture.ShowDialog() == DialogResult.OK)
                {
                    var image = Image.FromFile(LoadPicture.FileName);

                    double x = image.Width;
                    double y = image.Height;
                    if (x * y > 250000)
                    {
                        double n = Math.Sqrt(x) * Math.Sqrt(y) / 500.0d;
                        x = x / n;
                        y = y / n;
                    }

                    Picture.Image = new Bitmap(image, (int)x, (int)y);
                }
            }
            catch (NotImplementedException)
            {
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            catch (Exception)
            {
                DisplayMessage($"Error: Could not load image {LoadPicture.FileName}", true);
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
        /// Actions to do when form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProfile_FormClosing(object sender, FormClosingEventArgs e)
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
        /// Actions to do when form's visibility is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProfile_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;
            Data.NextForm = string.Empty;
            try
            {
                UserData user = Network.AskData(Data.Login);
                if (user == null)
                {
                    DisplayMessage("Error: Could not receive data.", true);
                    user = new UserData();
                }
                UpdateData(user);
            }
            catch (NotImplementedException)
            {
                var user = new UserData();
                UpdateData(user);
                DisplayMessage("Error: A required method is not implemented.", true);
            }
            catch (Exception ex)
            {
                var user = new UserData();
                UpdateData(user);
                DisplayMessage("Error: An error occured.", true);
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
    }
}
