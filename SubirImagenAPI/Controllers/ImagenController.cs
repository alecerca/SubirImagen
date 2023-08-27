using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubirImagenAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SubirImagenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImagenController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> SubirImagen(IFormFile archivo)
        {
            if(archivo == null || archivo.Length == 0)
            {
                return BadRequest("No se ha subido ningun archivo");
            }
            var imagen = new Imagen
            {
                Nombre = archivo.FileName
            };

            using(var ms = new MemoryStream())
            {
                await archivo.CopyToAsync(ms);
                imagen.Contenido = ms.ToArray();
            }

            _context.Imagenes.Add(imagen);
            await _context.SaveChangesAsync();

            return Ok(new { imagen.Id });
        }
        [HttpGet("{id}")]
        public IActionResult ObtenerImagen(int id)
        {
            var imagen = _context.Imagenes.FirstOrDefault(v => v.Id == id);
            if(imagen == null)
            {
                return NotFound();
            }
            return File(imagen.Contenido, "imagen/png");
        }
    }
}
