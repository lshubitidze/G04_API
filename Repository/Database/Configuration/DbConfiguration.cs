using Microsoft.EntityFrameworkCore;

namespace Repository.Database.Configuration
{
    internal static class DbConfiguration
    {
        public static void ConfigurModels(this ModelBuilder modelBuilder)
        {
            PersonConfiguration.ConfigureModel(modelBuilder);
            RelatedPersonConfiguration.ConfigureModel(modelBuilder);
            CityConfiguration.ConfigureModel(modelBuilder);
            UserConfiguration.ConfigureModel(modelBuilder);
        }
    }
}
