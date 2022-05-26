using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            List<VentaDTO> listaventakDTO = new List<VentaDTO>();

            Producto producto = new Producto();

            var listaventa = await _context.DetalleVenta.Join(
                         
                        _context.Venta,
                       

                        detalleventa => detalleventa.idDetalleVenta,
                        venta => venta.idVenta,                             
                       


                        (detalleventa, venta) => new
                        {
                            idDetalleVenta = detalleventa.idDetalleVenta,
                            idVenta = detalleventa.idVenta,
                            idProducto = detalleventa.idProducto,
                            cantidad = detalleventa.cantidad,
                            total = venta.total,
                            fecha = venta.fecha
                           

                        }
                        ).Join(
                        _context.Producto,
                         detalleventa => detalleventa.idDetalleVenta,
                         producto => producto.idProducto,


                        (detalleventa, producto) => new
                        {

                            idDetalleVenta = detalleventa.idDetalleVenta,
                            idVenta = detalleventa.idVenta,
                            idProducto = detalleventa.idProducto,
                            cantidad = detalleventa.cantidad,
                            total = detalleventa.total,
                            fecha = detalleventa.fecha,
                            nombreProducto = producto.nombre


                        }



                         ).ToListAsync();

            foreach (var detalleventa in listaventa)
            {
                VentaDTO ventaDTO = new VentaDTO();

                ventaDTO.idDetalleVenta = detalleventa.idDetalleVenta;
                ventaDTO.idVenta = detalleventa.idVenta;
                ventaDTO.idProducto = detalleventa.idProducto;
                ventaDTO.cantidad = detalleventa.cantidad;
                ventaDTO.total = detalleventa.total;
                ventaDTO.fecha = detalleventa.fecha;
                ventaDTO.nombreProducto = detalleventa.nombreProducto;

                listaventakDTO.Add(ventaDTO);
            }

            return listaventakDTO;
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
            if (id != ventaDTO.idDetalleVenta)
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

            return CreatedAtAction("GetVentaDTO", new { id = ventaDTO.idDetalleVenta }, ventaDTO);
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
            return (_context.VentaDTO?.Any(e => e.idDetalleVenta == id)).GetValueOrDefault();
        }
    }
}
