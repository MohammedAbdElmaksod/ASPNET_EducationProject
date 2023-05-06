using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

public partial class TbAssignmentLink
{
    [Key]
    public int AssignmentId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Link { get; set; }

    public string? AssignmentTitle { get; set; }

    public int? LevelId { get; set; }

    public int? TeacherId { get; set; }

    public int? MatrialId { get; set; }

    public int? VideoId { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("TbAssignmentLinks")]
    public virtual TbLevel? Level { get; set; }

    [ForeignKey("MatrialId")]
    [InverseProperty("TbAssignmentLinks")]
    public virtual TbMatrial? Matrial { get; set; }
    
    [ForeignKey("VideoId")]
    [InverseProperty("AssignmentLinks")]
    public virtual TbVideo? video { get; set; }

    [InverseProperty("Assignment")]
    public virtual ICollection<AssignmentsDone> TbAssignmentDones { get; } = new List<AssignmentsDone>();

    [ForeignKey("TeacherId")]
    [InverseProperty("TbAssignmentLinks")]
    public virtual TbTeacher? Teacher { get; set; }
}
