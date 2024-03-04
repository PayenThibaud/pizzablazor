using System.ComponentModel.DataAnnotations;

namespace ProjetPizza.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? ImageLink { get; set; }


        public List<Ingredient>? Ingredients { get; set; }
    }
}
