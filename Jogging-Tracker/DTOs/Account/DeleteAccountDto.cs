using System.ComponentModel.DataAnnotations;

namespace Jogging_Tracker.DTOs.Account
{
    public class DeleteAccountDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }
    }
}