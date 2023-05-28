using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Database.Configuration;

namespace Repository.Database
{
    public class TBCDbContext : DbContext
    {
        public TBCDbContext(DbContextOptions<TBCDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurModels();
        }

        public DbSet<PersonDTO> Poersons { get; set; }
        public DbSet<RelatedPersonDTO> RelatedPeople { get; set; }
        public DbSet<CityDTO> Cities { get; set; }
        public DbSet<UserDTO> Users { get; set; }
    }
}
