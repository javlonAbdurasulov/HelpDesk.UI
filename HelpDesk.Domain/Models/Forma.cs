using HelpDesk.Domain.Enum;

namespace HelpDesk.Domain.Entity
{
    public class Forma
    {
        
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
		public string? Description { get; set; }
        public Texnika Texnika { get; set; }
        public Korpus Korpus { get; set; }
        public string Kabinet { get; set; }

        public static Forma CreateForma(string description, Texnika texnika, Korpus korpus, string kabinet)
        {
            var newForma = new Forma();
            newForma.Description = description;
            newForma.Korpus= korpus;    
            newForma.Texnika = texnika;
            newForma.Kabinet= kabinet;
            return newForma;
        }

    }
}
