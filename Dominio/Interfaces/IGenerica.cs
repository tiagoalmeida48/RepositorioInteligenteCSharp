using System.Linq.Expressions;

namespace Dominio.Interfaces
{
    public interface IGenerica<T> where T : class
    {
        Task Adicionar(T obj);
        Task Alterar(T obj);
        Task Excluir(T obj);
        Task<T> BuscarPorId(long Id);
        Task<List<T>> ListarTudo();
        Task<List<T>> ListarComExpressions(Expression<Func<T, bool>> expressions);
    }
}
