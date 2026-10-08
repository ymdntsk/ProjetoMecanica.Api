using ProjetoMecanica.Api.Controllers;
using System.Drawing;
using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }

        public int? ClientesId { get; set; }

        [JsonIgnore]
        public Cliente? Clientes { get; set; }

        [JsonIgnore]
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
