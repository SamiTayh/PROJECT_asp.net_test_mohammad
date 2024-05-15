using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Student
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
        public string? Extentions { get; set; }
        public DateTime? Date { get; set; }
        [ForeignKey("gender")]
        public int Genderid { get; set; }
        public Gender? Gender { get; set; } = null;

        [ForeignKey("lists")]
        public int Listid { get; set; }
        public ListBooks? ListBooks { get; set; } = null;


        //[ForeignKey("Manegments")]
        //public int ManegmentNetId { get; set; }
        //public ManegmentNet Manegments { get; set; }





        [ForeignKey("Manegments")]
        public int? Manegmentid { get; set; }
        public ManegmentNet? Manegments { get; set; } = null;



    }
}
