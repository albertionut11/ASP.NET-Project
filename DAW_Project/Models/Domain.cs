using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW_Project.Models
{
    public class Domain
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Numele domeniului este obligatoriu!")]
        public string? Domain_name { get; set; }
        [Required(ErrorMessage = "Descrierea domeniului este obligatorie!")]
        public string? Domain_description { get; set; }
        public string? UserID { get; set; }

        public virtual ApplicationUser? User { get; set; }
       public virtual ICollection<Article>? Articles { get; set; }
    }
}
