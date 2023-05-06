using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Table("TbStudent")]
[Index("LevelId", Name = "IX_TbStudent_LevelId")]
public partial class TbStudent
{
    [Key]
    [Column("StudentID")]
    public string? StudentId { get; set; }

    [StringLength(200)]
    public string StudentFullName { get; set; } = null!;

    public string? UserName { get; set; }

    [Required(ErrorMessage ="من فضلك حدد اذا كان مشترك او لا")]
    public bool? subscribe { get; set; }

    public string Code { get; set; }

    public int? LevelId { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("TbStudents")]
    public virtual TbLevel? Level { get; set; }

    //[InverseProperty("Student")]
    //public virtual ICollection<AssignmentsDone>? TbAssignmentDones { get; } = new List<AssignmentsDone>();

    [InverseProperty("Student")]
    public virtual ICollection<TbCode>? TbCodes { get; } = new List<TbCode>();

    [ForeignKey("StudentId")]
    [InverseProperty("Student")]
    public virtual ICollection<TbMatrial>? Matrial { get; } = new List<TbMatrial>();
   
}
