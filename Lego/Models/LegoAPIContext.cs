using Microsoft.EntityFrameworkCore;
namespace Lego.Models
{
    public class LegoAPIContext : DbContext
    {
        public LegoAPIContext(DbContextOptions<LegoAPIContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<UserBoughtLego> UBL { get; set; } = null!;
        public virtual DbSet<Target> Target { get; set; } = null!;
        public virtual DbSet<Collection> Collection { get; set; } = null!;
        public virtual DbSet<Constructor> Constructor { get; set; } = null!;

    }
}
