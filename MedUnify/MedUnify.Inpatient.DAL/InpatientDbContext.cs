using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.SharedModel.Settings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MedUnify.Inpatient.DAL
{
    public class InpatientDbContext : DbContext
    {
        private readonly EntityConnections entityConnections;

        public InpatientDbContext(EntityConnections entityConnections)
        {
            this.entityConnections = entityConnections;
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProgressNote> ProgressNotes { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(entityConnections.ConnectionString);
        }
    }
}
