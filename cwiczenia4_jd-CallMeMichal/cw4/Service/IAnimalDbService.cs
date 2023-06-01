using cw4.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw4.Service
{
    public interface IAnimalDbService
    {
        Task<IList<Animal>> GetAnimalListAsync(string name);
       
        Task<bool> AddAnimalAsync(Animal animal);

        Task<bool>  DeleteAnimalAsync(int id);

        Task<bool> PutAnimalAsync(int id,Animal animal);


    }
}
