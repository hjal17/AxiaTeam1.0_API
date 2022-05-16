using AxiaTeam1._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxiaTeam1._0.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TTache> Taches { get; set; }
        public DbSet<UserStory> UserStorys { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TacheAFait> tacheAFaits { get; set; }
        public DbSet<EmployeeEquipe> employeeEquipes  { get; set; }
        public DbSet<Equipe> equipes { get; set; }

        public DbSet<BackLog> BackLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User>(entity => { entity.HasIndex(e => e.Email).IsUnique(); });

            modelBuilder.Entity<UserStory>().HasOne(u => u.BackLog).WithMany(b => b.UserStory);
            modelBuilder.Entity<TacheAFait>().HasOne(t => t.User).WithMany(u => u.tacheAFait);

            modelBuilder.Entity<TTache>().HasOne(t => t.UserStory).WithMany(u => u.Taches);

            modelBuilder.Entity<Project>().HasOne(p => p.User).WithMany(u => u.Projects);
            modelBuilder.Entity<Project>().HasOne(p => p.Client).WithMany(c => c.Projects);

            //Relation equipe-developpeur
            modelBuilder.Entity<EmployeeEquipe>().HasKey(Ee => new { Ee.userId, Ee.EquipeId });
            modelBuilder.Entity<EmployeeEquipe>().HasOne(Ee => Ee.user).WithMany(u => u.employeeEquipes).HasForeignKey(Ee => Ee.userId);
            modelBuilder.Entity<EmployeeEquipe>().HasOne(Ee => Ee.equipe).WithMany(e => e.employeeEquipes).HasForeignKey(Ee => Ee.EquipeId);
        }
    }
}
