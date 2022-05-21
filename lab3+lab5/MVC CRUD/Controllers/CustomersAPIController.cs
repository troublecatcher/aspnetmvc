using System;
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
    public class CustomersAPI : ControllerBase
    {
        private readonly Context _context;
        private readonly IMemoryCache _memoryCache;
        public CustomersAPI(Context context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        // GET: api/Everything
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            //customers = _memoryCache.Get<List<Customers>>("customers");
            if (customers == null)
            {
                if(_memoryCache.Get<List<Customers>>("customers") == null)
                    return NotFound();
                else
                {
                    customers = _memoryCache.Get<List<Customers>>("customers");
                    return customers;
                }
            }
            _memoryCache.Set("customers", customers, TimeSpan.FromMinutes(1));
            return customers;
        }
    }
}
