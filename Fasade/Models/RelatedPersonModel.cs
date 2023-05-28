using Fasade.Enum;

namespace Fasade.Models
{
    public class RelatedPersonModel
    {
        public PersonModel Person { get; set; }
        public int PersonId { get; set; }
        public PersonModel RelatedPerson { get; set; }
        public int RelatedPersonId { get; set; }
        public RelationType RelationType { get; set; }
    }
}
