using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Table("TbTeacher")]
public partial class TbTeacher
{
    [Key]
    public int TeacherId { get; set; }

    [StringLength(200)]
    public string TeacherName { get; set; } = null!;

    public int? MatrialId { get; set; }

    [ForeignKey("MatrialId")]
    [InverseProperty("TbTeachers")]
    public virtual TbMatrial? Matrial { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<TbAssignmentLink>? TbAssignmentLinks { get; } = new List<TbAssignmentLink>();

    [InverseProperty("Teacher")]
    public virtual ICollection<TbVideo>? TbVideos { get; } = new List<TbVideo>();

    [InverseProperty("teacher")]
    public virtual ICollection<AssignmentsDone> TbAssignmentDones { get; } = new List<AssignmentsDone>();
}
