using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTracker.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { set; get; }
        [Required]
        public string Username { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
