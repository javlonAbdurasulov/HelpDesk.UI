using System.Text.RegularExpressions;

namespace HelpDesk.Domain.Entity
{
    public class User
    {
        private User(int id, string fullName, string phoneNumber, string email)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public int Id { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public Role Role { get; }
        public Letter Letter { get; }

        public static (User User, IEnumerable<string> Error) CreateUser(int id, string fullName, string phoneNumber, string email)
        {
            string patternForEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            IEnumerable<string> errors = new List<string>();
            Regex regex = new Regex(patternForEmail);

            if (!regex.IsMatch(email))
            {
                errors.Append("email did't confirmed\n");
            }

            var User = new User(id, fullName, phoneNumber, email);

            return (User, errors);
        }
    }
}
