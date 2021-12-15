using Labb1API.Entities;
using Labb1API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly DogRepository _repository;

        public DogsController(DogRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<Dog> GetDogs()
        {
            return _repository.GetDogs();
        }

        [HttpGet("{id}")]
        public ActionResult<Dog> GetDog(int id)
        {
            var dog = _repository.GetDog(id);

            if (dog == null)
            {
                return NotFound();
            } else
            {
                return Ok(dog);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDog(Dog dog, int id)
        {
            var existingItem = _repository.GetDog(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = dog.Name;

            _repository.UpdateDog(existingItem);

            return Ok();
        }

        [HttpPost]
        public ActionResult<Dog> AddDog(Dog v)
        {
            Dog dog = new()
            {
                Id = v.Id,
                Name = v.Name
            };
            _repository.AddDog(dog);
            return CreatedAtAction(nameof(GetDog), new { id = dog.Id }, dog);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVinyl(int id)
        {
            _repository.DeleteDog(id);

            return NoContent();
        }
    }
}
