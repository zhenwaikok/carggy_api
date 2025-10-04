using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;

namespace CarggyAPI.Models
{
    public partial class CarggyDBContext : DbContext
    {
        public CarggyDBContext() { }

        public CarggyDBContext(DbContextOptions<CarggyDBContext> options):base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<ServiceLog> ServiceLog { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=mydbinstance.cjebslyd6yl6.us-east-1.rds.amazonaws.com;Initial Catalog=assignmentrds;User ID=admin;Password=androidadmin123;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<User>( entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("userID");
                entity.Property(e => e.Username).HasColumnName("username").HasMaxLength(100);
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.EmailAddress).HasColumnName("emailAddress").HasMaxLength(100);
                entity.Property(e => e.ImageURL).HasColumnName("imageURL").HasColumnType("nvarchar(max)");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            });

            modelBuilder.Entity<Vehicle>( entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasKey(e => e.VehicleId);
                entity.Property(e => e.VehicleId).HasColumnName("vehicleId").ValueGeneratedOnAdd();
                entity.Property(e => e.VehicleName).HasColumnName("vehicleName").HasMaxLength(50);
                entity.Property(e => e.VehicleType).HasColumnName("vehicleType");
                entity.Property(e => e.VehicleBrand).HasColumnName("vehicleBrand").HasMaxLength(50);
                entity.Property(e => e.PlateNo).HasColumnName("plateNo").HasMaxLength(50);
                entity.Property(e => e.Year).HasColumnName("year").HasMaxLength(20);
                entity.Property(e => e.VehicleImageURL).HasColumnName("vehicleImageURL").HasColumnType("nvarchar(max)");
                entity.Property(e => e.UserId).HasColumnName("userId");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            });

            modelBuilder.Entity<ServiceLog>(entity =>
            {
                entity.ToTable("ServiceLog");

                entity.HasKey(e => e.ServiceLogId);
                entity.Property(e => e.ServiceLogId).HasColumnName("serviceLogId").ValueGeneratedOnAdd();
                entity.Property(e => e.ServiceName).HasColumnName("serviceName").HasMaxLength(50);
                entity.Property(e => e.ServiceType).HasColumnName("serviceType");
                entity.Property(e => e.ServiceDescription).HasColumnName("serviceDescription").HasMaxLength(100);
                entity.Property(e => e.ServiceDate).HasColumnName("serviceDate");
                entity.Property(e => e.ServicePrice).HasColumnName("servicePrice").HasMaxLength(20);
                entity.Property(e => e.ServiceImageURL).HasColumnName("serviceImageURL").HasColumnType("nvarchar(max)");
                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");
                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");
            });
        }
    }
}
