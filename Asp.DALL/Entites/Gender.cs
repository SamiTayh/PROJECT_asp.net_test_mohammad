using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Entites
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Fileextention> Fileextentions { get; set;}
        public ICollection<ScientaficPromation> scientaficPromations { get; set;}
         public ICollection<Survey> surveys { get; set;}
        public ICollection<PromationReaserch> PromationReaserchs { get; set; }
        public ICollection<Mohammad> Mohammads { get; set; }
        public ICollection<Languges> Languges { get; set; }
        public ICollection<Majales> Majaless { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Travel> Travels { get; set; }
        public ICollection<Decerator> Decerators { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<ManegmentNet> Manegments { get; set; }
        public ICollection<Greeting> Greetings { get; set; }
        public ICollection<TSAP> TSAPssss { get; set; }
        public ICollection<PeaNbu> peaNbus { get; set; }
        public ICollection<Academic> Academics { get; set; }
        public ICollection<Alumni> Alumnis { get; set; }
        public ICollection<Ethreaa> Ethreaas { get; set; }
        public ICollection<Wigoo> Wigooes { get; set;}
        public ICollection<TransVisa> TransVisaes { get; set;}
        public ICollection<CodeAgent> CodeAgents { get; set; }
        public ICollection<Sponser> Sponsers { get; set; }
        public ICollection<CodeBank> CodeBanks { get; set; }
    }
}
