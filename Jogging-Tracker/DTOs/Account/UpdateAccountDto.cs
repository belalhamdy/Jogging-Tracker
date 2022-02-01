using System.ComponentModel.DataAnnotations;

namespace Jogging_Tracker.DTOs.Account
{
    public class UpdateAccountDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}