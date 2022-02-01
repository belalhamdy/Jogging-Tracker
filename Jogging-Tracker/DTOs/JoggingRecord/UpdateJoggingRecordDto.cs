using System;

namespace Jogging_Tracker.DTOs.JoggingRecord
{
    public class UpdateJoggingRecordDto
    {
        public int RecordId { get; set; }
        public DateTime Date { get; set; }
        public double DurationInSeconds { get; set; }
        public double DistanceInMeters { get; set; }
    }
}
