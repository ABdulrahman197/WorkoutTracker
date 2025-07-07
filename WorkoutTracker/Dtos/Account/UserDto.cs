namespace WorkoutTracker.Dtos.Account
{
    public class UserDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string token { get; set; }

        public int height_cm { get; set; }
        public decimal weight_kg { get; set; }

    }
}
