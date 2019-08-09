using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MitraisCodingTest.Core.Models
{
    public class MitraisCodingTestContext : DbContext, IMitraisCodingTestContext
    {
        public MitraisCodingTestContext() : base("MitraisCodingTestContext")
        {
        }

        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
