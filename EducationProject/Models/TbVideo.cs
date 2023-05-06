using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Index("LevelId", Name = "IX_TbVideos_LevelId")]
[Index("TeacherId", Name = "IX_TbVideos_TeacherId")]
public partial class TbVideo
{
    [Key]
    [Column("VideoID")]
    public int VideoId { get; set; }

    [Column("URL")]
    [StringLength(500)]
    public string? Url { get; set; } = null!;

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("Chapter")]
    public string Chapter { get; set; } = null!;

    public int semester { get; set; }

    [Column("Lesson")]
    public string Lesson { get; set; } = null!;

    public int LevelId { get; set; }

    public int? MatrialId { get; set; }

    public int? TeacherId { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("TbVideos")]
    public virtual TbLevel? Level { get; set; }

    [ForeignKey("MatrialId")]
    [InverseProperty("TbVideos")]
    public virtual TbMatrial? Matrial { get; set; }

    [ForeignKey("TeacherId")]
    [InverseProperty("TbVideos")]
    public virtual TbTeacher? Teacher { get; set; }

    
    [InverseProperty("video")]
    public virtual ICollection<TbAssignmentLink>? AssignmentLinks { get; } = new List<TbAssignmentLink>();
    
}
