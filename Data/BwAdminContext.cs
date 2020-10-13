﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BwAdminContext : DbContext
    {
        public BwAdminContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Offer> Offers { get; set; }
        

        #region ModelBuilding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserEntity
            var user = modelBuilder.Entity<User>();

            user.HasOne(x => x.UserInfo)
                .WithOne();

            user.HasMany(c => c.Clients)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);
            #endregion

            #region ClientEntity
            var client = modelBuilder.Entity<Client>();

            client.HasOne(c => c.Info)
                .WithOne();

            client.HasMany(c => c.Offers)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);

            client.HasMany(c => c.Invoices)
                .WithOne(i => i.Client)
                .HasForeignKey(i => i.ClientId);
            #endregion

            #region InvoiceEntity
            var invoice = modelBuilder.Entity<Invoice>();

            invoice.HasOne(i => i.Offer)
                .WithOne(o => o.Invoice)
                .HasForeignKey<Offer>(o => o.InvoiceId);

            invoice.HasMany(i => i.ExtraWorkItem)
                .WithOne();
            #endregion

            #region OfferEntity
            var offer = modelBuilder.Entity<Offer>();

            offer.HasOne(o => o.Invoice)
                .WithOne(i => i.Offer)
                .HasForeignKey<Invoice>(i => i.OfferId);

            invoice.HasMany(i => i.ExtraWorkItem)
                .WithOne();
            #endregion

        }
        #endregion
    }
}
