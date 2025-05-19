using System;
using System.Drawing;
using System.Windows.Forms;

namespace MirrorImageApp
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private Button btnLoad, btnMirror, btnSave;
        private Bitmap currentImage;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Дзеркальне зображення";
            this.Size = new Size(800, 600);

            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(10, 10),
                Size = new Size(760, 460),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(pictureBox);

            btnLoad = new Button
            {
                Text = "Завантажити",
                Location = new Point(10, 480)
            };
            btnLoad.Click += BtnLoad_Click;
            this.Controls.Add(btnLoad);

            btnMirror = new Button
            {
                Text = "Здзеркалити",
                Location = new Point(130, 480)
            };
            btnMirror.Click += BtnMirror_Click;
            this.Controls.Add(btnMirror);

            btnSave = new Button
            {
                Text = "Зберегти",
                Location = new Point(250, 480)
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Зображення (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImage = new Bitmap(ofd.FileName);
                pictureBox.Image = currentImage;
            }
        }

        private void BtnMirror_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;

            Bitmap mirrored = new Bitmap(currentImage.Width, currentImage.Height);
            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color pixel = currentImage.GetPixel(x, y);
                    mirrored.SetPixel(currentImage.Width - x - 1, y, pixel);
                }
            }

            currentImage = mirrored;
            pictureBox.Image = mirrored;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PNG файл (*.png)|*.png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
