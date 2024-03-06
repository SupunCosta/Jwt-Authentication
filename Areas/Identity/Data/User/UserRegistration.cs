using System.ComponentModel.DataAnnotations;

namespace JwtAuthentication.Areas.Identity.Data.User
{
    public class UserRegistration
    {
        [EmailAddress]
        public string Email { get; set;}
        public string Password { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }


    }

    public class TimeSlots
    {
        public string STime { get; set; }
        public string ETime { get; set; }
        public bool IsError { get; set; }

    }

    public class obj
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsError { get; set; }
        public DateTime? E1 { get; set; }
        public DateTime? E2 { get; set; }

    }
}
