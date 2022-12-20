using DAW_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Article
    {
        [Key]
        public int Article_Id { get; set; }
        public string Title { get; set; }
        public string Editor_Name { get; set; }
        public DateTime Post_Date { get; set; }
        public int Modify_count { get; set; }

        public string Content { get; set; }
        public string? UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
