using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Modification
    {
        [Key]
        public int Modification_Id { get; set; }
        public int Article_Id { get; set; }
        public string Editor_Name { get; set; }
        public DateTime Post_Date { get; set; }
        public string New_Content { get; set; }
        public string? UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
