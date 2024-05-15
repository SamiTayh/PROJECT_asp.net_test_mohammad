using Asp.DALL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Asp.DALL.Viewmodel
{
    public class StudentVM
    {

        [Key]
        public int Studentid { get; set; }
        [Required]
        public string? Studentname { get; set; }
        [Required]
        public string? Studentemail { get; set; }
        [Required]
        public int Studentphone { get; set; }
        [Required]
        public string? Studentposetion { get; set; }
        [Required]
        public string? Studentdescription { get; set; }
        [Required]
        public int Studentage { get; set; }
        public string? File { get; set; }
        public string? Filepath { get; set; }
        public string? Extentions { get; set; }
        public IFormFile Attach { get; set; }
        public DateTime? Date { get; set; }
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;

        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;
        public ICollection<ManegmentNet> Manegments { get; set; }
    }
}
