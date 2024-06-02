using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace YTeAspMVC.Models
{
    public class YTeDBContext : DbContext
    {
        public YTeDBContext() : base("DBConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Schedules> Schedule { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Advise> Advises { get; set; }
        public DbSet<Doctors_Schedules> Doctors_Schedules { get; set; }
        public DbSet<DoctorSpecialistSchedules> DoctorSpecialistSchedules { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName + ": " + x.ErrorMessage));
                throw new DbEntityValidationException(errorMessages);
            }
        }
    }
}