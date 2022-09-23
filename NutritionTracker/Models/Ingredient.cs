using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NutritionTracker.Models
{
    public class Ingredient
    {
        [Required]
        [Key]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Indgedient name cannot be longer than 50 character or shorter than 3 character.")]
        public string ingredientName { get; set; }

        [Required]
        [Range(0, 20000)]
        public int calories { get; set; }

        [Required]
        [Range(0, 20000)]
        public int fats { get; set; }

        [Required]
        [Range(0, 20000)]
        public int protein { get; set; }

        [Required]
        [Range(0, 20000)]
        public int sugar { get; set; }

        [Required]
        [Range(0, 20000)]
        public int carbs { get; set; }
    }
}
