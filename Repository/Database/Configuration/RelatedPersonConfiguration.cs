using Fasade.DTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.Database.Configuration
{
    internal class RelatedPersonConfiguration
    {
        internal static void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelatedPersonDTO>(relatedPerson =>
            {
                relatedPerson.HasKey(rl => new { rl.PersonId, rl.RelatedPersonId });
                relatedPerson.HasOne(rl => rl.Person)
                             .WithMany(p => p.RelatedPeople)
                             .HasForeignKey(rl => rl.PersonId)
                             .OnDelete(DeleteBehavior.Restrict);

                relatedPerson.HasOne(rl => rl.RelatedPerson)
                             .WithMany(p => p.RelatedPeopleOf)
                             .HasForeignKey(rl => rl.RelatedPersonId)
                             .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
