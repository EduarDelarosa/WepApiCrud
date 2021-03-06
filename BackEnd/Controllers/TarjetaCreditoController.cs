using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public TarjetaCreditoController(AplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/TarjetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarjetaCredito>>> GetTarjetaCredito()
        {
            return await _context.TarjetaCredito.ToListAsync();
        }

        //Get: api/TarjetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaCredito>> GetTarjetaCredito(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);

            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return tarjetaCredito;
        }

        //PUT: api/TarjetaCredito
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetaCredito(int id, TarjetaCredito tarjetaCredito)
        {
            if (id != tarjetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                if (!TarjetaCreditoExist(id))
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

        //POST: api/TarjetaCredito
        [HttpPost]
        public async Task<ActionResult<TarjetaCredito>> PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            _context.TarjetaCredito.Add(tarjetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetaCredito", new { id = tarjetaCredito.Id }, tarjetaCredito);
        }

        //DELETE: api/TarjetaCredito
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarjetaCredito>> DeleteTarjetaCredito(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);
            if (tarjetaCredito == null)
            {
                return NotFound();  
            }

            _context.TarjetaCredito.Remove(tarjetaCredito);
            await _context.SaveChangesAsync();

            return tarjetaCredito;
        }

        private bool TarjetaCreditoExist(int id)
        {
            return _context.TarjetaCredito.Any(x => x.Id == id);
        }
    }
}
