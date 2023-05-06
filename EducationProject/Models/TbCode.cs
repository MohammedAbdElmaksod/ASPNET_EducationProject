using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Models;

[Index("LevelId", Name = "IX_TbCodes_LevelId")]
[Index("StudentId", Name = "IX_TbCodes_StudentID")]
public partial class TbCode
{
    [Key]
    [Column("CodeID")]
    public int CodeId { get; set; }

    [StringLength(20)]
    public string Code { get; set; } = null!;

    [Column("StudentID")]
    public string? StudentId { get; set; }

    public int? LevelId { get; set; }

    [ForeignKey("LevelId")]
    [InverseProperty("TbCodes")]
    public virtual TbLevel? Level { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("TbCodes")]
    public virtual TbStudent? Student { get; set; } = null!;
}
