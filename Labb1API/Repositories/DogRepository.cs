using Labb1API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb1API.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly List<Dog> _dogs = new()
        {
            new Dog() { Id = 0, Name = "Dog 1" },
            new Dog() { Id = 1, Name = "Dog 2" },
            new Dog() { Id = 2, Name = "Dog 3" },
            new Dog() { Id = 3, Name = "Dog 4" },
            new Dog() { Id = 4, Name = "Dog 5" },
        };

        public IEnumerable<Dog> GetDogs()
        {
            return _dogs;
        }

        public Dog GetDog(int id)
        {
            var dog = _dogs.Where(dog => dog.Id == id);
            return dog.SingleOrDefault();
        }

        public void UpdateDog(Dog dog)
        {
            var index = _dogs.FindIndex(exDog => exDog.Id == dog.Id);
            _dogs[index] = dog;
        }

        public void AddDog(Dog dog)
        {
            _dogs.Add(dog);
        }

        public void DeleteDog(int id)
        {
            var index = _dogs.FindIndex(exDog => exDog.Id == id);
            _dogs.RemoveAt(index);
        }
    }
}
