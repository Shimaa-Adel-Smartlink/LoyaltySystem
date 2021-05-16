using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace LoyaltySystem.Business.Entities
{
   public class LoyaltyContext : DbContext
    {
        public LoyaltyContext(DbContextOptions<LoyaltyContext> options) : base(options)
        {
        }

        // Entites
        public DbSet<User> Users { get; set; }
        public DbSet<TransactionLog> transactionLogs { get; set; }
        public DbSet<Configuration> configurations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1-m relationship between User and TransactionLog (CreatedBy)

            modelBuilder.Entity<TransactionLog>()
                .HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.TransactionLogCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_TransactionLogs_CreatedByNavigation");

            //1-m relationship between User and TransactionLog(UpdatedBy)

            modelBuilder.Entity<TransactionLog>()
                .HasOne(d => d.UpdatedByNavigation)
                .WithMany(p => p.TransactionLogUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_TransactionLogs_UpdatedByNavigation");

            base.OnModelCreating(modelBuilder);

        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
