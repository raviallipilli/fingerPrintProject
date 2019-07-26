using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace biometricFingerprints
{
    public partial class Form1 : Form
    {
        Bitmap image1, image2;
        public Form1()
        {
            InitializeComponent();
        }
        //uploading images from a open file dialog1
        private void button1_Click(object sender, EventArgs e)
        {//in order to use openfile dialog add system.io namespace
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFile.FileName;
                image1 = new Bitmap(openFile.FileName);
            }

        }
        //uploading the second image from open file dialog to compare
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openFile.FileName;
                image2 = new Bitmap(openFile.FileName);
            }


        }
        //now comparing both the uploaded images but the result is not saved to display
        private void button3_Click(object sender, EventArgs e)
        {
            bool compare = ImgComStr(image1, image2);
            if (compare==true)
            {
                MessageBox.Show("Match Found");
            }
            else
            {
                MessageBox.Show("Match Not Found");
            }
        }
        //to display the saved result create a new method for compating two images
        private bool ImgComStr(Bitmap image11, Bitmap image22)
        {
            //throw new NotImplementedException();

            //add a namespace system.drawing.imaging to use image format
            MemoryStream ms = new MemoryStream();
            image11.Save(ms, ImageFormat.Png);//image should be saved in png format
            string firstimage = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;//initial position will set to empty or zero
            image22.Save(ms, ImageFormat.Png);
            string secondimage = Convert.ToBase64String(ms.ToArray());
            if (firstimage.Equals(secondimage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
