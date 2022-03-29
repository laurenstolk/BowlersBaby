﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BowlersBaby.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public int CaptainID { get; set; }

    }
}