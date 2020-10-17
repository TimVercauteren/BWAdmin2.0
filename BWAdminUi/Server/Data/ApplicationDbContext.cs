using BWAdminUi.Server.Models;
using Data.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BWAdminUi.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<User> AppUsers { get; set; }
        public DbSet<global::Data.Entities.Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region UserEntity
            var user = modelBuilder.Entity<User>();

            user.HasOne(x => x.UserInfo)
                .WithOne();

            user.HasMany(c => c.Clients)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region ClientEntity
            var client = modelBuilder.Entity<global::Data.Entities.Client>();

            client.HasOne(c => c.Info)
                .WithOne()
                .HasForeignKey<global::Data.Entities.Client>(c => c.InfoId);

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
                .HasForeignKey<Offer>(o => o.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);


            invoice.HasMany(i => i.ExtraWorkItem)
                .WithOne()
                .HasForeignKey(wi => wi.InvoiceId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region OfferEntity
            var offer = modelBuilder.Entity<Offer>();

            offer.HasOne(o => o.Invoice)
                .WithOne(i => i.Offer)
                .HasForeignKey<Invoice>(i => i.OfferId)
                .OnDelete(DeleteBehavior.NoAction);


            offer.HasMany(o => o.WorkItems)
                .WithOne()
                .HasForeignKey(wi => wi.OfferId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region WorkItem

            

            #endregion

        }
    }
}
