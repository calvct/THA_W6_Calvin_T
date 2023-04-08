using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Calvin_T
{
    public partial class Form2 : Form
    {
        Button[,] btn = new Button[5, Form1.n];
        int x = 0;
        int y = 0;
        string question = Form1.word[Form1.a];
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //kalau mau tau jawabannya enable messagebox
            //MessageBox.Show(question);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < Form1.n; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].Size = new Size(60, 60);
                    btn[i, j].Location = new Point(i * 60 + 50, j * 60 + 50);
                    this.Controls.Add(btn[i, j]);
                }
            }

        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            var send = sender as Button;
            if (x != 5)
            {
                btn[x, y].Text = send.Text;
                x++;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            int benar = 0;
            
            if(x != 5)
            {
                MessageBox.Show("word must be 5 letters","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string penampung = "";
                for (int i = 0;i< x; i++)
                {
                    penampung += btn[i,y].Text;
                }
                if (Form1.word.Contains(penampung.ToLower()))
                {
                    for (int i = 0; i < x; i++)
                    {
                        if (question[i].ToString() == btn[i, y].Text.ToLower())
                        {
                            btn[i, y].BackColor = Color.ForestGreen;
                            benar++;
                        }
                        else if (question.Contains(btn[i, y].Text.ToLower()))
                        {
                            btn[i, y].BackColor = Color.Yellow; 
                        }
                        else
                        {
                            btn[i, y].BackColor = Color.Gray;
                        }
                    }
                    y++;
                    x = 0;
                    if(benar == 5)
                    {
                        MessageBox.Show("You win");
                        this.Close();
                    }
                    else if(benar < 5 && y == Form1.n)
                    {
                        MessageBox.Show("You lose, the correct answer is " + question);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("There is no word in wordlist");
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            btn[x - 1, y].Text = "";
            x--;
        }
    }
}
