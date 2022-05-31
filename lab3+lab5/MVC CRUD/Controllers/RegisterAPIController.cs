using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using Microsoft.Extensions.Caching.Memory;
namespace MVC_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterAPI : ControllerBase
    {
        private readonly Context _context;
        private readonly IMemoryCache _memoryCache;
        public RegisterAPI(Context context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
        // GET: api/getregisters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            List<Register> registers;
            if (!_memoryCache.TryGetValue("registers", out registers))
            {
                registers = await _context.Registers.ToListAsync();
                if (registers != null)
                {
                    _memoryCache.Set("registers", registers, TimeSpan.FromMinutes(1));
                    return registers;
                }

            }
            return _memoryCache.Get<List<Register>>("registers");
        }
    }
}