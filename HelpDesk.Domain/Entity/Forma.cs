using HelpDesk.Domain.Enum;

namespace HelpDesk.Domain.Entity
{
    public class Forma
    {
        private Forma(string description, Texnika texnika,Korpus korpus,string kabinet)
        {
            Description=description;
            Texnika=texnika;
            Korpus=korpus;
            Kabinet=kabinet;
        }
        public int Id { get; }
        public DateTime DateTime { get; } = DateTime.Now; 
        public string? Description { get; }
        public Texnika Texnika { get; set; }
        public Korpus Korpus { get; set; }
        public string Kabinet { get; set; }
        public Letter Letter { get; set; }

        public static (Forma, IEnumerable<string>) CreateLetter(string description, Texnika texnika, Korpus korpus, string kabinet)
        {
            IEnumerable<string> errors = new List<string>();
            var newForma = new Forma( description,texnika, korpus, kabinet);
            return (newForma, errors);
        }

    }
}
