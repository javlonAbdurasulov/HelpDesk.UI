using HelpDesk.Domain.Entity;
using HelpDesk.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.DTO.Letter
{
    public class LetterCreateDTO
    {
        public string Title { get; set; }
        public int UserId { get; set; }

		//Forma
		public string? DescriptionForm { get; set; }
		public Texnika TexnikaForm { get; set; }
		public Korpus KorpusForm { get; set; }
		public string KabinetForm { get; set; }
	}
}
