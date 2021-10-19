using System;
using ConferenceSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RatingSystem.Models;

#nullable disable

namespace RatingSystem.Data
{
    public partial class SuggestionsDbContext : DbContext
    {
        public SuggestionsDbContext(DbContextOptions<SuggestionsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<ConferenceXAttendee> ConferenceXAttendee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Conference>(entity =>
            {
                entity.ToTable("Conference");
            });


            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
