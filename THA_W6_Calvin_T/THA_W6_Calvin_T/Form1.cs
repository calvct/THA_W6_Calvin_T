using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W6_Calvin_T
{
    public partial class Form1 : Form
    {
        Button btn = new Button();
        Label label = new Label();
        Label label1 = new Label();
        TextBox txt = new TextBox();
        public static string wordlist = File.ReadAllText(@"C:\Users\Calvin CT\source\repos\THA_W6_Calvin_T\THA_W6_Calvin_T\Wordle Word List.txt");
        public static string[] word = wordlist.Split(',');
        public static int n;
        static Random random = new Random();
        public static int a = random.Next(1, 14913);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "WORDLE";
            label1.Size = new Size(100, 20);
            label1.Location = new Point(80, 20);
            label1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            this.Controls.Add(label1);
            label.Text = "How many live?";
            label.Location = new Point(80, 50);
            this.Controls.Add(label);
            txt.Location = new Point(65, 70);
            txt.Size = new Size(110, 10);
            this.Controls.Add(txt);
            btn.Location = new Point(80, 100);
            btn.Size = new Size(80, 40);
            btn.Text = "Play";
            this.Controls.Add(btn);
            btn.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(txt.Text);
            if(n < 1)
            {
                MessageBox.Show("Minimum live is 1", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text = "";
                txt.Focus();
            }
            else
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }
    }
}
