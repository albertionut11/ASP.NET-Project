using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW_Project.Models
{
    public class Article
    {
        [Key]
        public int Article_Id { get; set; }
        [Required(ErrorMessage = "Titlul este obligatoriu!")]
        public string Title { get; set; }
        public string Editor_Name { get; set; }
        public DateTime Post_Date { get; set; }
        [Required(ErrorMessage = "Continutul articolului este obligatoriu!")]
        public string Content { get; set; }
        public string? UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }
        [Required(ErrorMessage = "Domeniul articolului este obligatoriu!")]
        public int? Domain_id { get; set; }
        public virtual Domain Domain { get; set; }

    }
}
