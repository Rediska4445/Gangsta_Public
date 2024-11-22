using StreetRobbery.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreetRobbery
{
    public partial class Form1 : Form
    {
        Robber Player;
        Robber Gangsta_Enemy;
        List<Passebry> passebry;

        public const int maxLocation = 300;
        public const int minLocation = 490;
        public const int BulletSpeed = 10;

        public int dura;

        public int seconds_int;
        public int minutes_int;

        public const int diaposoneInteractive = 150;
        public const int pleaseDontKillMe = 2000;
        public const int RUN_MOTHERFUCKER = 75;

        public bool movePassebry;
        public const int step = 15;

        public Form1(int timerPolice, int countPassebry, int moneyForLeave, int spawnEnemyTime)
        {
            InitializeComponent();

            passebry = new List<Passebry>();
            seconds_int = 59;
            minutes_int = timerPolice - 1;

            if(timerPolice == 0)
            {
                seconds_int = -1;
                minutes_int = -1;
            }

            seconds.Text = seconds_int.ToString();
            minutes.Text = minutes_int.ToString();

            Player = new Robber(Resources.gangsta, Bands.Crips, new Random().Next(
                100, 700), minLocation);
            Player.Form(this);
            Player.money = 0;
            Player.health = 999;
            Player.Ammo = 54;
            Player.current_gun = Guns.Glock;
            Player.Current_Ammo = 0;
            label9.Text = "Health: " + Player.health;

            if (File.Exists("data.txt"))
            {
                using (StreamReader reader = new StreamReader("data.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("money"))
                        {
                            Player.money = int.Parse(line.Substring(line.IndexOf(":")).Substring(1));
                        }
                        else if (line.Contains("gun"))
                        {
                            string gun = line.Substring(line.IndexOf(":")).Substring(1);
                            switch (gun)
                            {
                                case "Glock":
                                    Player.current_gun = Guns.Glock;
                                    label8.Text = "Glock-17";
                                    this.gun.Image = Resources.glock__1_;
                                    break;
                                case "Sawed_Off":
                                    Player.current_gun = Guns.Sawed_Off;
                                    label8.Text = "Sawed-Off";
                                    this.gun.Image = Resources.sawed_off__3_;
                                    break;
                                case "Deagle":
                                    Player.current_gun = Guns.Deagle;
                                    label8.Text = "Desert Eagle";
                                    this.gun.Image = Resources.deagle__1_;
                                    break;
                                default:
                                    Player.current_gun = Guns.Glock;
                                    label8.Text = "Glock-17";
                                    this.gun.Image = Resources.glock__1_;
                                    break;
                            }
                        }
                        else if (line.Contains("ammo"))
                        {
                            Player.Ammo = int.Parse(line.Substring(line.IndexOf(":")).Substring(1));
                        }
                        else if (line.Contains("current_ammo"))
                        {
                            Player.Current_Ammo = int.Parse(line.Substring(line.IndexOf(":")).Substring(1));
                        }
                        else if (line.Contains("health"))
                        {
                            Player.health = int.Parse(line.Substring(line.IndexOf(":")).Substring(1));
                        }
                    }
                }
            }

            Background.Controls.Add(Player.pictureBox);

            Ammo.Text = Player.Current_Ammo + " : " + Player.Ammo;

            Gangsta_Enemy = new Robber(Resources.gangsta1, Bands.Bloods, 
                Background.Image.Width, maxLocation);
            Gangsta_Enemy.Form(this);
            Background.Controls.Add(Gangsta_Enemy.pictureBox);

            SpawnPassebry(countPassebry);

            label2.Text = "Money: " + Player.money.ToString() + " $";
            timer1.Start();

            timer2.Interval = 1750;
            timer3.Interval = spawnEnemyTime;
            timer3.Start();

            new Task(() =>
            {
                while(true)
                {
                    if (Gangsta_Enemy.isKilled)
                        timer2.Stop();

                    if (Player.isKilled || Player.health <= 0)
                        End("U killed by gangsta", "U die");
                }
            }).Start();
        }

        //public void SpawnPolice(int minutes)
        //{
        //    Car police = new Car(Resources.police_car, new Point(-200, Background.Height - 325), new Size(400, 400));
        //    new Thread(() =>
        //    {
        //        while (true)
        //        {
        //            for (int x = -200; x < Background.Width + 200; x += 15)
        //            {
        //                Thread.Sleep(2);
        //                police.pictureBox.Location = new Point(x, police.pictureBox.Location.Y);
        //                if (Player.pictureBox.Image == Resources.gangsta_interact || Player.pictureBox.Image == Resources.gangsta_interact_back)
        //                    End("Полиция увидела как ты грабишь прохожих", "Тебя поймали");

        //            }
        //            Thread.Sleep(new Random().Next(1, 5) * 60000);
        //        }
        //    }).Start();
        //    Background.Controls.Add(police.pictureBox);
        //}

        public void SpawnEnemy()
        {
            Gangsta_Enemy = new Robber(Resources.gangsta1, Bands.Bloods,
                 Background.Image.Width, maxLocation);
            Gangsta_Enemy.current_gun = Guns.Glock;
            Gangsta_Enemy.Form(this);
            Gangsta_Enemy.pictureBox.Click += (s, e) =>
            {
                try
                {
                    if (Player.Current_Ammo > 0)
                        Player.Shoot(Gangsta_Enemy, BulletSpeed);
                } catch(IndexOutOfRangeException) {}
                Ammo.Text = Player.Current_Ammo + ":" + Player.Ammo;
                label7.Text = Gangsta_Enemy.health.ToString();
            };

            Background.Controls.Add(Gangsta_Enemy.pictureBox);
            MoveEnemyX(Background.Width, new Random(5).Next(Gangsta_Enemy.pictureBox.Width, Background.Width / 2)).Start();
        }

        public Task MoveEnemyX(int from, int to)
        {
            return new Task(() =>
            {
                if (to > from)
                {
                    for (int x1 = from; x1 < to; x1 += step / 3)
                    {
                        Thread.Sleep(10);
                        Gangsta_Enemy.SetLocation(x1, Gangsta_Enemy.pictureBox.Location.Y);
                    }
                }
                else
                {
                    for (int x1 = from; x1 > to; x1 -= step / 3)
                    {
                        Thread.Sleep(10);
                        Gangsta_Enemy.SetLocation(x1, Gangsta_Enemy.pictureBox.Location.Y);
                    }
                }
                MoveEnemyY(Player.pictureBox.Location.Y, Gangsta_Enemy.pictureBox.Location.Y, step / 3).Start();
            });
        }

        public Task MoveEnemyY(int playerY, int GangstaY, int steps)
        {
            return new Task(() =>
            {
                if (playerY > GangstaY)
                {
                    for (int x1 = GangstaY; x1 < playerY; x1 += steps)
                    {
                        Thread.Sleep(10);
                        Gangsta_Enemy.SetLocation(Gangsta_Enemy.pictureBox.Location.X, x1);
                    }
                }
                else
                {
                    for (int x1 = GangstaY; x1 > playerY; x1 -= steps)
                    {
                        Thread.Sleep(10);
                        Gangsta_Enemy.SetLocation(Gangsta_Enemy.pictureBox.Location.X, x1);
                    }
                }
                Gangsta_Enemy.pictureBox.Image = Resources.gangsta_interact1;
            });
        }

        public void SpawnPassebry(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Passebry pas1 = new Passebry(please_dont_kill_me, Resources.passebry,
                    new Random(new Random().Next(1, 15)).Next(100, Background.Width - 100),
                    new Random(i * 3).Next(300, 315),
                    pleaseDontKillMe, RUN_MOTHERFUCKER, step,
                    Background.Width, Background.Height);

                Background.Controls.Add(pas1.pictureBox);
                Background.Controls.Add(pas1.please_dont_kill_me);

                Task pas1Move = pas1.Move(
                    new Random(i * 4).Next(1, 5) * 1000,
                    new Random(i * 5).Next(1, 5) * 100,
                    new Random(i * 6).Next(-step, step),
                    0,
                    new Random(i * 7).Next(10, 25)
                );
                pas1Move.Start();

                pas1.pictureBox.Click += (s, e) =>
                {
                    if (!pas1.please_dont_kill_me.Visible && (Player.pictureBox.Location.X + (Player.pictureBox.Width + diaposoneInteractive) >= pas1.pictureBox.Location.X
                            && Player.pictureBox.Location.X + (Player.pictureBox.Width - diaposoneInteractive) <= pas1.pictureBox.Location.X + pas1.pictureBox.Width)
                            && (Player.pictureBox.Location.Y + (Player.pictureBox.Height + diaposoneInteractive) >= pas1.pictureBox.Location.Y
                            && Player.pictureBox.Location.Y + (Player.pictureBox.Height - diaposoneInteractive) <= pas1.pictureBox.Location.Y + pas1.pictureBox.Height))
                    {
                        Robbery(pleaseDontKillMe, pas1);
                        pas1.Interact().Start();
                    }
                };

                passebry.Add(pas1);
            }
        }

        private void Robbery(int dura, Passebry pas1)
        {
            Player.money += new Random().Next(5, 50);
            label2.Text = "Money: " + Player.money + " $";

            give_me_ur_money.Location = new Point(Player.pictureBox.Location.X - Player.pictureBox.Width / 2, Player.pictureBox.Location.Y - Player.pictureBox.Height + 50);

            give_me_ur_money.Visible = true;
            new Task(() =>
            {
                if (pas1.pictureBox.Location.X < Player.pictureBox.Location.X)
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_interact_back;
                    else
                        Player.pictureBox.Image = Resources.gangsta_interact_back;
                }
                else
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_interact;
                    else
                        Player.pictureBox.Image = Resources.gangsta_interact;
                }

                Thread.Sleep(dura);

                if (pas1.pictureBox.Location.X < Player.pictureBox.Location.X)
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_back;
                    else
                        Player.pictureBox.Image = Resources.gangsta_back;
                }
                else
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking;
                    else
                        Player.pictureBox.Image = Resources.gangsta;
                }

                give_me_ur_money.Visible = false;
            }).Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = timer3.Enabled.ToString();
            if (seconds_int > 0)
            {
                seconds_int -= 1;
                seconds.Text = seconds_int.ToString();
            }
            else if (minutes_int > 0)
            {
                if (seconds_int == 0) 
                    seconds_int = 60;
                minutes_int -= 1;
                minutes.Text = minutes_int.ToString();
            } else if(seconds_int < 0 || minutes_int < 0)
            {
                label5.Text = "";
                seconds.Text = "";
                minutes.Text = "Infinity";
            }

            if (seconds_int == 0 && minutes_int == 0)
            {
                if (Player.money < 1000)
                    End("Полиция смоглa найти тебя", "Тебя поймали");
                else
                    End("Ты успел свалить", "Ты выжил");
            } 

            if (!Background.Controls.Contains(Gangsta_Enemy.pictureBox))
            {
                timer2.Stop();
                timer3.Start();
            }

        }

        public void End(string msg, string msgTitle)
        {
            MessageBox.Show(
                msgTitle,
                msg,
                MessageBoxButtons.OK);
            Hide();
            new Menu().Show();
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("data.txt", false))
            {
                writer.WriteLineAsync("money:" + Player.money + "\ngun:" + Player.current_gun
                 + "\ncurrent_ammo:" + Player.Current_Ammo + "\nammo:" + Player.Ammo
                 + "\nhealth:" + Player.health);
            }
            Hide();
            new Menu().Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Text = Player.pictureBox.Location.ToString();

            if (e.KeyCode == Keys.W)
            {
                if (Player.pictureBox.Location.Y > maxLocation)
                    Player.SetLocation(Player.pictureBox.Location.X, Player.pictureBox.Location.Y - step);
            }
            if (e.KeyCode == Keys.A)
            {
                if (!give_me_ur_money.Visible)
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_back;
                    else
                        Player.pictureBox.Image = Resources.gangsta_back;
                }
                else
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_interact_back;
                    else
                        Player.pictureBox.Image = Resources.gangsta_interact_back;
                }

                if (Player.pictureBox.Location.X > 0)
                    Player.SetLocation(Player.pictureBox.Location.X - step, Player.pictureBox.Location.Y);
            }
            if (e.KeyCode == Keys.S)
            {
                if (Player.pictureBox.Location.Y < Background.Height - Player.pictureBox.Height)
                    Player.SetLocation(Player.pictureBox.Location.X, Player.pictureBox.Location.Y + step);
            }
            if (e.KeyCode == Keys.D)
            {
                if (!give_me_ur_money.Visible)
                {
                    if(Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking;
                    else
                        Player.pictureBox.Image = Resources.gangsta;
                }
                else
                {
                    if (Player.isSmoking)
                        Player.pictureBox.Image = Resources.gangsta_smoking_interact;
                    else
                        Player.pictureBox.Image = Resources.gangsta_interact;
                }

                if (Player.pictureBox.Location.X < Background.Width - Player.pictureBox.Width)
                    Player.SetLocation(Player.pictureBox.Location.X + step, Player.pictureBox.Location.Y);
            }
            if (e.KeyCode == Keys.T)
            {
                if(!Player.isSmoking)
                    Player.Smoke(Drugs.Sativa);
            }
            if (e.KeyCode == Keys.R)
            {
                Player.ReloadGun();
                Ammo.Text = Player.Current_Ammo + ":" + Player.Ammo;
            }
            if (!(Gangsta_Enemy.pictureBox.Location.Y + Gangsta_Enemy.pictureBox.Height >= Player.pictureBox.Location.Y
                 && Gangsta_Enemy.pictureBox.Location.Y + Gangsta_Enemy.pictureBox.Height <= Player.pictureBox.Location.Y + Player.pictureBox.Height))
            {
                if (Gangsta_Enemy.Location.X < Player.Location.X)
                    Gangsta_Enemy.pictureBox.Image = Resources.gangsta1;
                else
                    Gangsta_Enemy.pictureBox.Image = Resources.gangsta_back1;
            } 
            give_me_ur_money.Location = new Point(Player.pictureBox.Location.X - Player.pictureBox.Width / 2, Player.pictureBox.Location.Y - Player.pictureBox.Height + 25);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("data.txt", false))
            {
                writer.WriteLine("money:" + Player.money + "\ngun:" + Player.current_gun
                    + "\ncurrent_ammo:" + Player.Current_Ammo + "\nammo:" + Player.Ammo
                    + "\nhealth:" + Player.health);
            }
            Environment.Exit(0);
        }

        private void seconds_Click(object sender, EventArgs e)
        {
            Player.pictureBox.Controls.Remove(passebry[0].pictureBox);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Gangsta_Enemy.pictureBox.Location.Y + Gangsta_Enemy.pictureBox.Height - 25 >= Player.pictureBox.Location.Y
                 && Gangsta_Enemy.pictureBox.Location.Y <= Player.pictureBox.Location.Y + Player.pictureBox.Height - 25)
            {
                Gangsta_Enemy.Shoot(Player, BulletSpeed);
                label9.Text = "Health: " + Player.health;
            }
            else
                MoveEnemyY(Player.pictureBox.Location.Y, Gangsta_Enemy.pictureBox.Location.Y, step / 3).Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SpawnEnemy();
            timer2.Start();
            timer3.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("data.txt", false))
            {
                writer.WriteLine("money:" + Player.money + "\ngun:" + Player.current_gun
                 + "\ncurrent_ammo:" + Player.Current_Ammo + "\nammo:" + Player.Ammo
                 + "\nhealth:" + Player.health);
            }
            Hide();
            new Shop(this).Show();
        }

        private void minutes_Click(object sender, EventArgs e)
        {

        }
    }

    public class Passebry : Entity
    {
        public System.Windows.Forms.Label please_dont_kill_me;
        public PictureBox pictureBox;
        public Point Location;
        public int pleaseDontKillMe;
        public int RUN_MOTHERFUCKER;
        public int step;
        public int widthBackground;
        public int heightBackground;

        private int x;
        private int y;

        public Passebry(Label label, Image image, int x, int y, int pleaseDontKillMe, int RUN_MOTHERFUCKER, int step, int widthBackground, int heightBackground)
        {
            please_dont_kill_me = label;
            please_dont_kill_me.Visible = false;
            this.widthBackground = widthBackground;
            this.heightBackground = heightBackground;
            this.step = step;
            this.RUN_MOTHERFUCKER = RUN_MOTHERFUCKER;
            this.pleaseDontKillMe = pleaseDontKillMe;
            pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Size = new Size(80, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(x, y);
        }

        public Task Move(int sleep, int sleep1, int x, int y, int steps)
        {
            this.x = x;
            this.y = y;
            object locker = new object();
            return new Task(() =>
            {
                lock(locker)
                {
                    while (true)
                    {
                        Thread.Sleep(sleep);
                        for (int i = 0; i < steps; i++)
                        {
                            Thread.Sleep(sleep1);
                            if (pictureBox.Location.X > 0 && pictureBox.Location.X < widthBackground - pictureBox.Width)
                                pictureBox.Location = new Point(pictureBox.Location.X + this.x, pictureBox.Location.Y + this.y);
                        }
                    }
                }
            });
        }

        public Task Interact()
        {
            int xBuff = x;
            int yBuff = y;
            please_dont_kill_me.Text = "Please, Dont Kill Me";
            please_dont_kill_me.Location = new Point(pictureBox.Location.X - pictureBox.Width / 2, pictureBox.Location.Y - pictureBox.Height + 25);
            please_dont_kill_me.Visible = true;
            pictureBox.Image = Resources.passebry_scary;

            return new Task(() =>
            {
                x = 0;
                y = 0;
                Thread.Sleep(pleaseDontKillMe);
                pictureBox.Image = Resources.passebry;
                while (pictureBox.Location.X < widthBackground)
                {
                    Thread.Sleep(RUN_MOTHERFUCKER);
                    SetLocation(pictureBox.Location.X + step, pictureBox.Location.Y);
                    please_dont_kill_me.Location = new Point(pictureBox.Location.X - pictureBox.Width / 2, pictureBox.Location.Y - pictureBox.Height + 25);
                }
                pictureBox.Location = new Point(new Random(2).Next(150, widthBackground / 2), new Random().Next(300, 315));
                please_dont_kill_me.Visible = false;
                x = xBuff;
                y = yBuff;
            });
        }

        public void SetLocation(int x, int y)
        {
            pictureBox.Location = new Point(x, y);
        }
    }

    public class Car : Entity
    {
        public int X;
        public int Y;
        public PictureBox pictureBox;

        public Car(Image image, Point XY, Size size)
        {
            pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Location = new Point(XY.X, XY.Y);
            X = XY.X;
            Y = XY.Y;
            pictureBox.Size = size;
            pictureBox.BackColor = Color.Transparent;
        }

        public void SetLocation(int x, int y)
        {
            pictureBox.Location = new Point(x, y);
        }

    }

    public enum Items
    {
        Drug,
        Gun,
        Money
    }

    public enum Bands
    {
        Bloods,
        Crips
    }

    public enum Guns
    {
        Glock,
        Sawed_Off,
        MAC_10,
        Deagle
    }

    public enum Drugs
    {
        Sativa, // trava
        Crack,
        Cocaine
    }

    public class Robber : Entity
    {
        public Bands banda;
        public int health;
        public bool isKilled;
        public int Current_Ammo;
        public int Ammo;
        public PictureBox pictureBox;
        public Point Location;
        public int money;
        public Guns current_gun;

        private PictureBox drug_smoke;
        public bool isSmoking;

        Form1 form;

        public void Form(Form1 form)
        {
            this.form = form;
        }

        public void ReloadGun()
        {
            Task.Run(() =>
            {
                //Thread.Sleep(500);
                //if (banda == Bands.Crips)
                //    pictureBox.Image = Resources.gangsta_interact;
                //else
                //    pictureBox.Image = Resources.gangsta_interact1;
                int ammunation = 0;
                switch (current_gun)
                {
                    case Guns.Glock:
                        ammunation = 17;
                        break;
                    case Guns.Sawed_Off:
                        ammunation = 5;
                        break;
                    case Guns.MAC_10:
                        ammunation = 30;
                        break;
                    case Guns.Deagle:
                        ammunation = 7;
                        break;
                }
                if (Current_Ammo < ammunation)
                {
                    if (Ammo >= ammunation)
                    {
                        Ammo -= ammunation;
                        Current_Ammo = ammunation;
                    }
                    else if (Ammo > 0 && Ammo <= ammunation)
                    {
                        Current_Ammo = Ammo;
                        Ammo = 0;
                    }
                }
            });
        }

        public Robber(Image image, Bands banda, int x, int y) // size = 88:204
        {
            this.banda = banda;
            current_gun = Guns.Glock;
            isKilled = false;
            money = 10;
            health = 5;
            pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Size = new Size(80, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(x, y);
            ReloadGun();
        }

        public Bullet Shoot(Robber to, int bulletSpeed)
        {
            Bullet bullet = new Bullet(new Size(50, 50), Resources.bullet);
            bullet.speed = bulletSpeed;
            bullet.bullet.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            form.Background.Controls.Add(bullet.bullet);

            Current_Ammo -= 1;

            PictureBox blood = new PictureBox();
            blood.Image = Resources.blood;
            blood.Location = new Point(form.Background.Width, form.Background.Height);
            blood.Size = new Size(bullet.bullet.Size.Width, bullet.bullet.Size.Height);
            blood.SizeMode = PictureBoxSizeMode.Zoom;
            blood.BackColor = Color.Transparent;
            form.Background.Controls.Add(blood);

            CheckRotateSkin(to);
            if (pictureBox.Location.X < to.pictureBox.Location.X)
                bullet.bullet.Image = Resources.bullet;
            else 
                bullet.bullet.Image = Resources.bullet_back;

            new Task(() =>
            {
                int xTo = pictureBox.Location.X > to.pictureBox.Location.X ? -bullet.speed : bullet.speed;
                for (int x = pictureBox.Location.X; x != to.pictureBox.Location.X; x += xTo)
                {
                    Thread.Sleep(10);
                    bullet.bullet.Location = new Point(x, bullet.bullet.Location.Y);
                    if (bullet.bullet.Location.X >= to.pictureBox.Location.X
                             && bullet.bullet.Location.X <= to.pictureBox.Location.X + to.pictureBox.Width
                             && bullet.bullet.Location.Y >= to.pictureBox.Location.Y
                             && bullet.bullet.Location.Y <= to.pictureBox.Location.Y + to.pictureBox.Height)
                    {
                        if (to.health <= 1) { 
                            to.Kill(blood, this); 
                        } else { 
                            switch(current_gun)
                            {
                                case Guns.Glock:
                                    to.health -= 1;
                                    break;
                                case Guns.Sawed_Off:
                                    to.health -= 3;
                                    break;
                                case Guns.Deagle:
                                    to.health -= 5;
                                    break;
                            }
                        }
                        break;
                    }
                }
                // form.Background.Controls.Remove(bullet.bullet);
                bullet.bullet.Dispose();
                CheckRotateSkin(to);
            }).Start();
            return bullet;
        }

        public void Smoke(Drugs drug)
        {
            switch (drug)
            {
                case Drugs.Sativa:
                    isSmoking = true;
                    if (pictureBox.Image == Resources.gangsta)
                        pictureBox.Image = Resources.gangsta_smoking;
                    else
                        pictureBox.Image = Resources.gangsta_smoking_back;
                    drug_smoke = new PictureBox();
                    drug_smoke.Size = new Size(50, 50);
                    drug_smoke.SizeMode = PictureBoxSizeMode.Zoom;
                    drug_smoke.BackColor = Color.Transparent;
                    drug_smoke.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 50);
                    form.Background.Controls.Add(drug_smoke);

                    Image[] img = new Image[] {
                        Resources.smoke_sativa, Resources.smoke_sativa__1_, Resources.smoke_sativa__2_
                    };

                    Task.Run(() =>
                    {
                        for(int i = 0; i < 15; i++)
                        {
                            foreach (Image image in img)
                            {
                                drug_smoke.Image = image;
                                Thread.Sleep(250);
                                health += 1;
                            }
                        }
                        if (pictureBox.Image == Resources.gangsta)
                            pictureBox.Image = Resources.gangsta;
                        else
                            pictureBox.Image = Resources.gangsta_back;
                        isSmoking = false;
                        // form.Background.Controls.Remove(drug_smoke);
                        drug_smoke.Dispose();
                    });
                    break;
            }
        }

        public void Kill(PictureBox blood, Robber whoKilled)
        {
            pictureBox.Dispose();
            Task.Run(() =>
            {
                // DropItem(whoKilled, Items.Money, new Point(this.pictureBox.Location.X, this.pictureBox.Location.Y - 25));
                blood.BringToFront();
                blood.Location = new Point(this.pictureBox.Location.X, this.pictureBox.Location.Y);
                whoKilled.money += new Random().Next(25, 100);
                Thread.Sleep(1500);
                // form.Background.Controls.Remove(blood);
                blood.Dispose();
            });
            isKilled = true;
        }

        private void CheckRotateSkin(Robber to)
        {
            switch (banda) {
                case Bands.Bloods:
                    if (pictureBox.Location.X < to.pictureBox.Location.X)
                        pictureBox.Image = Resources.gangsta_interact1;
                    else
                        pictureBox.Image = Resources.gangsta_interact_back1;
                    break;
                case Bands.Crips:
                    if (pictureBox.Location.X < to.pictureBox.Location.X)
                    {
                        if(isSmoking)
                            pictureBox.Image = Resources.gangsta_smoking_interact;
                        else
                            pictureBox.Image = Resources.gangsta_interact;
                    }
                    else
                    { 
                        if (isSmoking)
                            pictureBox.Image = Resources.gangsta_smoking_interact_back;
                        else
                            pictureBox.Image = Resources.gangsta_interact_back;
                    }
                    break;
            } 
        }

        public void SetLocation(int x, int y)
        {
            pictureBox.Location = new Point(x, y);
            if (isSmoking)
                drug_smoke.Location = new Point(x + 5, y - 50);
        }
    }

    public class Bullet
    {
        public int speed;
        public PictureBox bullet;
         
        public Bullet(Size size, Image image)
        {
            bullet = new PictureBox();
            bullet.Image = image;
            bullet.Size = size;
            bullet.SizeMode = PictureBoxSizeMode.Zoom;
            bullet.BackColor = Color.Transparent;
        }
    }

    interface Entity
    {
        void SetLocation(int x, int y);
    }
}