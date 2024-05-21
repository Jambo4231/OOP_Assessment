using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP_Assessment
{
    public class Competition
    {
        public List<Competitor> Competitors { get; set; } = new List<Competitor>();

        // Constructor with optional file name to load data from
        public Competition(string fileName = null)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                LoadFromFile(fileName);
            }
        }

        // Method to add a competitor to the competition
        public void AddCompetitor(Competitor competitor)
        {
            if (CheckCompetitor(competitor.CompNumber))
            {
                Console.WriteLine("Error: Competitor already exists.");
                return;
            }
            Competitors.Add(competitor);
            Console.WriteLine("Competitor added successfully.");
        }

        // Overloaded method to create and add a competitor to the competition
        public void AddCompetitor(int compNumber, string compName, int compAge, string hometown, Result results, CompHistory history, BreastStroke compEvent)
        {
            Competitor competitor = new Competitor(compNumber, compName, compAge, hometown, results, history, compEvent);
            AddCompetitor(competitor);
        }

        // Method to check if a competitor exists in the competition
        public bool CheckCompetitor(int compNo)
        {
            return Competitors.Any(c => c.CompNumber == compNo);
        }

        // Method to clear all competitors from the competition
        public void ClearAll()
        {
            Competitors.Clear();
        }

        // Method to delete a competitor from the competition
        public void DeleteCompetitor(int compNo)
        {
            Competitor competitor = Competitors.FirstOrDefault(c => c.CompNumber == compNo);
            if (competitor != null)
            {
                Competitors.Remove(competitor);
                Console.WriteLine($"Competitor {compNo} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Competitor {compNo} not found.");
            }
        }

        // Method to get all competitors by event number
        public void GetAllByEvent(int eventNumber)
        {
            bool found = false;

            foreach (Competitor competitor in Competitors)
            {
                if (competitor.CompEvent != null && competitor.CompEvent.EventNo == eventNumber)
                {
                    if (!found)
                    {
                        Console.WriteLine($"Event Number: {competitor.CompEvent.EventNo}");
                        Console.WriteLine($"Venue: {competitor.CompEvent.Venue}");
                        Console.WriteLine($"Venue ID: {competitor.CompEvent.VenueID}");
                        Console.WriteLine($"Date and Time: {competitor.CompEvent.EventDateTime}");
                        Console.WriteLine($"Record: {competitor.CompEvent.Record}");
                        Console.WriteLine();
                        found = true;
                    }

                    Console.WriteLine($"Competitor {competitor.CompNumber}: {competitor.CompName}");
                    Console.WriteLine($"Age: {competitor.CompAge}");
                    Console.WriteLine($"Hometown: {competitor.Hometown}");
                    Console.WriteLine($"Race Time: {competitor.Results?.RaceTime} seconds");
                    Console.WriteLine();
                }
            }

            if (!found)
            {
                Console.WriteLine($"Event with number {eventNumber} not found.");
            }
        }

        // Method to get an event by its number
        public BreastStroke GetEvent(int eventNo, BreastStroke eventObj)
        {
            foreach (Competitor competitor in Competitors)
            {
                if (competitor.CompEvent is BreastStroke bsEvent && bsEvent.EventNo == eventNo)
                {
                    return bsEvent;
                }
            }

            if (eventObj != null && eventObj.EventNo == eventNo)
            {
                return eventObj;
            }

            return null;
        }

        // Method to load competitors from a file
        public void LoadFromFile(string fileName)
        {
            try
            {
                Console.WriteLine($"Loading data from file: {fileName}");

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                ClearAll();

                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Reading line: {line}");
                        string[] data = line.Split(new string[] { ", " }, StringSplitOptions.None);

                        if (data.Length < 18)
                        {
                            Console.WriteLine("Invalid data format in file.");
                            continue;
                        }

                        int compNumber = int.Parse(data[0].Split(':')[1].Trim());
                        string compName = data[1].Split(':')[1].Trim();
                        int compAge = int.Parse(data[2].Split(':')[1].Trim());
                        string hometown = data[3].Split(':')[1].Trim();
                        int eventNo = int.Parse(data[4].Split(':')[1].Trim());
                        string venue = data[5].Split(':')[1].Trim();
                        string eventDate = data[6].Split(':')[1].Trim();
                        double record = double.Parse(data[7].Split(':')[1].Trim());
                        string eventType = data[8].Split(':')[1].Trim();
                        int distance = int.Parse(data[9].Split(':')[1].Trim());
                        double winningTime = double.Parse(data[10].Split(':')[1].Trim());
                        bool newRecord = bool.Parse(data[11].Split(':')[1].Trim());
                        int placed = int.Parse(data[12].Split(':')[1].Trim());
                        double raceTime = double.Parse(data[13].Split(':')[1].Trim());
                        bool qualified = bool.Parse(data[14].Split(':')[1].Trim());
                        int careerWins = int.Parse(data[15].Split(':')[1].Trim());
                        double personalBest = double.Parse(data[16].Split(':')[1].Trim());
                        List<string> medals = data[17].Split(':')[1].Trim().Split(',').Select(m => m.Trim()).ToList();

                        Result result = new Result(placed, raceTime);
                        CompHistory history = new CompHistory("", careerWins, medals, personalBest);
                        BreastStroke compEvent = new BreastStroke(eventNo, venue, eventDate, record, eventType, distance, winningTime);

                        AddCompetitor(compNumber, compName, compAge, hometown, result, history, compEvent);
                    }
                }

                Console.WriteLine("Data loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data from file: {ex.Message}");
            }
        }

        // Method to save competitors to a file
        public void SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (var competitor in Competitors)
                    {
                        string line = competitor.ToFile();
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to file: {ex.Message}");
            }
        }

        // Method to create an index of competitors by their competitor number and event number
        public Dictionary<string, Competitor> CompIndex()
        {
            Dictionary<string, Competitor> compIndex = new Dictionary<string, Competitor>();

            foreach (Competitor competitor in Competitors)
            {
                if (competitor.CompEvent != null)
                {
                    string key = $"Competitor {competitor.CompNumber}, Event {competitor.CompEvent.EventNo}";
                    compIndex[key] = competitor;
                }
            }

            foreach (var kvp in compIndex)
            {
                string key = kvp.Key;
                Competitor competitor = kvp.Value;
                Console.WriteLine($"Competitor Index (Comp Number / Event Number)\n{key}");
            }

            return compIndex;
        }

        // Method to sort competitors by age (ascending)
        public void SortCompetitorsByAge()
        {
            Competitors.Sort((c1, c2) => c1.CompAge.CompareTo(c2.CompAge));
        }

        // Method to display competitors with career wins exceeding a target
        public void Winners(int target)
        {
            var qualifiedCompetitors = Competitors.Where(c => c.History != null && c.History.CareerWins > target);
            foreach (var competitor in qualifiedCompetitors)
            {
                Console.WriteLine(competitor);
            }
        }

        // Method to display race qualifiers sorted by race time
        public void GetQualifiers()
        {
            var qualifiers = Competitors.Where(c => c.Results != null && c.Results.Qualified);
            qualifiers = qualifiers.OrderBy(c => c.Results.RaceTime);

            foreach (var competitor in qualifiers)
            {
                Console.WriteLine($"Competitor {competitor.CompNumber}: RaceTime = {competitor.Results.RaceTime}");
            }
        }

        // Override ToString method to return a string representation of all competitors
        public override string ToString()
        {
            return string.Join(Environment.NewLine, Competitors);
        }

        // Method to generate file content representing all competitors
        public string ToFile()
        {
            var sb = new StringBuilder();
            foreach (var competitor in Competitors)
            {
                string competitorData = competitor.ToFile();
                sb.AppendLine(competitorData);
            }
            return sb.ToString();
        }
    }
}

