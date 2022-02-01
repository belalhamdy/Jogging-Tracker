using System.ComponentModel.DataAnnotations;

namespace Jogging_Tracker.DTOs.JoggingRecord
{
    public class DeleteJoggingRecordDto
    {
        [Required(ErrorMessage = "Record ID is required")]
        public int RecordId { get; set; }
    }
}
