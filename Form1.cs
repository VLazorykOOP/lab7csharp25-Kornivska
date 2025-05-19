using System;
using System.Drawing;
using System.Windows.Forms;

namespace InfoFormApp
{
    public partial class Form1 : Form
    {
        private TextBox textBox;
        private Button btnInfo;
        private Button btnExit;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Ініціалізація
            this.Text = "Форма з Інформацією";
            this.Size = new Size(400, 200);

            rand = new Random();

            textBox = new TextBox
            {
                Location = new Point(20, 20),
                Width = 340
            };
            this.Controls.Add(textBox);

            btnInfo = new Button
            {
                Text = "Інформація",
                Location = new Point(20, 60),
                Width = 100
            };
            btnInfo.Click += BtnInfo_Click;
            this.Controls.Add(btnInfo);

            btnExit = new Button
            {
                Text = "Вихід",
                Location = new Point(140, 60),
                Width = 100
            };
            btnExit.MouseEnter += BtnExit_MouseEnter;
            btnExit.Click += (s, e) => Application.Exit();
            this.Controls.Add(btnExit);
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            textBox.Text = $"Позиція форми: X = {this.Location.X}, Y = {this.Location.Y}";
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            int maxX = this.ClientSize.Width - btnExit.Width;
            int maxY = this.ClientSize.Height - btnExit.Height;
            int newX = rand.Next(0, maxX);
            int newY = rand.Next(0, maxY);

            btnExit.Location = new Point(newX, newY);
        }
    }
}
