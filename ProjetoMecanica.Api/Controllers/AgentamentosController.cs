using EscolaApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            return await _context.Agendamento.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddAgendamento(Agendamento agendamentos)
        {
            _context.Agendamento.Add(agendamentos);
            await _context.SaveChangesAsync();
            return Ok("Agendamento salvo com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgendamento(int id, Agendamento agendamentos)
        {
            var agendamentoExistente = await _context.Agendamento.FindAsync(id);
             
            if (agendamentoExistente == null) return NotFound("Agendamento não encontrado");
          

             agendamentoExistente.DataAgendamento = agendamentos.DataAgendamento;
            agendamentoExistente.Servico = agendamentos.Servico;
            agendamentoExistente.Preco = agendamentos.Preco;
            agendamentoExistente.ClientesId = agendamentos.ClientesId;
            agendamentoExistente.VeiculosId = agendamentos.VeiculosId;

            await _context.SaveChangesAsync();

            return Ok("Agendamento Editado com sucesso");
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            var agendamentos = await _context.Agendamento.FindAsync(id);

            if (agendamentos == null)
                return NotFound("Agendamento não encontrado");

            _context.Agendamento.Remove(agendamentos);
            await _context.SaveChangesAsync();
            return Ok("Agendamento removido com sucesso");
        }
    }
}