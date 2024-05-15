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
    public class TravelVM
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public string? File { get; set; }
        public string? Filepath { get; set; }
        public IFormFile Attach { get; set; }
        public string? Extention { get; set; }
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;
        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;
    }
}
