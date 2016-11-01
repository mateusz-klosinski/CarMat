using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarMat.Models
{
    public class CMContext : IdentityDbContext<CMUser>
    {
        private IConfigurationRoot _config;


        public DbSet<Offer> Offers { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Demographics> Demographics { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleEquipment> VehicleEquipments { get; set; }
        public DbSet<VehicleVehicleEquipment> VehicleVehicleEquipment { get; set; }



        public CMContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:Database"]);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Offer>()
                .HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .IsRequired();

            modelBuilder.Entity<VehicleVehicleEquipment>()
                .HasKey(vve => new { vve.VehicleId, vve.EquipmentId });
        }

    }
}
