using Fasade.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database.Configuration
{
    internal class CityConfiguration
    {
        internal static void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDTO>(city =>
            {
                city.HasKey(c => c.ID);
                city.Property(c => c.ID).ValueGeneratedOnAdd();

                city.Property(c => c.CityName).IsRequired();
            });
        }
    }
}
