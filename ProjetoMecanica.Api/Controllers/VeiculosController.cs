using EscolaApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddVeiculo(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veiculo salvo com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVeiculo(int id, Veiculo veiculo)
        {
            var veiculoExistente = await _context.Veiculos.FindAsync(id);

            if (veiculoExistente == null) return NotFound("Veiculo não encontrado");

            veiculoExistente.Modelo = veiculo.Modelo;
            veiculoExistente.Cor = veiculo.Cor;
            veiculoExistente.Placa = veiculo.Placa;
            veiculoExistente.Marca = veiculo.Marca;

            await _context.SaveChangesAsync();

            return Ok("Veiculo Editado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);

            if (veiculo == null)
                return NotFound("Veiculo não encontrado");

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veiculo removido com sucesso");
        }
    }
}