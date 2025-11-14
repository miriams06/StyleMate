using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using StyleMateAPI.Models;

namespace StyleMateAPI.Data
=======
using StyleMate1._1.Models;

namespace StyleMate1._1.Data
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class StyleMateContext : DbContext
    {
        public StyleMateContext(DbContextOptions<StyleMateContext> options) : base(options) { }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Roupa> Roupas { get; set; }
        public DbSet<Conjunto> Conjuntos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mala> Malas { get; set; }

        public DbSet<ConjuntoRoupa> ConjuntoRoupas { get; set; }
        public DbSet<MalaConjunto> MalaConjuntos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === ConjuntoRoupa (Conjunto ↔ Roupa) ===
            modelBuilder.Entity<ConjuntoRoupa>()
                .HasKey(cr => new { cr.IdConjunto, cr.IdRoupa });

            modelBuilder.Entity<ConjuntoRoupa>()
                .HasOne(cr => cr.Conjunto)
                .WithMany(c => c.ConjuntosRoupas)
                .HasForeignKey(cr => cr.IdConjunto)
                .OnDelete(DeleteBehavior.Cascade); // Apaga as relações se o conjunto for apagado

            modelBuilder.Entity<ConjuntoRoupa>()
                .HasOne(cr => cr.Roupa)
                .WithMany()
                .HasForeignKey(cr => cr.IdRoupa)
                .OnDelete(DeleteBehavior.Cascade); // Apaga as relações se a roupa for apagada

            // === MalaConjunto (Mala ↔ Conjunto) ===
            modelBuilder.Entity<MalaConjunto>()
                .HasKey(mc => new { mc.IdMala, mc.IdConjunto });

            modelBuilder.Entity<MalaConjunto>()
                .HasOne(mc => mc.Mala)
                .WithMany(m => m.MalaConjuntos)
                .HasForeignKey(mc => mc.IdMala)
                .OnDelete(DeleteBehavior.Cascade); // Apaga as relações se a mala for apagada

            modelBuilder.Entity<MalaConjunto>()
                .HasOne(mc => mc.Conjunto)
                .WithMany()
                .HasForeignKey(mc => mc.IdConjunto)
                .OnDelete(DeleteBehavior.Restrict); // Evita ciclo com ConjuntoRoupa
        }
    }
}
