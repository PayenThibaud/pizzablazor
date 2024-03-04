using ProjetPizza.Models;

namespace ProjetPizza.Services
{
    public interface IPizzaService
    {
        public Task<bool> Post(Pizza pizza);
        public Task<bool> Delete(int id);
        public Task<Pizza> GetById(int id);
        public Task<List<Pizza>> GetAll();
    }
}
