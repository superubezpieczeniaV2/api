using System;
using System.Collections.Generic;
using Superubezpieczenia.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Superubezpieczenia.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public virtual DbSet<PolicyDetails> PolicyDetails { get; set; }
        public virtual DbSet<EnginePower> EnginePowers { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<MethodUse> MethodUses { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<TypeFuel> TypeFuels { get; set; }
        public virtual DbSet<TypeOwner> TypeOwners { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
