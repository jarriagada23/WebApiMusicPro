using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMusicPro.Data;
using WebApiMusicPro.Models;

namespace WebApiMusicPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaDTOController : ControllerBase
    {
        private readonly WebApiMusicProContext _context;

        public VentaDTOController(WebApiMusicProContext context)
        {
            _context = context;
        }

        // GET: api/VentaDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaDTO>>> GetVentaDTO()
        {
            List<VentaDTO> listaVentaDTO = new List<VentaDTO>();

            var listaVenta = await _context.Venta.Join(

                        _context.Usuario,
                        venta => venta.idUsuario,
                        usuario => usuario.idUsuario,
                        (venta, usuario) => new
                        {
                            idVenta = venta.idVenta,
                            idUsuario = venta.idUsuario,
                            total = venta.total,
                            fecha = venta.fecha,
                            nombreUsuario = usuario.nombre





                        }
                        ).ToListAsync();

            foreach (var venta in listaVenta)
            {
                VentaDTO ventaDTO = new VentaDTO();

                ventaDTO.idVenta = venta.idVenta;
                ventaDTO.idUsuario = venta.idUsuario;
                ventaDTO.total = venta.total;
                ventaDTO.fecha = venta.fecha;
                ventaDTO.nombreUsuario = venta.nombreUsuario;

                listaVentaDTO.Add(ventaDTO);
            }

            return listaVentaDTO;
        }

        // GET: api/VentaDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaDTO>> GetVentaDTO(int id)
        {
            if (_context.VentaDTO == null)
            {
                return NotFound();
            }
            var ventaDTO = await _context.VentaDTO.FindAsync(id);

            if (ventaDTO == null)
            {
                return NotFound();
            }

            return ventaDTO;
        }

        // PUT: api/VentaDTO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaDTO(int id, VentaDTO ventaDTO)
        {
            if (id != ventaDTO.idVenta)
            {
                return BadRequest();
            }

            _context.Entry(ventaDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VentaDTO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaDTO>> PostVentaDTO(VentaDTO ventaDTO)
        {
            if (_context.VentaDTO == null)
            {
                return Problem("Entity set 'WebApiMusicProContext.VentaDTO'  is null.");
            }
            _context.VentaDTO.Add(ventaDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentaDTO", new { id = ventaDTO.idVenta }, ventaDTO);
        }

        // DELETE: api/VentaDTO/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaDTO(int id)
        {
            if (_context.VentaDTO == null)
            {
                return NotFound();
            }
            var ventaDTO = await _context.VentaDTO.FindAsync(id);
            if (ventaDTO == null)
            {
                return NotFound();
            }

            _context.VentaDTO.Remove(ventaDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaDTOExists(int id)
        {
            return (_context.VentaDTO?.Any(e => e.idVenta == id)).GetValueOrDefault();
        }
    }
}
