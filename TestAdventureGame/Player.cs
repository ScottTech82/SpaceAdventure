using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class Player
    {
        public string Name { get; set; }
        public decimal PlayerCredits { get; set; }


        public Player(string Name, decimal PlayerCredits)
        {
            this.Name = Name;
            this.PlayerCredits = PlayerCredits;
        }



    }
}
