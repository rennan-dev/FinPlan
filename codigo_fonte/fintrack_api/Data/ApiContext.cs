using Microsoft.EntityFrameworkCore;
using fintrack_api.Models;

namespace fintrack_api.Data;
public class ApiContext : DbContext {
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

    // DbSets de todas as entidades
    public DbSet<Instituicao> Instituicoes { get; set; }
    public DbSet<CompraDebito> ComprasDebito { get; set; }
    public DbSet<CompraCredito> ComprasCredito { get; set; }
    public DbSet<Deposito> Depositos { get; set; }
    public DbSet<Fatura> Faturas { get; set; }

    // Configurações adicionais de mapeamento (se necessário)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração de chave estrangeira e relacionamentos (se necessário)
        modelBuilder.Entity<CompraDebito>()
            .HasOne(c => c.Instituicao)
            .WithMany()
            .HasForeignKey(c => c.InstituicaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CompraCredito>()
            .HasOne(c => c.Instituicao)
            .WithMany()
            .HasForeignKey(c => c.InstituicaoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Fatura>()
            .HasOne(f => f.Instituicao)
            .WithMany()
            .HasForeignKey(f => f.InstituicaoId)
            .OnDelete(DeleteBehavior.Restrict);

        // Você pode adicionar outras configurações ou relações aqui, conforme necessário
    }
}