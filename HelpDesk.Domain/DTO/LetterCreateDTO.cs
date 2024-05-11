using HelpDesk.Domain.Entity;
using HelpDesk.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.DTO
{
    public class LetterCreateDTO
    {
        public Status Status { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Enum.Action Name { get; set; }
        public Forma Forma { get; set; }
        public User User { get; set; }
    }
}
