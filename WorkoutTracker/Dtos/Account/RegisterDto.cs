using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }


        [Phone]
        public string PhoneNumber { get; set; }

        public int height_cm { get; set; }
        public decimal weight_kg { get; set; }

    }
}
