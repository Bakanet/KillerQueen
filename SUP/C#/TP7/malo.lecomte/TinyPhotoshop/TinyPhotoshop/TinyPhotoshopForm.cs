using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyPhotoshop
{
    public partial class TinyPhotoshopForm : Form
    {
        private string path = "";

        private Color selected_color = Color.Black;

        public TinyPhotoshopForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    path = OpenFile.FileName;
                    Image.Image = Bitmap.FromFile(OpenFile.FileName);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                    ((Bitmap) Image.Image).Save(SaveFile.FileName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Image_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (path != "")
                    Image.Image = System.Drawing.Image.FromFile(path);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void textEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Steganography.EncryptText((Bitmap) Image.Image, TextToEncrypt.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void TextToEncrypt_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void imageEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                    Image.Image = Steganography.EncryptImage((Bitmap) Image.Image,
                        (Bitmap) Bitmap.FromFile(OpenFile.FileName));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void textDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(Steganography.DecryptText((Bitmap) Image.Image));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void imageDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Steganography.DecryptImage((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Basics.Apply((Bitmap) Image.Image, Basics.Grey);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void binarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Basics.Apply((Bitmap) Image.Image, Basics.Binarize);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void binarizeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Basics.Apply((Bitmap) Image.Image, Basics.BinarizeColor);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = Basics.Apply((Bitmap) Image.Image, Basics.Negative);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void tinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Func<Color, Color> f = (Color c) => { return Basics.Tinter(c, showColor.BackColor, (int)transparentIn.Value); };
                Image.Image = Basics.Apply((Bitmap) Image.Image, f);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            //TODO Tinter
        }

        private void Geometry_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            try
            {
                x = Convert.ToInt32(Width.Text);
                y = Convert.ToInt32(Height.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
            Image.Image = TinyPhotoshop.Geometry.Resize((Bitmap) Image.Image, x, y);
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            try
            {
                x = Convert.ToInt32(Width.Text);
                y = Convert.ToInt32(Height.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
            Image.Image = TinyPhotoshop.Geometry.Shift((Bitmap) Image.Image, x, y);
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Geometry.SymmetryHorizontal((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Geometry.SymmetryVertical((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            try
            {
                x = Convert.ToInt32(Width.Text);
                y = Convert.ToInt32(Height.Text);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
            Image.Image = TinyPhotoshop.Geometry.SymmetryPoint((Bitmap) Image.Image, x, y);
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Geometry.RotationLeft((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Geometry.RotationRight((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Convolution_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void Average_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.Blur);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Gauss_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image =
                    TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.Gauss);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image =
                    TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.Sharpen);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.Blur);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void edgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void rehToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image =
                    TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.EdgeEnhance);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void detectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image =
                    TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.EdgeDetect);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image =
                    TinyPhotoshop.Convolution.Convolute((Bitmap) Image.Image, TinyPhotoshop.Convolution.Emboss);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Advanced_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void gothamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void kelvinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void lomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void nashvilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InstaFilter t = new InstaNashville();
                Image.Image = t.Process((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void toasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InstaFilter t = new InstaToaster();
                Image.Image = t.Process((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Auto_Contrast_Click(object sender, EventArgs e)
        {
            try
            {
                Image.Image = TinyPhotoshop.Auto.ConstrastStretch((Bitmap) Image.Image);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Mine_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO call mine
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void widthStripTextBox_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void Width_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void heightStripTextBox_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void Height_Click(object sender, EventArgs e)
        {
            //Nothing
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                showColor.BackColor = colorDialog.Color;
            }
        }
    }
}