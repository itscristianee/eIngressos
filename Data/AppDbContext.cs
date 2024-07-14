using eIngressos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eIngressos.Data
{
    public class AppDbContext : IdentityDbContext<UsersApp>
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<ActedIn> ActedIns { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Theaters> Theaters { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<UserTickets> UserTickets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActedIn>().HasKey(ai => new { ai.MovieId, ai.ActorId });

            modelBuilder.Entity<ActedIn>()
                .HasOne(ai => ai.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ai => ai.MovieId);

            modelBuilder.Entity<ActedIn>()
                .HasOne(ai => ai.Actor)
                .WithMany(a => a.ActedIns)
                .HasForeignKey(ai => ai.ActorId);

            modelBuilder.Entity<UserTickets>()
                .HasKey(ut => new { ut.Name, ut.TicketId });

            modelBuilder.Entity<UserTickets>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTickets)
                .HasForeignKey(ut => ut.Name);

            modelBuilder.Entity<UserTickets>()
                .HasOne(ut => ut.Ticket)
                .WithMany(t => t.UserTickets)
                .HasForeignKey(ut => ut.TicketId);///

            modelBuilder.Entity<Movies>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)");  // Adjust precision and scale as needed

            modelBuilder.Entity<Tickets>()
                .Property(t => t.Total)
                .HasColumnType("decimal(18,2)");  // Adjust precision and scale as needed
        }
    }
}
