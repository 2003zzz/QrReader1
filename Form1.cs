using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace QrReader1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap bitmap = encoder.Encode(text);
            pictureBox1.Image = bitmap;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName);
                textBox1.Text = "";
                MessageBox.Show("QR код успешно сохранён \nПуть к файлу: " + saveFileDialog.FileName.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadfile = new OpenFileDialog();
            if (loadfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = loadfile.FileName;
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            MessageBox.Show(decoder.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap)));
            textBox1.Text = "";
        }
    }
}
