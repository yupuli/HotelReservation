namespace HotelReservation.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FIT5032_Model : DbContext
    {
        public FIT5032_Model()
            : base("name=FIT5032_Model")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Customers)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotels>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Hotels)
                .HasForeignKey(e => e.HotelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owners>()
                .HasMany(e => e.Hotels)
                .WithRequired(e => e.Owners)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owners>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Owners)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);
        }
    }
}
