using System.Text.RegularExpressions;

namespace HelpDesk.Domain.Entity
{
    public class User {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Letter Letter { get; set; }

        public static (User User, IEnumerable<string> Error) CreateUser(int id, string fullName, string phoneNumber, string email)
        {
            string patternForEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            IEnumerable<string> errors = new List<string>();
            Regex regex = new Regex(patternForEmail);

            if (!regex.IsMatch(email))
            {
                errors.Append("email did't confirmed\n");
            }

            var User = new User();
            User.Id = id;
            User.FullName = fullName;
            User.PhoneNumber = phoneNumber;
            User.Email = email;

            return (User, errors);
        }
    }
}
