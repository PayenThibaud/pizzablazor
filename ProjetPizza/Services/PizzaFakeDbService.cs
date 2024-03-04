using ProjetPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetPizza.Services
{
    public class PizzaFakeDbService : IPizzaService
    {
        private int _lastId = 8;
        private List<Pizza> _pizza = new List<Pizza>();
        private List<Ingredient> _ingredient = new List<Ingredient>();

        // Données de seed pour les pizzas
        public static readonly List<Pizza> CompletePizzas = new List<Pizza>()
        {
            new Pizza{ Id =1, Name ="Bacon", Price = 12, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 1, PizzaId = 1, Name = "bacon" },
                new Ingredient {Id = 2, PizzaId = 1, Name = "mozzarella"},
                new Ingredient {Id = 3, PizzaId = 1, Name = "champignon"},
                new Ingredient {Id = 4, PizzaId = 1, Name = "emmental" },
            }, ImageLink = "/images/bacon.jpg"  },
            new Pizza{ Id =2, Name ="4 fromages", Price= 11, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 5, PizzaId = 2, Name = "cantal"},
                new Ingredient {Id = 6, PizzaId = 2, Name = "mozzarella"},
                new Ingredient {Id = 7, PizzaId = 2, Name = "fromage de chèvre" },
                new Ingredient {Id = 8, PizzaId = 2, Name = "gruyère" },
            }, ImageLink = "/images/cheese.jpg"  },
            new Pizza{ Id =3, Name ="Margherita", Price = 10, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 9, PizzaId = 3, Name = "sauce tomate" },
                new Ingredient {Id = 10, PizzaId = 3, Name = "mozzarella"},
                new Ingredient {Id = 11, PizzaId = 3, Name = "basilic" },
            }, ImageLink = "/images/margherita.jpg"  },
            new Pizza{ Id =4, Name ="Mexicaine", Price=12, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 12, PizzaId = 4, Name = "boeuf"},
                new Ingredient {Id = 13, PizzaId = 4, Name = "mozzarella"},
                new Ingredient {Id = 14, PizzaId = 4, Name = "maïs"},
                new Ingredient {Id = 15, PizzaId = 4, Name = "tomates"},
                new Ingredient {Id = 16, PizzaId = 4, Name = "oignon"},
                new Ingredient {Id = 17, PizzaId = 4, Name = "coriandre" },
            }, ImageLink = "/images/meaty.jpg"  },
            new Pizza{ Id =5, Name ="Reine", Price=11, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 18, PizzaId = 5, Name = "jambon"},
                new Ingredient {Id = 19, PizzaId = 5, Name = "champignons"},
                new Ingredient {Id = 20, PizzaId = 5, Name = "mozzarella" },
            }, ImageLink = "/images/mushroom.jpg"  },
            new Pizza{ Id =6, Name ="Pepperoni", Price=11, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 21, PizzaId = 6, Name = "mozzarella"},
                new Ingredient {Id = 22, PizzaId = 6, Name = "pepperoni"},
                new Ingredient {Id = 23, PizzaId = 6, Name = "tomates" },
            }, ImageLink = "/images/pepperoni.jpg"  },
            new Pizza{ Id =7, Name ="Végétarienne",Price = 10, Ingredients = new List<Ingredient>(){
                new Ingredient {Id = 24, PizzaId = 7, Name = "champignons"},
                new Ingredient {Id = 25, PizzaId = 7, Name = "roquette"},
                new Ingredient {Id = 26, PizzaId = 7, Name = "artichauts"},
                new Ingredient {Id = 27, PizzaId = 7, Name = "aubergine" }
            }, ImageLink = "/images/veggie.jpg"  },
        };


        public static readonly List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza{ Id =1, Name ="Bacon", Price = 12, ImageLink = "/images/bacon.jpg"  },
            new Pizza{ Id =2, Name ="4 fromages", Price= 11, ImageLink = "/images/cheese.jpg"  },
            new Pizza{ Id =3, Name ="Margherita", Price = 10, ImageLink = "/images/margherita.jpg"  },
            new Pizza{ Id =4, Name ="Mexicaine", Price=12,  ImageLink = "/images/meaty.jpg"  },
            new Pizza{ Id =5, Name ="Reine", Price=11, ImageLink = "/images/mushroom.jpg"  },
            new Pizza{ Id =6, Name ="Pepperoni", Price=11, ImageLink = "/images/pepperoni.jpg"  },
            new Pizza{ Id =7, Name ="Végétarienne",Price = 10, ImageLink = "/images/veggie.jpg"  },
        };

        public static readonly List<Ingredient> Ingredients = new List<Ingredient>()
        {
            new Ingredient {Id = 1, PizzaId = 1, Name = "bacon" },
            new Ingredient {Id = 2, PizzaId = 1, Name = "mozzarella"},
            new Ingredient {Id = 3, PizzaId = 1, Name = "champignon"},
            new Ingredient {Id = 4, PizzaId = 1, Name = "emmental" },
            new Ingredient {Id = 5, PizzaId = 2, Name = "cantal"},
            new Ingredient {Id = 6, PizzaId = 2, Name = "mozzarella"},
            new Ingredient {Id = 7, PizzaId = 2, Name = "fromage de chèvre" },
            new Ingredient {Id = 8, PizzaId = 2, Name = "gruyère" },
            new Ingredient {Id = 9, PizzaId = 3, Name = "sauce tomate" },
            new Ingredient {Id = 10, PizzaId = 3, Name = "mozzarella"},
            new Ingredient {Id = 11, PizzaId = 3, Name = "basilic" },
            new Ingredient {Id = 12, PizzaId = 4, Name = "boeuf"},
            new Ingredient {Id = 13, PizzaId = 4, Name = "mozzarella"},
            new Ingredient {Id = 14, PizzaId = 4, Name = "maïs"},
            new Ingredient {Id = 15, PizzaId = 4, Name = "tomates"},
            new Ingredient {Id = 16, PizzaId = 4, Name = "oignon"},
            new Ingredient {Id = 17, PizzaId = 4, Name = "coriandre" },
            new Ingredient {Id = 18, PizzaId = 5, Name = "jambon"},
            new Ingredient {Id = 19, PizzaId = 5, Name = "champignons"},
            new Ingredient {Id = 20, PizzaId = 5, Name = "mozzarella" },
            new Ingredient {Id = 21, PizzaId = 6, Name = "mozzarella"},
            new Ingredient {Id = 22, PizzaId = 6, Name = "pepperoni"},
            new Ingredient {Id = 23, PizzaId = 6, Name = "tomates" },
            new Ingredient {Id = 24, PizzaId = 7, Name = "champignons"},
            new Ingredient {Id = 25, PizzaId = 7, Name = "roquette"},
            new Ingredient {Id = 26, PizzaId = 7, Name = "artichauts"},
            new Ingredient {Id = 27, PizzaId = 7, Name = "aubergine" }
        };

        public async Task<bool> Delete(int id)
        {
            var removedFromPizzaList = _pizza.RemoveAll(p => p.Id == id);
            var removedFromCompleteList = CompletePizzas.RemoveAll(p => p.Id == id);

            Console.WriteLine($"Total pizzas in _pizza list: {_pizza.Count}");
            Console.WriteLine($"Total pizzas in CompletePizzas list: {CompletePizzas.Count}");

            return removedFromPizzaList == 1 || removedFromCompleteList == 1;
        }

        public async Task<bool> Post(Pizza pizza)
        {
            pizza.Id = ++_lastId;
            _pizza.Add(pizza);
            Console.WriteLine(_pizza.Count);
            return true;
        }

        public Task<Pizza> GetById(int id)
        {
            return Task.FromResult(_pizza.FirstOrDefault(p => p.Id == id));
        }

        public Task<List<Pizza>> GetAll()
        {
            var allPizzas = new List<Pizza>(CompletePizzas);
            allPizzas.AddRange(_pizza);
            return Task.FromResult(allPizzas);
        }
    }
}


