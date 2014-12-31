using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication11
{
    public class Bet
    {
        public int Amount { set; get; }// The amount of cash that was bet
        public int Dog { set; get; } // The number of the dog the bet is on
        public Guy Bettor { set; get; } //Guy who placed the bet

        public string GetDescription()
        {

            string description = String.Format("{0} bets {1} on dog #{2}", Bettor.Name, Amount, Dog);
            // Return a string that says who placed the bet, how much
            // cash was bet, and which dog he bet on ("Joe bets 8 on dog #4")
            // If the amount is zero, no bet was placed ("Joe hasn't placed a bet")
            return description;
        }

        public int PayOut(int Winner)
        {
            // The parameter is the winner of the race.  If the dog won,
            // return the amount bet.  Otherwise, return the negative of 
            // the amount bet.

            if (Dog == Winner)
                return Amount;
            else
                return -Amount;

        }
    }
}

