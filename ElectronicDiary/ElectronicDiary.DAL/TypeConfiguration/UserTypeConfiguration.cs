using ElectronicDiary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicDiary.DAL.TypeConfiguration
{
    class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly string _tableName = "User";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(_tableName).HasKey(p => p.Id);
            builder.Property(p => p.FirstName).HasMaxLength(32).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(32).IsRequired();
            builder.Property(p => p.Login).HasMaxLength(32).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(13);
            
            builder.HasOne(prop => prop.UserRole);

            builder.HasData(new User
            {
                Id = 1,
                FirstName = "admin",
                LastName= "admin",
                Login = "admin",
                Email = "admin@admin.com",
                Phone = "+398854526584",
                UserRoleId=1
            }); 
        }
    }
}
