using System.ComponentModel.DataAnnotations;

namespace ReservaSala.Api.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
