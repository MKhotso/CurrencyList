using CurrencyList.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyList.Server.Controllers
{ 
        [Route("api/[controller]")]
        [ApiController]
        public class CurrenciesController : ControllerBase
        {
            private LibraryContext _context;
            public CurrenciesController(LibraryContext context)
            {
                _context = context;
            }

            // GET: api/<CurrenciesController>
            [HttpGet]
            public object Get()
            {
                return new { Items = _context.currencies, Count = _context.Currencies.Count() };
            }

            // POST api/<CurrenciesController>
            [HttpPost]
            public void Post([FromBody] Currencies currencies)
            {
                _context.Currencies.Add(currencies);
                _context.SaveChanges();
            }

            // PUT api/<CurrenciesController>
            [HttpPut]
            public void Put(long id, [FromBody] Currencies currencies)
            {
                Currencies _currencies = _context.Currencies.Where(x => x.Id.Equals(currencies.Id)).FirstOrDefault();
                _currencies.Name = currencies.Name;
                _currencies.CurrencyCode = currencies.CurrencyCode;
                _context.SaveChanges();
            }

            // DELETE api/<CurrenciesController>
            [HttpDelete("{id}")]
            public void Delete(long id)
            {
                Currencies _currencies = _context.Currencies.Where(x => x.Id.Equals(id)).FirstOrDefault();
                _context.Currencies.Remove(_currencies);
                _context.SaveChanges();
            }
        }
    }