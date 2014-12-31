using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
             private List<Guy> guys = new List<Guy>();
        private List<Greyhound> dogs = new List<Greyhound>();
        private Random MyRandom = new Random();
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            guys.Add(new Guy { Name = "Joe", Cash = 50, MyRadioButton = this.joeRadioButton, MyLabel = this.joeBetLabel });
            guys.Add(new Guy { Name = "Bob", Cash = 75, MyLabel = this.bobBetLabel, MyRadioButton = this.bobRadioButton });
            guys.Add(new Guy { Name = "Al", Cash = 45, MyRadioButton = this.alRadioButton, MyLabel = this.alBetLabel });
            dogs.Insert(0,new Greyhound { MyPictureBox = pictureBox1, StartingPosition = pictureBox1.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width, Randomizer = MyRandom });
            dogs.Insert(1,new Greyhound { MyPictureBox = pictureBox2, StartingPosition = pictureBox2.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width, Randomizer = MyRandom });
            dogs.Insert(2,new Greyhound { MyPictureBox = pictureBox3, StartingPosition = pictureBox3.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width, Randomizer = MyRandom });
            dogs.Insert(3,new Greyhound { MyPictureBox = pictureBox4, StartingPosition = pictureBox4.Left, RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width, Randomizer = MyRandom });
            
            foreach (Guy guy in guys)
            {
                guy.ClearBet();
            }

            this.minimumBetLabel.Text = "Minimum bet: " + numericUpDownBetSize.Minimum + " bucks";
            
        }
        
        private void buttonBets_Click(object sender, EventArgs e)
        {
            foreach (Guy guy in guys)
            {
                if (guy.MyRadioButton.Checked)
                {
                    if (guy.PlaceBet((int)numericUpDownBetSize.Value, (int)numericUpDownDogNumber.Value))
                    {
                        guy.MyLabel.Text = guy.MyBet.GetDescription();
                        //guy.MyRadioButton.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(guy.Name+ " doesn't has enough money!");
                    }
                }
            }
        }
        private void buttonRace_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Greyhound dog in dogs)
            {
                if (dog.Run())
                {
                    timer1.Stop();
                    // We have a winner!
                    int winningDog = dogs.IndexOf(dog)+1;
                    // Showing mesage who won
                    MessageBox.Show("Dog #" + winningDog + " won the race!", "We have a winner", MessageBoxButtons.OK);
                    // Each guy collects his winnings
                    foreach (Guy guy in guys)
                    {
                        guy.Collect(winningDog);
                        guy.UpdateLabels();   
                    }

                    foreach (Greyhound _dog in dogs)
                        _dog.TakeStartingPosition();
                    this.groupBox1.Enabled = true;
                }
            }
        }
        
        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.labelName.Text = "Joe";
        }
        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.labelName.Text = "Bob";
        }
        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.labelName.Text = "Al";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        

    };
}
