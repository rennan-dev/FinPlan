using finances.Models;
using Microsoft.EntityFrameworkCore;

namespace finances.Data;

public class InstituicaoContext : DbContext {
    public InstituicaoContext(DbContextOptions<InstituicaoContext> opts) : base(opts) { }

    public DbSet<Instituicao> Instituicoes { get; set; }
    public DbSet<FaturaCredito> FaturasCredito { get; set; } 
    public DbSet<Debito> Debitos { get; set; }
    public DbSet<Deposito> Depositos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Instituicao>().HasIndex(e => e.Id).IsUnique();

        //configuração do relacionamento entre Instituicao e FaturaCredito
        modelBuilder.Entity<FaturaCredito>()
            .HasOne(f => f.Instituicao) //uma FaturaCredito tem uma Instituicao
            .WithMany(i => i.FaturasCredito) //uma Instituicao pode ter várias FaturasCredito
            .HasForeignKey(f => f.InstituicaoId) 
            .OnDelete(DeleteBehavior.Cascade); 

        //configuração do relacionamento entre Instituicao e Débito
        modelBuilder.Entity<Debito>()
            .HasOne(f => f.Instituicao) //um Débito tem uma Instituicao
            .WithMany(i => i.Debitos) //uma Instituicao pode ter vários Débitos
            .HasForeignKey(f => f.InstituicaoId) 
            .OnDelete(DeleteBehavior.Cascade); 

        //configuração do relacionamento entre Instituicao e Deposito
        modelBuilder.Entity<Deposito>()
            .HasOne(f => f.Instituicao) //um Depósito tem uma Instituicao
            .WithMany(i => i.Depositos) //uma Instituicao pode ter vários Depósitos
            .HasForeignKey(f => f.InstituicaoId) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}
