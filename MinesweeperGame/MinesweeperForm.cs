using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MinesweeperGame
{
    public partial class MinesweeperForm : Form
    {
        internal bool flagForProduce = true;
        public int mineCounter = 0;
        public int clickedsafeButtons;
        public int Score;
        public int counter = 1; 
        public bool flag = false;
        Settings AppSettings;
        public mine[,] mineArray;
        public List<int> MineNumbers = new List<int>();
        Random rnd = new Random();
        public MinesweeperForm(Settings settings)
        {
            InitializeComponent();
            lblScore.Text = "0";
            AppSettings = settings;
            mineArray = new mine[AppSettings.cols,AppSettings.rows];
            if (settings.DifficultyLevel== "Hard")
            {
                // Settings for hard mode
                // btnProduce
                // 
                this.btnProduce.Location = new System.Drawing.Point(1006, 12);
                this.btnProduce.Size = new System.Drawing.Size(57, 105);
                // 
                // flowLayoutPanel1
                // 
                this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 4);
                this.flowLayoutPanel1.Size = new System.Drawing.Size(995, 694);
                // 
                // lblSkor
                // 
                this.lblScore.Location = new System.Drawing.Point(1041, 130);
                this.lblScore.Size = new System.Drawing.Size(29, 13);
                // 
                // label1
                // 
                this.label1.Location = new System.Drawing.Point(1003, 130);
                this.label1.Size = new System.Drawing.Size(32, 13);
                // 
                // Form
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.ClientSize = new System.Drawing.Size(1077, 699);
            }
        }
        private void MayinTarlasiForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i<AppSettings.MineCount; i++)
            {

                int x ;
                x = rnd.Next(0, AppSettings.Buttons);
                while (MineNumbers.Contains(x))
                {
                    x = rnd.Next(0, AppSettings.Buttons);

                }
                MineNumbers.Add(x);
            }

            for (int i = 0; i < AppSettings.cols; i++)
            {
                for (int j = 0; j < AppSettings.rows; j++)
                {
                    mineArray[i, j] = new mine();
                    this.mineArray[i, j].id = counter;
                    counter++; // Counter increased by 1 to go next index

                    if (MineNumbers.Contains(mineArray[i, j].id))
                    {
                        mineArray[i, j].isMineAround = true;
                    }
                }
            }
        }
        private void btnUret_Click(object sender, EventArgs e)
        {
            if (btnProduce.Text == "Exit")
            {
                this.Close();
            }

            if (!flagForProduce) return;
            flagForProduce = false;
            btnProduce.Text = "Exit";

            for (int i = 1; i <= AppSettings.Buttons; i++)
            {
                Button btnTemp = new Button();
                btnTemp.Name = "btn" + i.ToString();
                btnTemp.Size = new System.Drawing.Size(AppSettings.ButtonWidth, AppSettings.ButtonHeight);

                btnTemp.Text = i.ToString();
                btnTemp.UseVisualStyleBackColor = true;
                btnTemp.Enabled = true;

                if(MineNumbers.Contains(i))
                {
                    btnTemp.Tag = true;
                }
                else
                {
                    btnTemp.Tag = false;
                }
            
                btnTemp.BackColor = System.Drawing.SystemColors.ActiveBorder;
                btnTemp.Click += BtnTemp_Click;
                btnTemp.MouseUp += BtnTemp_MouseUp;
                flowLayoutPanel1.Controls.Add(btnTemp);
                
            }
        }

        private void BtnTemp_MouseUp(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (clickedButton.BackColor == Color.DarkBlue)
                {
                    clickedButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
                }
                else
                {
                    clickedButton.BackColor = Color.DarkBlue;
                }
                
            }
        }

        private void Control(int id)
        {
            int X = 0;
            int Y = 0;
            for (int x = 0; x < AppSettings.cols; x++)
            {
                for (int y = 0; y < AppSettings.rows; y++)
                {
                    if (mineArray[x, y].id == id)
                    {
                        X = x;
                        Y = y;
                        goto StartPosition;
                    }
                }
            }
            StartPosition:
            
            for (int i = X - 1; i <= X + 1; i++)
            {
                  for (int j = Y - 1; j <= Y + 1; j++)
                  {
                    if (i >= 0 && i < mineArray.GetLength(0) && j >= 0 && j < mineArray.GetLength(1))
                    {
                        if (mineArray[i, j].isMineAround == true)
                        {
                            
                            flag = true;
                            break;
                        }
                    }
                }
            }
        }

        private void BtnTemp_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            bool mayinBulundumu = (bool)clickedButton.Tag;


            if (mayinBulundumu)
            {
                // Mine Found
                MessageBox.Show("Mine found!");
                clickedButton.BackColor = Color.Red;
                clickedButton.Enabled = false;
                int SkorLost = rnd.Next(1, 55);
                Score = int.Parse(lblScore.Text);
                Score = Score - SkorLost;

                mineCounter++;
                if (mineCounter == 3)
                {
                    MessageBox.Show("You lost the game.. Your Score: " + Score, "You Lost The Game!");

                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        Button b = c as Button;
                        if (b != btnProduce)
                        {
                            b.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                // No Mine
                flag = false;
                Control(Convert.ToInt16(clickedButton.Text));

                if (flag == true) { clickedButton.BackColor = Color.Yellow; }
                else { clickedButton.BackColor = Color.Green; }
                clickedButton.Enabled = false;

                Score = int.Parse(lblScore.Text);
                lblScore.ForeColor = Color.Blue;
                Score++;
                lblScore.Text = Score.ToString();
                clickedsafeButtons++;
            }

            if (Score <= 0)
            {
                lblScore.Text = Score.ToString();
                lblScore.ForeColor = Color.Red;
            }
            else
            {
                lblScore.Text = Score.ToString();
                lblScore.ForeColor = Color.Blue;
            }
            if (AppSettings.Buttons - clickedsafeButtons == AppSettings.MineCount)
            {
                MessageBox.Show("Your Score: " + Score, "You Won The Game!");
                
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    Button b = c as Button;
                    if (b != btnProduce)
                    {
                        b.Enabled = false;
                    }
                }
                flagForProduce = false;
            }
            
        }

        
    }
}