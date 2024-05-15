using Asp.DALL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Viewmodel
{
    public class AuthorVM
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Title { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
