using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment
{
    public class CompHistory
    {
        // Property for the most recent win of the competitor
        public string MostRecentWin { get; set; }

        // Property for the total career wins of the competitor
        public int CareerWins { get; set; }

        // Property for the list of medals achieved by the competitor
        public List<string> Medals { get; set; }

        // Property for the personal best race time of the competitor
        public double PersonalBest { get; set; }

        // Constructor to initialise CompHistory 
        public CompHistory(string mostRecentWin, int careerWins, List<string> medals, double personalBest)
        {
            MostRecentWin = mostRecentWin;
            CareerWins = careerWins;
            Medals = medals;
            PersonalBest = personalBest;
        }

        // Method to provide a string representation of the CompHistory object
        public override string ToString()
        {
            string medalsString = string.Join(", ", Medals); // Concatenate medals into a comma-separated string
            return $"Most Recent Win: {MostRecentWin}, Career Wins: {CareerWins}, Personal Best: {PersonalBest} seconds, Medals: {medalsString}";
        }

        // Method to generate a string representation of the CompHistory object for file storage
        public string ToFile()
        {
            string medalsStr = string.Join(",", Medals); // Convert list of medals to a comma-separated string
            return $"{MostRecentWin},{CareerWins},{medalsStr},{PersonalBest}";
        }
    }
}

