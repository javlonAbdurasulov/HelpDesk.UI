using HelpDesk.Domain.Enum;

namespace HelpDesk.Domain.Entity
{
    public class Forma
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now; 
        public string? Description { get; set; }
        public Texnika Texnika { get; set; }
        public Korpus Korpus { get; set; }
        public string Kabinet { get; set; }
        public Letter Letter { get; set; }

        public static (Forma, IEnumerable<string>) CreateForma(string description, Texnika texnika, Korpus korpus, string kabinet)
        {
            IEnumerable<string> errors = new List<string>();
            var newForma = new Forma();
            newForma.Description = description;
            newForma.Korpus= korpus;    
            newForma.Texnika = texnika;
            newForma.Kabinet= kabinet;
            return (newForma, errors);
        }

    }
}
