using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;

namespace Superubezpieczenia.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(string connectionString) : base(GetOptions(connectionString))
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public virtual DbSet<PolicyDetails> PolicyDetails { get; set; }
        public virtual DbSet<EnginePower> EnginePowers { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MethodUse> MethodUses { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<TypeInsurance> TypeInsurance { get; set; }
        public virtual DbSet<TypeFuel> TypeFuels { get; set; }
        public virtual DbSet<TypeOwner> TypeOwners { get; set; }
        public virtual DbSet<Log> Loggers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
