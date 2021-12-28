namespace WebApiRepositorioInteligente.DTO
{
    public class UsuarioAlteracaoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoAlteracaoDto Endereco { get; set; }
    }
}
