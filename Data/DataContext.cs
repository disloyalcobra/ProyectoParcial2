using Microsoft.EntityFrameworkCore;
using ProyectoParcial2.Data.Entities;

namespace ProyectoParcial2.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
       public DbSet<PatientDisease>PatientDiseases { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
