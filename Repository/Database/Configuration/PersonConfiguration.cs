using Fasade.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database.Configuration
{
    internal class PersonConfiguration
    {
        internal static void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonDTO>(person =>
            {
                person.HasKey(p => p.ID);
                person.Property(p => p.ID).ValueGeneratedOnAdd();

                person.Property(p => p.FirstName).IsRequired().HasMaxLength(50);

                person.Property(p => p.LastName).IsRequired().HasMaxLength(50);

                person.Property(p => p.IdNumber).IsRequired().HasMaxLength(11);

                person.Property(p => p.BirthDate).IsRequired();

                person.Property(p => p.PhoneNumber).HasMaxLength(50);
            });
        }
    }
}
