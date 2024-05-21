using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment
{
    public class MenuInterface
    {
        private Competition competition;

        // Constructor to initialize the competition and load data from a file
        public MenuInterface()
        {
            competition = new Competition();
            LoadFromFile();
        }

        // Method to display the main menu and handle user choices
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Competition Management System");
                Console.WriteLine("1. Add Competitor");
                Console.WriteLine("2. Delete Competitor");
                Console.WriteLine("3. Clear All Competitors");
                Console.WriteLine("4. Print Competitors");
                Console.WriteLine("5. Get All by Event");
                Console.WriteLine("6. Load from File");
                Console.WriteLine("7. Save to File");
                Console.WriteLine("8. Competitor Index");
                Console.WriteLine("9. Sort Competitors by Age");
                Console.WriteLine("10. Winners");
                Console.WriteLine("11. Get Qualifiers");
                Console.WriteLine("12. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Switch statement to handle user choice
                switch (choice)
                {
                    case "1":
                        AddCompetitor();
                        break;
                    case "2":
                        DeleteCompetitor();
                        break;
                    case "3":
                        ClearAll();
                        break;
                    case "4":
                        PrintCompetitors();
                        break;
                    case "5":
                        GetAllByEvent();
                        break;
                    case "6":
                        LoadFromFile();
                        break;
                    case "7":
                        SaveToFile();
                        break;
                    case "8":
                        DisplayCompetitorIndex();
                        break;
                    case "9":
                        SortCompetitorsByAge();
                        break;
                    case "10":
                        DisplayWinners();
                        break;
                    case "11":
                        DisplayQualifiers();
                        break;
                    case "12":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }

        // Method to add a new competitor
        private void AddCompetitor()
        {
            int compNumber;
            while (true)
            {
                Console.Write("Enter Competitor Number (100-999): ");
                if (int.TryParse(Console.ReadLine(), out compNumber) && compNumber >= 100 && compNumber <= 999)
                {
                    if (competition.CheckCompetitor(compNumber))
                    {
                        Console.WriteLine("Competitor already exists.");
                        return;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Competitor number must be a number between 100 and 999.");
                }
            }

            // Get competitor's name
            Console.Write("Enter Competitor Name: ");
            string compName = Console.ReadLine();

            // Get competitor's age
            int compAge;
            while (true)
            {
                Console.Write("Enter Competitor Age (positive integer): ");
                if (int.TryParse(Console.ReadLine(), out compAge) && compAge > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Competitor age must be a positive integer.");
                }
            }

            // Get competitor's hometown
            Console.Write("Enter Hometown: ");
            string hometown = Console.ReadLine();

            // Get event number
            int eventNo;
            while (true)
            {
                Console.Write("Enter Event Number (positive integer): ");
                if (int.TryParse(Console.ReadLine(), out eventNo) && eventNo > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Event number must be a positive integer.");
                }
            }

            // Check if event already exists
            BreastStroke eventObj = competition.GetEvent(eventNo, null);
            if (eventObj == null)
            {
                // Get event details if it doesn't exist
                Console.Write("Enter Event Type: ");
                string eventType = Console.ReadLine();

                int distance;
                while (true)
                {
                    Console.Write("Enter Distance (50-1500 meters): ");
                    if (int.TryParse(Console.ReadLine(), out distance) && distance >= 50 && distance <= 1500)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Distance must be between 50 and 1500 meters.");
                    }
                }

                double winningTime;
                while (true)
                {
                    Console.Write("Enter Winning Time (positive number): ");
                    if (double.TryParse(Console.ReadLine(), out winningTime) && winningTime > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Winning time must be a positive number.");
                    }
                }

                double record;
                while (true)
                {
                    Console.Write("Enter Record (positive number): ");
                    if (double.TryParse(Console.ReadLine(), out record) && record > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Record must be a positive number.");
                    }
                }

                Console.Write("Enter Venue (name or ID): ");
                string venueInput = Console.ReadLine();
                if (int.TryParse(venueInput, out int venueID))
                {
                    eventObj = new BreastStroke(eventNo, venueID, DateTime.Now.ToString(), record, eventType, distance, winningTime);
                }
                else
                {
                    eventObj = new BreastStroke(eventNo, venueInput, DateTime.Now.ToString(), record, eventType, distance, winningTime);
                }
            }

            // Get placement
            int placed;
            while (true)
            {
                Console.Write("Enter Placement (1-8): ");
                if (int.TryParse(Console.ReadLine(), out placed) && placed >= 1 && placed <= 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Placement must be between 1 and 8.");
                }
            }

            // Get race time
            double raceTime;
            while (true)
            {
                Console.Write("Enter Race Time (positive number): ");
                if (double.TryParse(Console.ReadLine(), out raceTime) && raceTime > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Race time must be a positive number.");
                }
            }

            bool qualified = placed <= 3;

            // Get personal best
            double personalBest;
            while (true)
            {
                Console.Write("Enter Personal Best (positive number): ");
                if (double.TryParse(Console.ReadLine(), out personalBest) && personalBest > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Personal best must be a positive number.");
                }
            }

            // Get career wins
            int careerWins;
            while (true)
            {
                Console.Write("Enter Career Wins (non-negative integer): ");
                if (int.TryParse(Console.ReadLine(), out careerWins) && careerWins >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Career wins must be a non-negative integer.");
                }
            }

            // Get medals
            Console.Write("Enter Medals (comma-separated, e.g., Gold,Silver,Bronze): ");
            string medalsInput = Console.ReadLine();
            List<string> medals = medalsInput.Split(',').Select(m => m.Trim()).ToList();

            // Create result and history objects
            Result result = new Result(placed, raceTime);
            CompHistory history = new CompHistory("", careerWins, medals, personalBest);

            // Create competitor object and add to competition
            Competitor competitor = new Competitor(compNumber, compName, compAge, hometown, result, history, eventObj);
            competition.AddCompetitor(competitor);
            Console.WriteLine("Competitor added successfully.");
        }

        // Method to delete a competitor by their number
        private void DeleteCompetitor()
        {
            Console.Write("Enter Competitor Number to delete: ");
            int compNumber = int.Parse(Console.ReadLine());

            competition.DeleteCompetitor(compNumber);
        }

        // Method to clear all competitors
        private void ClearAll()
        {
            competition.ClearAll();
            Console.WriteLine("All competitors have been cleared.");
        }

        // Method to print all competitors
        private void PrintCompetitors()
        {
            Console.WriteLine(competition.ToString());
        }

        // Method to get all competitors by event number
        private void GetAllByEvent()
        {
            Console.Write("Enter Event Number: ");
            int eventNo = int.Parse(Console.ReadLine());

            competition.GetAllByEvent(eventNo);
        }

        // Method to load competitors from a file
        private void LoadFromFile()
        {
            Console.Write("Enter filename to load: ");
            string fileName = Console.ReadLine();

            competition.LoadFromFile(fileName);
        }

        // Method to save competitors to a file
        private void SaveToFile()
        {
            Console.Write("Enter filename to save: ");
            string fileName = Console.ReadLine();

            competition.SaveToFile(fileName);
        }

        // Method to display competitor index
        private void DisplayCompetitorIndex()
        {
            competition.CompIndex();
        }

        // Method to sort competitors by age
        private void SortCompetitorsByAge()
        {
            competition.SortCompetitorsByAge();
            Console.WriteLine("Competitors sorted by age.");
        }

        // Method to display competitors with career wins exceeding a target
        private void DisplayWinners()
        {
            Console.Write("Enter target number of career wins: ");
            int target = int.Parse(Console.ReadLine());

            competition.Winners(target);
        }

        // Method to display race qualifiers sorted by race time
        private void DisplayQualifiers()
        {
            competition.GetQualifiers();
        }
    }
}

