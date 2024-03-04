using ProjetPizza.Models;

namespace ProjetPizza.Pages
{
    public partial class PizzaModel
    {
        List<Pizza>? Pizzas { get; set; }
        List<Pizza> Cart { get; set; } = new List<Pizza>();
        decimal TotalPrice => Cart.Sum(p => p.Price);
        Pizza NewPizza { get; set; } = new Pizza();
        string? IngredientInput { get; set; }
        bool IsAdminMode { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            Pizzas = await PizzaService.GetAll();
        }

        void AddToCart(Pizza pizza)
        {
            Cart.Add(pizza);
        }

        void RemoveFromCart(Pizza pizza)
        {
            Cart.Remove(pizza);
        }

        async Task CreatePizza()
        {
            // Splitting the ingredients input by commas
            var ingredients = IngredientInput.Split(',').Select(i => new Ingredient { Name = i.Trim() }).ToList();
            NewPizza.Ingredients = ingredients;

            bool success = await PizzaService.Post(NewPizza);
            if (success)
            {
                Pizzas = await PizzaService.GetAll();
                NewPizza = new Pizza();
                IngredientInput = string.Empty;
            }
            else
            {
                // Handle error
            }
        }

        void ToggleAdminMode()
        {
            IsAdminMode = !IsAdminMode;
        }

        async Task DeletePizza(int pizzaId)
        {
            bool success = await PizzaService.Delete(pizzaId);
            if (success)
            {
                Pizzas?.RemoveAll(p => p.Id == pizzaId);
            }
            else
            {
                // Handle error
            }
        }
    }
}