using Inmobiliaria.Domain.Entities;
using Inmobiliaria.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MensajesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enviar([FromBody] Mensaje mensaje)
        {
            mensaje.FechaEnvio = DateTime.UtcNow;
            mensaje.Leido = false;
            _context.Mensajes.Add(mensaje);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Mensaje enviado" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var mensajes = await _context.Mensajes.OrderByDescending(m => m.FechaEnvio).ToListAsync();
            return Ok(mensajes);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var msg = await _context.Mensajes.FindAsync(id);
            if (msg == null) return NotFound();
            _context.Mensajes.Remove(msg);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}