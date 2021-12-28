using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.InterfacesServicos;
using System.Linq.Expressions;

namespace Dominio.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuario _Usuario;

        public UsuarioServico(IUsuario usuario)
        {
            _Usuario = usuario;
        }

        public async Task AdicionarComValidacao(Usuario usuario)
        {
            if (usuario.ValidarString(usuario.Nome, "Nome"))
            {
                await _Usuario.Adicionar(usuario);
            }
        }

        public async Task<List<Usuario>> ListarProdutosComExpressions(Expression<Func<Usuario, bool>> exUsuario)
        {
            return await _Usuario.ListarComExpressions(exUsuario);
        }

        public async Task<List<Usuario>> ListarProdutosPorNome(string nome)
        {
            return await ListarProdutosComExpressions(p => p.Nome.Contains(nome));
        }
    }
}
