using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades;
public class Notifica
{
    [NotMapped]
    public string NomePropriedade { get; set; }

    [NotMapped]
    public string Mensagem { get; set; }

    [NotMapped]
    public List<Notifica> Notificacoes { get; set; }

    public Notifica()
    {
        Notificacoes = new List<Notifica>();
    }

    public bool ValidarPropriedadeString(string valor, string nomePropriedade)
    {
        if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
        {
            Notificacoes.Add(new Notifica
            {
                Mensagem = "campo Obrigatório",
                NomePropriedade = nomePropriedade
            });

            return false;
        }
        return true;
    }

    public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
    {
        if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
        {
            Notificacoes.Add(new Notifica
            {
                Mensagem = "campo Obrigatório",
                NomePropriedade = nomePropriedade
            });

            return false;
        }
        return true;
    }
}
