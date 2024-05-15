using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Languges
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? LangugeName { get; set; }
        [Required]
        public string? LangugeDescription { get; set; }
        [Required]
        public string? LangugeTitle { get; set; }
        [Required]
        public string? Age { get; set; }
        public DateTime Date { get; set; }
        public string? File { get; set; }
        public string? Extention { get; set; }
        [ForeignKey("gender")]
        public int Genderid {  get; set; }
        public Gender? Gender { get; set; } = null;
        [ForeignKey("lists")]
        public int listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;



    }
}
