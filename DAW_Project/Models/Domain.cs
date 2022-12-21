﻿using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Domain
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele domeniului este obligatoriu")]
        public string Domain_name { get; set; }
        public string Domain_description { get; set; }
        public string? UserID { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
