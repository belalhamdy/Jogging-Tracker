using System.ComponentModel.DataAnnotations;

namespace Jogging_Tracker.DTOs.Account
{
    public class GetAccountDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }
    }
}