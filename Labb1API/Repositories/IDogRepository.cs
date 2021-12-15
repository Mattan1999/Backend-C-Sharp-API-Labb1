using Labb1API.Entities;
using System.Collections.Generic;

namespace Labb1API.Repositories
{
    public interface IDogRepository
    {
        IEnumerable<Dog> GetDogs();
        Dog GetDog(int id);
        void UpdateDog(Dog dog);

        void AddDog(Dog dog);

        void DeleteDog(int id);
    }
}
