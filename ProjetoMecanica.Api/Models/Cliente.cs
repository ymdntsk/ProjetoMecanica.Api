using System.Drawing;
using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public int Telefone { get; set; }
        public string Email{ get; set; }
        public int Cpf { get; set; }

        [JsonIgnore]
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();

        [JsonIgnore]
        public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
