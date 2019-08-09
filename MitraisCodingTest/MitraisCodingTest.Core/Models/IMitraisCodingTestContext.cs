using System.Data.Entity;

namespace MitraisCodingTest.Core.Models
{
    public interface IMitraisCodingTestContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
