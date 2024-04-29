using Ing.Models;
using Microsoft.EntityFrameworkCore;

namespace Ing.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Filme>().HasKey(am => new
            {
                am.ActorId,
                am.FilmeId
            });
    
            modelBuilder.Entity<Actor_Filme>().HasOne(m => m.Filmes).WithMany(am => am.Actores_Filmes).HasForeignKey(m => m.FilmeId);
            modelBuilder.Entity<Actor_Filme>().HasOne(m => m.Actor).WithMany(am => am.Actores_Filmes).HasForeignKey(m => m.ActorId);
    
            base.OnModelCreating(modelBuilder);
        }
		
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Actor_Filme> Actores_Filmes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
    }
}
