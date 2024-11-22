using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetRobbery
{
    public partial class Setting : Form
    {
        private int countPassebry;
        private int spawnPolice;
        private int spawnEnemy;
        private int moneyLeave;

        public Setting()
        {
            InitializeComponent();
            countPassebry = 1;
            spawnPolice = 5;
            spawnEnemy = 30_000;
            moneyLeave = 1000;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            moneyLeave = trackBar3.Value;
            label8.Text = (trackBar3.Value * 100).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Menu m = new Menu();
            m.countPassebry = countPassebry;
            m.timePolice = spawnPolice;
            m.spawnEnemyTime = spawnEnemy;
            m.moneyLeave = moneyLeave;
            m.label1.Text = "Count Passebry: " + countPassebry + "\nTime for police: " + spawnPolice
                + "\nMoney for leave: " + moneyLeave + "\nSpawnEnemyTime: " + spawnEnemy;
            m.Show();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            spawnEnemy = trackBar1.Value * 1000;
            label6.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            spawnPolice = trackBar2.Value;
            label7.Text = trackBar2.Value.ToString();
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            countPassebry = trackBar4.Value;
            label9.Text = trackBar4.Value.ToString();
        }

        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
