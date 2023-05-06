using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Table("TbLevel")]
public partial class TbLevel
{
    [Key]
    public int LevelId { get; set; }

    [StringLength(50)]
    public string YearLevel { get; set; } = null!;

    [InverseProperty("Level")]
    public virtual ICollection<TbAssignmentLink> TbAssignmentLinks { get; } = new List<TbAssignmentLink>();

    [InverseProperty("Level")]
    public virtual ICollection<TbCode> TbCodes { get; } = new List<TbCode>();

    [InverseProperty("Level")]
    public virtual ICollection<TbMatrial> TbMatrials { get; } = new List<TbMatrial>();

    [InverseProperty("Level")]
    public virtual ICollection<TbStudent> TbStudents { get; } = new List<TbStudent>();
    [InverseProperty("Level")]
    public virtual ICollection<ApplicationUser> AppUser { get; } = new List<ApplicationUser>();

    [InverseProperty("Level")]
    public virtual ICollection<TbVideo> TbVideos { get; } = new List<TbVideo>();

    [InverseProperty("level")]
    public virtual ICollection<AssignmentsDone> TbAssignmentDones { get; } = new List<AssignmentsDone>();
}
