using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Agendamento
    {

        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Servico { get; set; }
        public decimal Preco { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        [JsonIgnore]
        public Veiculo? Veiculo { get; set; }
    }
}
