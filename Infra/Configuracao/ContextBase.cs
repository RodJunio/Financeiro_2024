using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao;
public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<SistemaFinanceiro> SistemaFinanceiro { get; set; }
    public DbSet<UsuarioSistemaFinanceiro> UsuarioSistemaFinanceiro { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Despesa> Despesa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ObterStringConexao());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder Builder)
    {
        Builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

        base.OnModelCreating(Builder);
    }

    public string ObterStringConexao()
    {
        return "Data Source=JUNIO;Initial Catalog=Financeiro_2024;Integrated Security=true";
    }

}
