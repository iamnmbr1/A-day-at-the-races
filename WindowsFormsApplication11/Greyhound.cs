using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public class Greyhound
    {
        public PictureBox MyPictureBox = null;
        public Random Randomizer;

        public int StartingPosition { get; set; }
        public int RacetrackLength { get; set; }
        public int Location { get; set; }

        public Greyhound()
        {
            Location = 0;
        }

        public bool Run()
        {
            // Move forward either 1, 2, 3, or 4 spaces at random
            Location = Randomizer.Next(1, 5);
            // Update the position of my PictureBox on the form like this:
            MyPictureBox.Left = MyPictureBox.Left + Location;
            // Return true if I won the race
            return (MyPictureBox.Right >= RacetrackLength);
        }
        public void TakeStartingPosition()//reset my location to 0 and my PictureBox to starting position
        {
            MyPictureBox.Left=StartingPosition;
            Location= 0;
        }
       
    }
}


   

