using ElectronicDiary.DAL.Models;
using ElectronicDiary.DAL.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicDiary.DAL
{
    public class ElectronicDiaryDbContext : DbContext, IElectronicDiaryDbContext
    {
        public ElectronicDiaryDbContext Context { get => this; }

        public DbSet<Record> Records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-E8CJAOH\\SQLEXPRESS; DataBase=ElectricDiary;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordTypeConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeLebel();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            AddTimeLebel();
            return base.SaveChanges();
        }

        private void AddTimeLebel()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is TimeLabel && (item.State == EntityState.Added || item.State == EntityState.Modified))
                {
                    if (item.State == EntityState.Added)
                    {
                        ((TimeLabel)item.Entity).WasCreated = DateTime.Now;
                    }
                    if (item.State == EntityState.Modified)
                    {
                        ((TimeLabel)item.Entity).WasModifyed = DateTime.Now;
                    }
                }
            }
        }
    }
}
