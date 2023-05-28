using Fasade.Enum;

namespace Fasade.DTO
{
    public class RelatedPersonDTO
    {
        public PersonDTO Person { get; set; }
        public int PersonId { get; set; }
        public PersonDTO RelatedPerson { get; set; }
        public int RelatedPersonId { get; set; }
        public RelationType RelationType { get; set; }
    }
}
