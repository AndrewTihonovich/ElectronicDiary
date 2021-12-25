using ElectronicDiary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicDiary.DAL.TypeConfiguration
{
    class TimeLabelTypeConfiguration : IEntityTypeConfiguration<TimeLabel>
    {
        private readonly string _tableName = "TimeLabel";

        public void Configure(EntityTypeBuilder<TimeLabel> builder)
        {
            builder.ToTable(_tableName);
            builder.HasNoKey();
        }
    }
}
