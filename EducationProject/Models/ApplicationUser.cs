using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Code { get; set; }
        public bool? Subscribe { get; set; }
        public int? LevelId { get; set; }
        [ForeignKey("LevelId")]
        [InverseProperty("AppUser")]
        public virtual TbLevel? Level { get; set; }

        [InverseProperty("StudentUser")]
        public virtual ICollection<AssignmentsDone>? AssignmentDones { get; } = new List<AssignmentsDone>();
    }
}
