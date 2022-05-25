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

        // GET: api/getcustomers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            List<Customers> customers;
            if (!_memoryCache.TryGetValue("customers", out customers))
            {
                customers = await _context.Customers.ToListAsync();
                if (customers != null)
                {
                    _memoryCache.Set("customers", customers, TimeSpan.FromMinutes(1));
                    return customers;
                }
                
            }
            return _memoryCache.Get<List<Customers>>("customers");
        }
    }
}
