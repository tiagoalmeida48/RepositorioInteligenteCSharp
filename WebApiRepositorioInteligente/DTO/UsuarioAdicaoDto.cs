namespace WebApiRepositorioInteligente.DTO
{
    public class UsuarioAdicaoDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoAdicaoDto Endereco { get; set; }
    }
}
