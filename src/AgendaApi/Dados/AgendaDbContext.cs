using AgendaApi.Agendamentos;
using AgendaApi.Profissionais;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Dados;

public class AgendaDbContext(DbContextOptions<AgendaDbContext> options) : DbContext(options)
{
    public DbSet<Profissional> Profissionais => Set<Profissional>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profissional>(entidade =>
        {
            entidade.Property(p => p.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Agendamento>(entidade =>
        {
            entidade.Property(a => a.NomeCliente).HasMaxLength(100);

            entidade.HasOne<Profissional>()
                .WithMany()
                .HasForeignKey(a => a.ProfissionalId);

            entidade.HasIndex(a => new { a.ProfissionalId, a.Inicio });
        });
    }
}