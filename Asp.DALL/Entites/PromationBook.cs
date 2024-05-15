using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class PromationBook
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? BookName { get; set; }
        [Required]
        public string? BookTitle { get; set; }
        [Required]
        public float? PriceBook { get; set; }
        [Required]
        public string? DescriptionBook { get;set; }
    }
}
