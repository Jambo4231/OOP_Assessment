using System;

namespace OOP_Assessment
{
    public class BreastStroke : Event
    {
        private string eventType;
        private int distance;
        private double winningTime;
        private bool newRecord;

        public string EventType
        {
            get { return eventType; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Event type cannot be null or empty.");
                }
                eventType = value;
            }
        }

        public int Distance
        {
            get { return distance; }
            set
            {
                if (value < 50 || value > 1500)
                {
                    throw new ArgumentException("Distance must be between 50 and 1500 meters.");
                }
                distance = value;
            }
        }

        public double WinningTime
        {
            get { return winningTime; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Winning time must be greater than 0.");
                }
                winningTime = value;
            }
        }

        public bool NewRecord
        {
            get { return newRecord; }
            set { newRecord = value; }
        }

        public BreastStroke(int eventNo, string venue, string eventDateTime, double record, string eventType, int distance, double winningTime)
        {
            EventNo = eventNo;
            SetVenue(venue); // Use string venue setter
            EventDateTime = eventDateTime;
            Record = record;
            EventType = eventType;
            Distance = distance;
            WinningTime = winningTime;
            newRecord = IsNewRecord();
        }

        public BreastStroke(int eventNo, int venueID, string eventDateTime, double record, string eventType, int distance, double winningTime)
        {
            EventNo = eventNo;
            SetVenue(venueID); // Use int venue setter
            EventDateTime = eventDateTime;
            Record = record;
            EventType = eventType;
            Distance = distance;
            WinningTime = winningTime;
            newRecord = IsNewRecord();
        }

        public override string ToString()
        {
            return $"Event: {eventType}, Distance: {distance}m, Winner Time: {winningTime} seconds, Venue: {venue}";
        }

        public string ToFile()
        {
            return $"{EventNo},{venue},{EventDateTime},{Record},{EventType},{Distance},{WinningTime},{NewRecord}";
        }

        public bool IsNewRecord()
        {
            if (winningTime < Record)
            {
                Record = winningTime;
                return true;
            }
            return false;
        }
    }
}
