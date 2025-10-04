namespace CarggyAPI.Models
{
    public class User
    {
        public string? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public string? ImageURL { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
