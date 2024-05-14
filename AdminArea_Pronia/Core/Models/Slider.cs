using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaCore.Models
{
    public class Slider : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubTitle { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public string? ImgUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile? ImgFile { get; set; } = null!;
    }
}
