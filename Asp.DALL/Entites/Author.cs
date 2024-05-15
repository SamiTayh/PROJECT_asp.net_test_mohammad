using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Title { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Greeting> Greetings { get; set; }
        public ICollection<TSAP> TSAPssss { get; set; }
        public ICollection<PeaNbu> peaNbus { get; set; }
        public ICollection<Academic> Academics { get; set; }
        public ICollection<Alumni> Alumnis { get; set; }
        public ICollection<Ethreaa> Ethreaas { get; set;}
        public ICollection<Wigoo> Wigooes { get; set;}
        public ICollection<TransVisa> TransVisas { get; set; }
        public ICollection<CodeAgent> CodeAgents { get; set; }
        public ICollection<Sponser> Sponsers { get; set; }
        public ICollection<CodeBank> CodeBanks { get; set; }
    }
}
