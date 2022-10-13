﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerServer.Models
{
    public class User
    {
       
        [Key]
        public int Id { set; get; }
        public string Email { set; get; }    
        public string Username { set; get; }      
        public byte[] PasswordHash { set; get; }      
        public byte[] PasswordSalt { set; get; }
        public bool IsConfirmed { set; get; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
