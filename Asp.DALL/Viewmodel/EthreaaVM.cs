﻿using Asp.DALL.Entites;
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
    public class EthreaaVM
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? Title { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? File { get; set; }
        public string? Filepath { get; set; }
        public DateTime Date { get; set; }
        public string? Extention { get; set; }
        public IFormFile Attach { get; set; }
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;
        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;
        public int AuthorId { get; set; }
        public Author? Author { get; set; } = null;
    }
}
