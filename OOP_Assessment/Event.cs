using System;

namespace OOP_Assessment
{
    public abstract class Event
    {
        protected int eventNo;           // Unique identifier for the event
        protected object venue;          // Location where the event takes place (string or int)
        protected string eventDateTime;  // Date and time of the event
        protected double record;         // Record for the event (e.g., winning time)

        public int EventNo
        {
            get { return eventNo; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Event number must be between 1 and 100.");
                }
                eventNo = value;
            }
        }

        public string Venue
        {
            get { return venue as string; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Venue name cannot be null or empty.");
                }
                venue = value;
            }
        }

        public int VenueID
        {
            get { return venue is int ? (int)venue : -1; }
            private set { venue = value; }
        }

        public string EventDateTime
        {
            get { return eventDateTime; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Event date and time cannot be null or empty.");
                }
                eventDateTime = value;
            }
        }

        public double Record
        {
            get { return record; }
            set { record = value; }
        }

        // Method to set the venue as a string
        public void SetVenue(string venue)
        {
            Venue = venue;
        }

        // Method to set the venue as an integer
        public void SetVenue(int venueID)
        {
            VenueID = venueID;
        }
    }
}
