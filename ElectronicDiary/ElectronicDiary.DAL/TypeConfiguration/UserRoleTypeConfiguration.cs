using ElectronicDiary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicDiary.DAL.TypeConfiguration
{
    class UserRoleTypeConfiguration: IEntityTypeConfiguration<UserRole>
    {
        private readonly string _tableName = "UserRole";

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(_tableName).HasKey(prop => prop.Id);

            builder.HasData(new UserRole
            {
                Id = 1,
                Role = "admin"
            });
        }
    }
}
