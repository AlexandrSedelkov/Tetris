using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Records : Form
    {
        private readonly int score;
        public static bool recordIsOpened = false;
        public Records(int score)
        {
            InitializeComponent();

            this.score = score;
        }

        private void Records_Load(object sender, EventArgs e)
        {
            recordIsOpened = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                Properties.Settings.Default.Records.Add(DateTime.Now.ToString() + " " + score + " — " + nameTextBox.Text);
                recordIsOpened = false;
                this.Close();
                this.Dispose();
                return;
            }
            else
            {
                MessageBox.Show("Имя не может быть пустым!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Records_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
