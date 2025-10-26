using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairsGame2
{
    public partial class Match : Form
    {

        Random Item = new Random();

        Label FirstClicked = null;

        Label SecondClicked = null;

        List<string> Storage = new List<string>()
        {

            "*","*", 

            "$","$",
            
            "%","%",
            
            "^","^",
            
            "!","!",

            "?","?",

            "N","N",
            
            "£", "£",
        };

        public Match()
        {
            InitializeComponent();
            AssigningImages();
        }

        private void AssigningImages()
        {
            foreach (Control instruction in tableLayoutPanel1.Controls)
            {
                Label symbols = instruction as Label;

                if (symbols != null)
                {

                    int Randomizer = Item.Next(Storage.Count);

                    symbols.Text = Storage[Randomizer];

                    symbols.ForeColor = symbols.BackColor;

                    Storage.RemoveAt(Randomizer);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
                return;

            Label clickey = sender as Label;

            if (clickey != null)
            {
                if (clickey.ForeColor == Color.Black)

                    return;

                if (FirstClicked == null)
                {

                    FirstClicked = clickey;

                    FirstClicked.ForeColor = Color.Black;

                    return;
                }

                SecondClicked = clickey;

                SecondClicked.ForeColor = Color.Black;

                winner();

                if (FirstClicked.Text == SecondClicked.Text)
                {
               
                    FirstClicked = null;

                    SecondClicked = null;

                    return;

                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Stop();

            SecondClicked.ForeColor = SecondClicked.BackColor;

            FirstClicked.ForeColor = SecondClicked.BackColor;

            FirstClicked = null;

            SecondClicked = null;

        }

        private void winner()
        {
            foreach(Control instruction in tableLayoutPanel1.Controls)
            {
                Label symbols = instruction as Label;

                if(symbols != null)
                {
                    if (symbols.ForeColor == symbols.BackColor)
                        return;
                }
            }

            tableLayoutPanel1.BackColor = Color.Green;

            MessageBox.Show("Yayyyyy!");

            MessageBox.Show("Congragulations!");

            MessageBox.Show("You've won!");

            Close();
        }
    }
}
