using EntityFramework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Data
{
   public class TakmicenjeDbContext : DbContext
   {
      public DbSet<User> Users { get; set; }
      public DbSet<Skola> Skola { get; set; }
      public DbSet<Ucenik> Ucenici { get; set; }
      public DbSet<Tim> Timovi { get; set; }
      public DbSet<Clanovi> Clanovi { get; set; }
      public DbSet<Beleska> Beleske { get; set; }
      public DbSet<Takmicenje> Takmicenja { get; set; }
      public DbSet<PrijavaZaTakmicenje> PrijaveZaTakmicenje { get; set; }
      public DbSet<RasporedSedenja> RasporediSedenja { get; set; }
      public DbSet<Rezultati> Rezultati { get; set; }
      public string DbPath { get; set; }

      //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //{
      //   //var folder = Environment.SpecialFolder.LocalApplicationData;
      //   //var path = Environment.GetFolderPath(folder);
      //   //DbPath = System.IO.Path.Join(path, "TakmicenjeBaza.db");
      //   //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TakmicenjeBaza");
      //   optionsBuilder.UseSqlite("Data Source=Takmicenje.db");
      //   //optionsBuilder.UseSqlite("Filename=Takmicenje.db");

      //}
      protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Takmicenje.db");

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

        
            


      }
      







   }
}
