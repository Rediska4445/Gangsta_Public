namespace StreetRobbery
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.minutes = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.Label();
            this.give_me_ur_money = new System.Windows.Forms.Label();
            this.please_dont_kill_me = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gun = new System.Windows.Forms.PictureBox();
            this.Background = new System.Windows.Forms.PictureBox();
            this.Ammo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 713);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 713);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "До прибытия копов: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // minutes
            // 
            this.minutes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.minutes.AutoSize = true;
            this.minutes.Location = new System.Drawing.Point(511, 713);
            this.minutes.Name = "minutes";
            this.minutes.Size = new System.Drawing.Size(14, 16);
            this.minutes.TabIndex = 4;
            this.minutes.Text = "0";
            this.minutes.Click += new System.EventHandler(this.minutes_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 713);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // seconds
            // 
            this.seconds.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.seconds.AutoSize = true;
            this.seconds.Location = new System.Drawing.Point(547, 713);
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(21, 16);
            this.seconds.TabIndex = 6;
            this.seconds.Text = "00";
            this.seconds.Click += new System.EventHandler(this.seconds_Click);
            // 
            // give_me_ur_money
            // 
            this.give_me_ur_money.AutoSize = true;
            this.give_me_ur_money.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.give_me_ur_money.Location = new System.Drawing.Point(1008, 17);
            this.give_me_ur_money.Name = "give_me_ur_money";
            this.give_me_ur_money.Size = new System.Drawing.Size(182, 20);
            this.give_me_ur_money.TabIndex = 7;
            this.give_me_ur_money.Text = "Give Me Ur Money!!!";
            this.give_me_ur_money.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.give_me_ur_money.Visible = false;
            // 
            // please_dont_kill_me
            // 
            this.please_dont_kill_me.AutoSize = true;
            this.please_dont_kill_me.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.please_dont_kill_me.Location = new System.Drawing.Point(21, 17);
            this.please_dont_kill_me.Name = "please_dont_kill_me";
            this.please_dont_kill_me.Size = new System.Drawing.Size(181, 20);
            this.please_dont_kill_me.TabIndex = 8;
            this.please_dont_kill_me.Text = "Please, Dont Kill Me";
            this.please_dont_kill_me.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(1012, 709);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "Shop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(1108, 709);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "Menu";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 713);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Label";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(874, 713);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Label";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(827, 713);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Label";
            // 
            // gun
            // 
            this.gun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gun.BackColor = System.Drawing.Color.Transparent;
            this.gun.Image = global::StreetRobbery.Properties.Resources.glock__1_;
            this.gun.Location = new System.Drawing.Point(574, 698);
            this.gun.Name = "gun";
            this.gun.Size = new System.Drawing.Size(59, 42);
            this.gun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gun.TabIndex = 14;
            this.gun.TabStop = false;
            // 
            // Background
            // 
            this.Background.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Background.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Background.Image = global::StreetRobbery.Properties.Resources.background_1200;
            this.Background.Location = new System.Drawing.Point(0, 40);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1204, 652);
            this.Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // Ammo
            // 
            this.Ammo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Ammo.AutoSize = true;
            this.Ammo.Location = new System.Drawing.Point(639, 698);
            this.Ammo.Name = "Ammo";
            this.Ammo.Size = new System.Drawing.Size(41, 16);
            this.Ammo.TabIndex = 15;
            this.Ammo.Text = "Label";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(639, 724);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Label";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 713);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 16);
            this.label9.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1204, 746);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Ammo);
            this.Controls.Add(this.gun);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.please_dont_kill_me);
            this.Controls.Add(this.give_me_ur_money);
            this.Controls.Add(this.seconds);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minutes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Background);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Gangsta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label minutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label seconds;
        private System.Windows.Forms.Label give_me_ur_money;
        private System.Windows.Forms.Label please_dont_kill_me;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox gun;
        private System.Windows.Forms.Label Ammo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
    }
}

