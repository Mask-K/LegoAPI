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
        public virtual DbSet<UserBoughtLego> UBLs { get; set; } = null!;
        public virtual DbSet<Target> Targets { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<Constructor> Constructors { get; set; } = null!;

    }
}
