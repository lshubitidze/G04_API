using Fasade.DTO;
using Microsoft.EntityFrameworkCore;

namespace Repository.Database.Configuration
{
    internal static class UserConfiguration
    {
        internal static void ConfigureModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>(user =>
            {
                user.HasKey(u => u.ID);
                user.Property(u => u.ID).ValueGeneratedOnAdd();
                
                user.HasAlternateKey(u => u.UserName);
                user.Property(u => u.UserName).IsRequired();

                user.Property(u => u.Password).IsRequired();
                user.Property(u => u.Email).IsRequired();
                user.Property(u => u.CreatedDate).HasDefaultValueSql("getdate()");
            });
        }
    }
}
