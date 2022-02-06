using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jogging_Tracker.Models
{
    public class JoggingRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } //ForeignKey
        public DateTime Date { get; set; }
        
        [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double DurationInSeconds { get; set; }
        
        [Range(1, double.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double DistanceInMeters { get; set; }
    }
}
