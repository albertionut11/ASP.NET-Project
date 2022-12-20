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
        public string Content { get; set; }
        public int Domain_Id { get; set; }
    
        public virtual Domain Domain { get; set; }

        





    }
}
