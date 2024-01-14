using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FIT_Api_Examples.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Opstina> Opstina { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Ispit> Ispit { get; set; }
        public DbSet<PrijavaIspita> PrijavaIspita{ get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken{ get; set; }
        public DbSet<Nastavnik> Nastavnik{ get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog{ get; set; }
        public DbSet<Obavijest> Obavijest{ get; set; }
        public DbSet<AkademskaGodina> AkademskaGodina { get; set; }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ovdje pise FluentAPI konfiguraciju

            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Nastavnik>().ToTable("Nastavnik");
        }
    }
}
