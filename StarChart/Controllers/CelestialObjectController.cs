using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;


namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Getter for ID location
        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.Find(id);
            if(celestialObject == null)
                return NotFound();
            celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            return Ok(celestialObject);
        }

        //Getter for Name
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celestialObjects = _context.CelestialObjects.Where(e => name == e.Name).ToList();
            if(!celestialObjects.Any())
                return NotFound();
            foreach(var celestialObject in celestialObjects)
            {
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id).ToList();
            }
            return Ok(celestialObjects);
        }

        //Getter for All
        [HttpGet]
        public IActionResult GetAll()
        {
            var celestialObjects = _context.CelestialObjects.ToList();

            foreach( var celestialObject in celestialObjects)
            {
                celestialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celestialObject.Id).ToList();
            }
            return Ok(celestialObjects);
        }


    }
}
