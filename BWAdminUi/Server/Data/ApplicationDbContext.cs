using Data.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ClientEntity = Data.Entities.Client;

namespace BWAdminUi.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PersonInfo> PersonInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ClientEntity
            var client = modelBuilder.Entity<global::Data.Entities.Client>();

            client.HasOne(c => c.Info)
                .WithOne()
                .HasForeignKey<ClientEntity>(c => c.InfoId);

            client.HasMany(c => c.Offers)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);

            client.HasMany(c => c.Invoices)
                .WithOne(i => i.Client)
                .HasForeignKey(i => i.ClientId);

            #endregion


            #region UserEntity
            var user = modelBuilder.Entity<ApplicationUser>();
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


        }
    }
}
