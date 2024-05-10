using HelpDesk.Domain.Enum;

namespace HelpDesk.Domain.Entity
{
	public class Forma
	{
        public int Id{ get; set; }
		public DateTime DateTime{ get; set; }
		public string? Description{ get; set; }
		public Texnika Texnika{ get; set; }
		public Korpus Korpus { get; set; }
		public string Kabinet { get; set; }
		public Letter Letter{ get; set; }
		

    }
}
