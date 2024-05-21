using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace OOP_Assessment
{
    public class Result
    {
        public int Placed { get; set; }
        public double RaceTime { get; set; }
        public bool Qualified { get; set; }

        public Result(int placed, double raceTime)
        {
            Placed = placed;
            RaceTime = raceTime;
            // Set the Qualified property based on the placed value
            Qualified = placed <= 3; // Automatically sets Qualified to true if Placed is 1, 2, or 3; false otherwise
        }

        // Method to provide a string representation of Result
        public override string ToString()
        {
            return $"Placed: {Placed}, Race Time: {RaceTime} seconds, Qualified: {Qualified}";
        }
    }
}


