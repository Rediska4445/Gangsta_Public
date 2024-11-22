using System;
using System.Windows.Forms;

namespace StreetRobbery
{
    public partial class Menu : Form
    {
        public int countPassebry = 1;
        public int timePolice = 5;
        public int moneyLeave = 1000;
        public int spawnEnemyTime = 30_000;

        public Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new Setting().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            Environment.Exit(0);
        }

        private void play_Click(object sender, EventArgs e)
        {
            Hide();
            new Form1(timePolice, countPassebry, moneyLeave, spawnEnemyTime).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            new Shop(this).Show();
        }
    }
}
