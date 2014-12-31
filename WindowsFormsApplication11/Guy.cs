using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public class Guy
    {
       
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public string Name { get; set; }
        public Bet MyBet { get; set; }
        public int Cash { get; set; }

        public void UpdateLabels()
        {
            // Set my label to my bet's description, and the label of my
            // radio button to show my cash ("Joe has 43 bucks")
            MyRadioButton.Text = String.Format("{0} has {1} bucks", Name, Cash);
            MyLabel.Text = Name + " hasn't placed a bet";
        }
        public void ClearBet()
        {
            this.MyLabel.Text = Name + " hasn't placed a bet";
            this.MyRadioButton.Text = Name + " has " + Cash + " bucks";
            // Reset my bet so it's zero
        }
        public bool PlaceBet(int betAmount, int dogToWin)
        {
            // Place a new bet and store it in my bet field
            // Return true if the guy had enough money to bet
            MyBet = new Bet { Amount = betAmount, Dog = dogToWin, Bettor = this };
            return (this.Cash >=betAmount);
        }
        public void Collect(int winner)
        {
            // Ask my bet to pay out, clear my bet, and update labels
            if (this.MyBet != null)
            {
                Cash += MyBet.PayOut(winner);
            }
        }

    }
}
