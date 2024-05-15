﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Alumni
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string ? Email { get; set; }
        public string? File { get; set; }
        public DateTime Date { get; set; }
        public string ? Extentions { get; set; }
        [ForeignKey("gender")]
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;
        [ForeignKey("lists")]
        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author? Author { get; set; } = null;

    }
}
