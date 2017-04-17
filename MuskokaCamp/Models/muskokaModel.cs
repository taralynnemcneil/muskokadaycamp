namespace MuskokaCamp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class muskokaModel : DbContext
    {
        public muskokaModel()
            : base("name=muskokaModel")
        {
        }

        public virtual DbSet<camperProfile> camperProfiles { get; set; }
        public virtual DbSet<gaurdian> gaurdians { get; set; }
        public virtual DbSet<payment> payments { get; set; }
        public virtual DbSet<registrationDate> registrationDates { get; set; }
        public virtual DbSet<staffLogin> staffLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<camperProfile>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.familyName)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.rate)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.contactName)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.contactRelation)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.contactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .Property(e => e.importantNotes)
                .IsUnicode(false);

            modelBuilder.Entity<camperProfile>()
                .HasMany(e => e.payments)
                .WithRequired(e => e.camperProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<camperProfile>()
                .HasMany(e => e.registrationDates)
                .WithRequired(e => e.camperProfile)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<camperProfile>()
                .HasMany(e => e.gaurdians)
                .WithMany(e => e.camperProfiles)
                .Map(m => m.ToTable("camperGaurdian").MapLeftKey("camperID").MapRightKey("guardianID"));

            modelBuilder.Entity<gaurdian>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<gaurdian>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.amount)
                .IsUnicode(false);

            modelBuilder.Entity<payment>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<registrationDate>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<registrationDate>()
                .Property(e => e.signInTime)
                .IsUnicode(false);

            modelBuilder.Entity<registrationDate>()
                .Property(e => e.signOutTime)
                .IsUnicode(false);

            modelBuilder.Entity<registrationDate>()
                .Property(e => e.signedInBy)
                .IsUnicode(false);

            modelBuilder.Entity<registrationDate>()
                .Property(e => e.signedOutBy)
                .IsUnicode(false);

            modelBuilder.Entity<staffLogin>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<staffLogin>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<staffLogin>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
