using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models
{
  
    [PrimaryKey("Id")]
    public class AssignmentsDone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? userId { get; set; }

        [Required]
        public int MatrialId { get; set; }

        public bool? Done { get; set; }

        public string? imgUrl { get; set; }

        public string? lesson { get; set; }

        public string? semester { get; set; }

        public string? chapter { get; set; }

        
        public int? AssignmentId { get; set; }

        
        public int? teacherId { get; set; }

        
        public int? levelId { get; set; }

        [ForeignKey("AssignmentId")]
        [InverseProperty("TbAssignmentDones")]
        public virtual TbAssignmentLink? Assignment { get; set; }

        [ForeignKey("MatrialId")]
        [InverseProperty("TbAssignmentDones")]
        public virtual TbMatrial? Matrial { get; set; } = null!;

        [ForeignKey("teacherId")]
        [InverseProperty("TbAssignmentDones")]
        public virtual TbTeacher? teacher { get; set; } = null!;

        [ForeignKey("levelId")]
        [InverseProperty("TbAssignmentDones")]
        public virtual TbLevel? level { get; set; } = null!;


        [ForeignKey("userId")]
        [InverseProperty("AssignmentDones")]
        public virtual ApplicationUser StudentUser { get; set; } = null!;
    }
}
