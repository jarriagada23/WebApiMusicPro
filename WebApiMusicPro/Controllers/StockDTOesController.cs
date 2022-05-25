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
    public class StockDTOesController : ControllerBase
    {
        private readonly WebApiMusicProContext _context;

        public StockDTOesController(WebApiMusicProContext context)
        {
            _context = context;
        }

        // GET: api/StockDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStockDTO()
        {
         List<StockDTO> listaStockDTO = new List<StockDTO>();

            var listaStock = await _context.Stock.Join(

                        _context.Producto,
                        stock => stock.idProductostock,
                        producto => producto.idProducto,
                        (stock, producto) => new 
                        {
                            idStock= stock.idStock,
                            total_prod = stock.total_prod,
                            bodega = stock.bodega,
                            idProductostock = stock.idProductostock,
                            nombreproducto = producto.nombre

                        }
                        ).ToListAsync();

                        foreach (var stock in listaStock)
                        {
                            StockDTO stockDTO = new StockDTO();

                            stockDTO.idStock = stock.idStock;
                            stockDTO.total_prod = stock.total_prod;
                            stockDTO.bodega = stock.bodega;
                            stockDTO.idProductostock = stock.idProductostock;
                            stockDTO.nombreProducto = stock.nombreproducto;

                                listaStockDTO.Add(stockDTO);
                        }

                        return listaStockDTO;

                
        }

        // GET: api/StockDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockDTO>> GetStockDTO(int id)
        {
          if (_context.StockDTO == null)
          {
              return NotFound();
          }
            var stockDTO = await _context.StockDTO.FindAsync(id);

            if (stockDTO == null)
            {
                return NotFound();
            }

            return stockDTO;
        }

        // PUT: api/StockDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockDTO(int id, StockDTO stockDTO)
        {
            if (id != stockDTO.idStock)
            {
                return BadRequest();
            }

            _context.Entry(stockDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockDTOExists(id))
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

        // POST: api/StockDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockDTO>> PostStockDTO(StockDTO stockDTO)
        {
          if (_context.StockDTO == null)
          {
              return Problem("Entity set 'WebApiMusicProContext.StockDTO'  is null.");
          }
            _context.StockDTO.Add(stockDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockDTO", new { id = stockDTO.idStock }, stockDTO);
        }

        // DELETE: api/StockDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockDTO(int id)
        {
            if (_context.StockDTO == null)
            {
                return NotFound();
            }
            var stockDTO = await _context.StockDTO.FindAsync(id);
            if (stockDTO == null)
            {
                return NotFound();
            }

            _context.StockDTO.Remove(stockDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockDTOExists(int id)
        {
            return (_context.StockDTO?.Any(e => e.idStock == id)).GetValueOrDefault();
        }
    }
}
