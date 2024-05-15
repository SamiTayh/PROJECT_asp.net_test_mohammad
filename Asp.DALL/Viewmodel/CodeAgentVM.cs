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
    public class CodeAgentVM
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? File { get; set; }
        public string? Filepath { get; set; }
        public IFormFile? Attach { get; set; }
        public string? Extentions { get; set; }
        public DateTime Date { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; } = null;
        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;
        public int AuthorId { get; set; }
        public Author? Author { get; set; } = null;
    }
}
