using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Repositorio.Configuracoes;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Repositorio.Repositorios
{
    public class RepositorioGenerico<T> : IGenerica<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;

        public RepositorioGenerico()
        {
            _optionsBuilder = new DbContextOptions<Contexto>();
        }

        public async Task Adicionar(T obj)
        {
            using var data = new Contexto(_optionsBuilder);
            await data.Set<T>().AddAsync(obj);
            await data.SaveChangesAsync();
        }

        public async Task Alterar(T obj)
        {
            using var data = new Contexto(_optionsBuilder);
            data.Set<T>().Update(obj);
            await data.SaveChangesAsync();
        }

        public async Task<T> BuscarPorId(long id)
        {
            using var data = new Contexto(_optionsBuilder);
            return await data.Set<T>().FindAsync(id);
        }

        public async Task Excluir(T obj)
        {
            using var data = new Contexto(_optionsBuilder);
            data.Set<T>().Remove(obj);
            await data.SaveChangesAsync();
        }

        public async Task<List<T>> ListarComExpressions(Expression<Func<T, bool>> expressions)
        {
            using var data = new Contexto(_optionsBuilder);
            return await data.Set<T>().Where(expressions).AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> ListarTudo()
        {
            using var data = new Contexto(_optionsBuilder);
            return await data.Set<T>().AsNoTracking().ToListAsync();
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
