namespace WebApiRepositorioInteligente.DTO
{
    public class UsuarioExibicaoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoExibicaoDto Endereco { get; set; }
    }
}
