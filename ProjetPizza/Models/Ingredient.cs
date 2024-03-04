using System.ComponentModel.DataAnnotations;

namespace ProjetPizza.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PizzaId { get; set; }

        [Required]
        public string? Name { get; set; }


        public Pizza? Pizza { get; set; }
    }
}
