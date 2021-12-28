using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Notifica
    {
        public Notifica()
        {
            Notificacoes = new List<Notifica>();
        }
 
        [NotMapped]
        public string? NomePropriedade { get; set; }

        [NotMapped]
        public string? Informacao { get; set; }

        public List<Notifica> Notificacoes;

        public bool ValidarString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Informacao = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }
    }
}
