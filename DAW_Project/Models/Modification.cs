using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models
{
    public class Modification
    {
        [Key]
        public int Modification_Id { get; set; }
        public string Modificator_Name { get; set; }
        public DateTime Modification_Date { get; set; }
        public string New_Content { get; set; }

        public int Article_Id { get; set; }

        public virtual Article Article { get; set; }


    }
}
