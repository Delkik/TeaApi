using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly TeaApiDbContext _context;

        public StoreController(TeaApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Response<Store>>> GetStores()
        {
            Response<Store> response = new();
            if (_context.Stores == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
                return response;
            }

            response.StatusCode = 200;
            response.StatusDescription = "OK";
            response.Data = await _context.Stores.ToListAsync();
            return response;
        }

        // POST: api/stores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<Response<Store>>> PostStore(int id, Store store)
        {
            Response<Store> response = new();
            if (_context.Stores == null)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Empty Database";
                return response;
                /*return Problem("Entity set 'TeaAPIDbContext.Stores'  is null."); // replace*/
            }
            if (id != store.StoreId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
                return response;
            }
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStores", new { id = store.StoreId }, store);
        }

        // PUT: api/stores/5/7
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/{quantity}")]
        public async Task<ActionResult<Response<Store>>> PutStore(int id, int quantity, Store store)
        {
            Response<Store> response = new();
            if (id != store.StoreId || quantity != store.Quantity)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request";
                return response;
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Not Found";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.StatusCode = 204;
            response.StatusDescription = "No Content";
            return response;
        }

        private bool StoreExists(int id)
        {
            return (_context.Stores?.Any(e => e.StoreId == id)).GetValueOrDefault();
        }
    }
}
