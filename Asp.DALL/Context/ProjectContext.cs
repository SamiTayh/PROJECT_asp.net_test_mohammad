using Asp.DALL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.DALL.Context
{
    public partial class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            
        }
        public ProjectContext(DbContextOptions<ProjectContext>options ):base(options) 
        {
                
        }
        public virtual DbSet<Product>products { get; set; }
        public virtual DbSet<PromationBook> promations { get; set; }
        public virtual DbSet<Fileextention> fileextention { get; set; }
        public virtual DbSet<ScientaficPromation> scientaficPromationss { get;set; }
        public virtual DbSet<Survey> surveys { get; set; }
        public virtual DbSet<PromationReaserch> PromationReaserchs { get; set; }
        public virtual DbSet<Mohammad>Mohammads { get; set; }
        public virtual DbSet<Languges> Langugess { get; set; }
        public virtual DbSet<Majales> Majaless { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Decerator> Decerators { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<ManegmentNet> Manegments { get;set; }
        public virtual DbSet<Department> Departments { get;set; }
        public virtual DbSet<Author> Authors { get;set; }
        public virtual DbSet<Greeting> Greetingsss { get; set; }
        public virtual DbSet<TSAP> TSAPs { get; set; }
        public virtual DbSet<PeaNbu> PeaNbuss { get; set; }
        public virtual DbSet<Academic> Academicss { get; set; }
        public virtual DbSet<Alumni> Alumniss { get; set; }
        public virtual DbSet<Ethreaa> Ethreaass { get; set; }
        public virtual DbSet<Wigoo> Wigooes { get; set;}
        public virtual DbSet<TransVisa> TransVisaes { get; set;}
        public virtual DbSet<CodeAgent> CodeAgents { get; set; }
        public virtual DbSet<Sponser> Sponsers { get; set; }
        public virtual DbSet<CodeBank> CodeBanks { get; set; }


    }
}
