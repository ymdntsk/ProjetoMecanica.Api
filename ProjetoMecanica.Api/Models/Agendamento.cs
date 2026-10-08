using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Agendamento
    {

        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Servico { get; set; }
        public decimal Preco { get; set; }
        public int? ClientesId { get; set; }
        public int? VeiculosId { get; set; }

        [JsonIgnore]
        public Cliente? Clientes { get; set; }

        [JsonIgnore]
        public Veiculo? Veiculos { get; set; }
    }
}
