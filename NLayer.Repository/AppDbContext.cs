using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NLayer.Core;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryBorder> CountryBorders { get; set; }

        public override int SaveChanges()
        {
            foreach (EntityEntry item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }


                    }
                }


            }


            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (EntityEntry item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;

                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }


                    }
                }


            }









            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //        modelBuilder.Entity<CountryBorder>()
            //.Property(e => e.Names)
            //.HasConversion(
            //    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            //    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
            //    new ValueComparer<ICollection<string>>(
            //        (c1, c2) => c1.SequenceEqual(c2),
            //        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            //        c => (ICollection<string>)c.ToList()));

        }
    }
}
