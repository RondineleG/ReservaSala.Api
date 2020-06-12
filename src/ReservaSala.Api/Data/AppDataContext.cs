using Microsoft.EntityFrameworkCore;
using ReservaSala.Api.Models;

namespace ReservaSala.Api.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext (DbContextOptions<AppDataContext> options): base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Bloco> Bloco { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        
    }
}
