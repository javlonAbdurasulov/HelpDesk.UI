﻿namespace HelpDesk.Domain.Entity
{
    public class Letter
    {
  
        public int Id { get; set; }
        public Enum.Status Status { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Enum.Action ActionType { get; set; }
        public int FormaId { get; set; }
        public Forma Forma { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        

        public static Letter CreateLetter(Enum.Status status, string description,string title, Enum.Action actionType, int formaId)
        {
            var Letter = new Letter();
            Letter.Status   = status;
            Letter.Title= title;    
            Letter.ActionType = actionType;
            Letter.FormaId = formaId;
            return Letter;
        }
    }
}
