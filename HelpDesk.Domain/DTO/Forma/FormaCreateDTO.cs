using HelpDesk.Domain.Enum;

namespace HelpDesk.Domain.DTO.Forma
{
    public class FormaCreateDTO
    {
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public Texnika Texnika { get; set; }
        public Korpus Korpus { get; set; }
        public string Kabinet { get; set; }
    }
}
