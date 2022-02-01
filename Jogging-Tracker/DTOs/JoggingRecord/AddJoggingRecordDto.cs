using System;
using System.ComponentModel.DataAnnotations;

namespace Jogging_Tracker.DTOs.JoggingRecord
{
    public class AddJoggingRecordDto
    {
        [Required(ErrorMessage = "Date of jogging record is required")]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "Duration in seconds of jogging record is required")]
        public double DurationInSeconds { get; set; }
        
        [Required(ErrorMessage = "Distance in meters of jogging record is required")]
        public double DistanceInMeters { get; set; }
    }
}
