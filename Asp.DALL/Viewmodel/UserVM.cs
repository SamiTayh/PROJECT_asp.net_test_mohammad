using Asp.DALL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Viewmodel
{
    public class UserVM
    {
      
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
     
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string MSG { get; set; }
    }
}
