using Microsoft.AspNetCore.Identity;

namespace DAW_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Article>? Articles { get; set; }
    }
}
