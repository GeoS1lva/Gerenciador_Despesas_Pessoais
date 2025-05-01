using GerenciadorDespesasPessoais.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDespesasPessoais.Infrastructure.Context
{
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : DbContext(options)
    {
        public DbSet<Despesas>? Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Despesas>()
                .Property(a => a.Tipo)
                .HasConversion<string>();

            modelBuilder.Entity<Despesas>()
                .Property(a => a.Parcelado)
                .HasConversion<string>();
        }
    }
}
