using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Configuracoes
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=localhost;Database=REPOSITORIO_INTELIGENTE;Uid=root;Pwd=16011991;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
        }
    }
}
