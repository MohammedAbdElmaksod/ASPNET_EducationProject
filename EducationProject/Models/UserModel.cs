using Microsoft.Build.Framework;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace EducationProject.Models
{
    public partial class UserModel
    {
        public string? FullName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public bool? Subscribe { get; set; }
        public int? LevelId { get; set; }
        public string? StudentID { get; set; }
        public string? returnUrl { get; set; }

            
        
    }
}
