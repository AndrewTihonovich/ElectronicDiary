using ElectronicDiary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicDiary.DAL.TypeConfiguration
{
    class RecordTypeConfiguration : IEntityTypeConfiguration<Record>
    {
        private readonly string _tableName = "Record";

        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.ToTable(_tableName).HasKey(p => p.Id);
            builder.Property(p => p.Text).HasMaxLength(1000).IsRequired();
            builder.Property(p=>p.Theme).HasMaxLength(64).IsRequired();
        }
    }
}
