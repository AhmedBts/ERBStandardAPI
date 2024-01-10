using Domain;
using Domain.Common;
using Domain.Entities.Common;
using Domain.Entities.MainModule.Master;
using Domain.Entities.Views;
using Domain.Sales;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace Persistence
{
    public class HUB_Context:DbContext
    {
        public HUB_Context(DbContextOptions<HUB_Context> options) : base(options)
        {

        }
        #region
        public DbSet<Group> Groups { get; set; }
        public DbSet<PrgPer> PrgPer { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<GroupPermission> GroupPermission { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLog> UsersLog { get; set; }
        public DbSet<ActionTypeUser> ActionTypeUser { get; set; }
        #endregion
        public DbSet<Country> Countrys { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }

        public DbSet<GeneralSetup> GeneralSetups { get; set; }
        public DbSet<VerificationCode> VerificationCodes { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<M_850DocTypeSubLdgType> DocTypeSubLdgTypes { get; set; }
        public DbSet<SubLdgType> SubLdgType { get; set; }
        public DbSet<M_850FieldType> FieldTypes { get; set; }
        public DbSet<M_850DocType> DocType { get; set; }

        ////New 2024
        public DbSet<OrderH> OrderH { get; set; }
        public DbSet<OrderD> OrderD { get; set; }
     
        /////

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
       .HasIndex(u => u.Email)
       .IsUnique();
            modelBuilder.Entity<User>()
   .HasIndex(u => u.UserName)
   .IsUnique();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HUB_Context).Assembly);



        }
       
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreateDateAndTime = DateTime.Now;

            }
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.DateAndTime = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
