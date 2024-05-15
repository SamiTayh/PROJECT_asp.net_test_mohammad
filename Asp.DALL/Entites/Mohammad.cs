using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Mohammad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Age { get; set; }
        [Required]
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? File { get; set; }
        public string? Extention { get; set; }
        [ForeignKey("gender")]
        public int Genderid { get; set; }
        public Gender? Gender { get; set; }
        [ForeignKey("lists")]
        public int listsid { get; set; }
        public ListBooks? ListBooks { get; set; }
    }
}
