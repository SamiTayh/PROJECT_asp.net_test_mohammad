using Asp.DALL.Entites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Asp.DALL.Viewmodel
{
    public class FileextentionVM
    {
       
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
        [Required]

        public string? Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string? File { get; set; }
        public string? FilePath { get; set; }

        public IFormFile Attach {  get; set; }
        public string? Extention { get; set; }
        
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;


    }
}
