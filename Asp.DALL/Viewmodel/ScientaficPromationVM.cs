using Asp.DALL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Viewmodel
{
    public class ScientaficPromationVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? PromationName { get; set; }
        [Required]
        public string? PromationDescription { get; set; }
        [Required]
        public float? PromationRate { get; set; }
        public DateTime Date { get; set; }
        public string? FilePath { get; set; }
        public string? File { get; set; }
        public string? Extention { get; set; }
        public IFormFile Attach { get; set; }
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;
        public int listid { get; set; }
        public ListBooks? ListBooks { get; set; }= null;


    }
}
