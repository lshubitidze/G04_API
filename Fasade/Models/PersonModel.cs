using Fasade.Enum;

namespace Fasade.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public string IdNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public CityModel City { get; set; } = null!;
        public PhoneType PhoneType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public ICollection<RelatedPersonModel>? RelatedPeople { get; set; }
        public ICollection<RelatedPersonModel>? RelatedPeopleOf { get; set; }
    }
}
