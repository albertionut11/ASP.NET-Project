using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW_Project.Models
{
    public class Modification
    {
        [Key]
        public int Modification_Id { get; set; }

        public int Article_Id { get; set; }
        public string Modificator_Name { get; set; }
        public DateTime Post_Date { get; set; }
        [Required(ErrorMessage = "Noul continut este obligatoriu!")]
        public string New_Content { get; set; }
        public string? UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual Article Article { get; set; }

    }
}
