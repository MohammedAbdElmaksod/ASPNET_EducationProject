using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Table("TbMatrial")]
[Index("LevelId", Name = "IX_TbMatrial_LevelId")]
public partial class TbMatrial
{
    [Key]
    [Column("MatrialID")]
    public int MatrialId { get; set; }

    [StringLength(200)]
    public string MatrialName { get; set; } = null!;

    public int? LevelId { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("TbMatrials")]
    public virtual TbLevel? Level { get; set; }

    [InverseProperty("Matrial")]
    public virtual ICollection<AssignmentsDone> TbAssignmentDones { get; } = new List<AssignmentsDone>();

    [InverseProperty("Matrial")]
    public virtual ICollection<TbTeacher> TbTeachers { get; } = new List<TbTeacher>();

    [InverseProperty("Matrial")]
    public virtual ICollection<TbVideo> TbVideos { get; } = new List<TbVideo>();

    [InverseProperty("Matrial")]
    public virtual ICollection<TbAssignmentLink> TbAssignmentLinks { get; } = new List<TbAssignmentLink>();

    [ForeignKey("MatrialId")]
    [InverseProperty("Matrial")]
    public virtual ICollection<TbStudent> Student { get; } = new List<TbStudent>();
}
