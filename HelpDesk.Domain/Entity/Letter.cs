namespace HelpDesk.Domain.Entity
{
    public class Letter
    {
        private Letter( Enum.Status status, string description,string title, Enum.Action actionType)
        {
            Status = status;
            Description = description;
            Title = title;  
            ActionType = actionType;
        }

        public int Id { get; set; }
        public Enum.Status Status { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Enum.Action ActionType { get; set; }
        public Forma Forma { get; set; }
        public User User { get; set; }


        public static (Letter, IEnumerable<string>) CreateLetter(Enum.Status status, string description,string title, Enum.Action actionType)
        {
            IEnumerable<string> errors = new List<string>();
            var Letter = new Letter(status,description,title,actionType);
            return (Letter, errors);
        }
    }
}
