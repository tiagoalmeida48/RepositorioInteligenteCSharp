using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesServicos
{
    public interface IUsuarioServico
    {
        Task<List<Usuario>> ListarProdutosComExpressions(Expression<Func<Usuario, bool>> exUsuario);
        Task<List<Usuario>> ListarProdutosPorNome(string nome);
        Task AdicionarComValidacao(Usuario usuario);
    }
}
