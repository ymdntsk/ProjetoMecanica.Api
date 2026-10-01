using EscolaApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Api.Models;

namespace ProjetoMecanica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioEncontrado = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.User == usuario.User && u.Senha == usuario.Senha);

            if (usuarioEncontrado == null)
                return Unauthorized("Credenciais inválidas");

            return Ok(new { Nome = usuarioEncontrado.Nome });
        }
    }
}