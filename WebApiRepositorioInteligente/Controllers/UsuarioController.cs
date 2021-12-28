using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.InterfacesServicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiRepositorioInteligente.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _Usuario;
        private readonly IUsuarioServico _UsuarioServico;

        public UsuarioController(IUsuario usuario, IUsuarioServico usuarioServico)
        {
            _Usuario = usuario;
            _UsuarioServico = usuarioServico;
        }

        [HttpPost]
        public async Task<List<Notifica>> AdicionarComValidacao(Usuario usuario)
        {
            await _UsuarioServico.AdicionarComValidacao(usuario);
            return usuario.Notificacoes;
        }

        [HttpPut]
        public async Task<List<Notifica>> Alterar(Usuario usuario)
        {
            await _Usuario.Alterar(usuario);
            return usuario.Notificacoes;
        }

        [HttpDelete]
        public async Task<List<Notifica>> Excluir(Usuario usuario)
        {
            await _Usuario.Excluir(usuario);
            return usuario.Notificacoes;
        }

        [HttpGet]
        public async Task<Usuario> BuscarPorId(long id)
        {
            return await _Usuario.BuscarPorId(id);
        }

        [HttpGet]
        public async Task<List<Usuario>> BuscarPorNome(string nome)
        {
            return await _UsuarioServico.ListarProdutosPorNome(nome);
        }

        [HttpGet]
        public async Task<List<Usuario>> BuscarTudo()
        {
            return await _Usuario.ListarTudo();
        }
    }
}
