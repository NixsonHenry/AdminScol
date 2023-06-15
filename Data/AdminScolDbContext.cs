using AdminScol.Models;
using Microsoft.EntityFrameworkCore;

public class AdminScolDbContext : DbContext
{
    public AdminScolDbContext(DbContextOptions<AdminScolDbContext> options) : base(options)
    {
    }

    public DbSet<AnneeAcademique> AnneeAcademiques { get; set; }
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Cour> Cours { get; set; }
    //public DbSet<Professeur> Professeurs { get; set; }
    //public DbSet<Heure> Heures { get; set; }
    //public DbSet<Jour> Jours { get; set; }
    public DbSet<Etudiant> Etudiants { get; set; }
    //public DbSet<Professeur> Professeurs { get; set; }
    //public DbSet<Heure> Heures { get; set; }
    //public DbSet<Jour> Jours { get; set; }
    //public DbSet<CourEtudiant> CourEtudiants { get; set; }
}
