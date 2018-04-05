using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeroesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET api/heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _context.Heroes.ToArray();
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return _context.Heroes.FirstOrDefault(c => c.Id == id);
        }

        // POST api/heroes
        [HttpPost]
        public void Post([FromBody]Hero value)
        {
            _context.Heroes.Add(value);
            _context.SaveChanges();

            //{Id:3, Name: 'Magneta'}
        }

        // PUT api/heroes/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string name)
        {
            var hero =_context.Heroes.FirstOrDefault(c => c.Id == id);
            hero.Name = name;
            _context.SaveChanges();
        }

        // DELETE api/heroes/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var hero = _context.Heroes.FirstOrDefault(c => c.Id == id);
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
        }
    }
}
