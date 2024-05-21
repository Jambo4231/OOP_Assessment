using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment
{
    public class Competitor
    {
        // Property for the competitor's unique number
        public int CompNumber { get; set; }

        // Property for the competitor's name
        public string CompName { get; set; }

        // Property for the competitor's age
        public int CompAge { get; set; }

        // Property for the competitor's hometown
        public string Hometown { get; set; }

        // Property for the competitor's associated event (e.g., BreastStroke)
        public BreastStroke CompEvent { get; set; }

        // Property for the competitor's race results
        public Result Results { get; set; }

        // Property for the competitor's competition history
        public CompHistory History { get; set; }

        // Constructor to initialise a Competitor object
        public Competitor(int compNumber, string compName, int compAge, string hometown, Result results, CompHistory history, BreastStroke compEvent)
        {
            CompNumber = compNumber;
            CompName = compName;
            CompAge = compAge;
            Hometown = hometown;
            Results = results;
            History = history;
            CompEvent = compEvent;
        }

        // Method to provide a string representation of the competitor
        public override string ToString()
        {
            return $"Competitor {CompNumber}: {CompName}, Age: {CompAge}, Hometown: {Hometown},\n {CompEvent}\n History: {History}\n Results: {Results} ";
        }

        // Method to generate a string representation of the competitor's data for file storage
        public string ToFile()
        {
            // Convert list of medals to a comma-separated string or return "No Medals" if null
            string medalsStr = History?.Medals != null ? string.Join(",", History.Medals) : "No Medals";

            // Format the output for writing to a file
            return $"Competitor Number: {CompNumber}, Name: {CompName}, Age: {CompAge}, Hometown: {Hometown}, " +
                   $"Event Number: {CompEvent?.EventNo}, Venue: {CompEvent?.Venue}, Event Date: {CompEvent?.EventDateTime}, Record: {CompEvent?.Record}, " +
                   $"Event Type: {CompEvent?.EventType}, Distance: {CompEvent?.Distance}, Winning Time: {CompEvent?.WinningTime}, New Record: {CompEvent?.NewRecord}, " +
                   $"Placed: {Results?.Placed}, Race Time: {Results?.RaceTime}, Qualified: {Results?.Qualified}, " +
                   $"Career Wins: {History?.CareerWins}, Personal Best: {History?.PersonalBest}, Medals: {medalsStr}";
        }
    }
}
