using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero 
                {
                    Id = 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham City"
                },
                new SuperHero
                {
                    Id = 2,
                    Name = "Superman",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "New York City"
                }
            };

        // Get Method
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null)
                return BadRequest("Hero not found.");
             return Ok(hero);
            
            
        }

        // Post Method
        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);   
            return Ok(heroes);
        }
    }
}
