using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Ingredient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Indgedient name cannot be longer than 50 character or shorter than 3 character.")]
        public string IngredientName { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Calories { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Fats { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Protein { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Sugar { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Carbs { get; set; }
    }
}
