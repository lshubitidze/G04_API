using Fasade.Enum;

namespace Fasade.DTO
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string IdNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public CityDTO City { get; set; } = null!;
        public PhoneType PhoneType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public ICollection<RelatedPersonDTO>? RelatedPeople { get; set; }
        public ICollection<RelatedPersonDTO>? RelatedPeopleOf { get; set; }
    }
}
