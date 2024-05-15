using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using ASP.Resources;
using ASP.Resources.cs;

namespace ProjectMohammadRepositry.Infra
{
    public class Inject
    {
        public void InjectClass(IServiceCollection services)
        {
            services.AddScoped<IRepositoryBase<Product>, RepositoryBase<Product>>();
            services.AddScoped<IRepositoryBase<PromationBook>, RepositoryBase<PromationBook>>();
            services.AddScoped<IRepositoryBase<Fileextention>, RepositoryBase<Fileextention>>();
            services.AddScoped<IRepositoryBase<Gender>, RepositoryBase<Gender>>();
            services.AddScoped<IRepositoryBase<ScientaficPromation>, RepositoryBase<ScientaficPromation>>();
            services.AddScoped<IRepositoryBase<ListBooks>, RepositoryBase<ListBooks>>();
            services.AddScoped<IRepositoryBase<Survey>, RepositoryBase<Survey>>();
            services.AddScoped<IRepositoryBase<PromationReaserch>,RepositoryBase<PromationReaserch>>();
            services.AddScoped<IRepositoryBase<Mohammad>, RepositoryBase<Mohammad>>();
            services.AddScoped<IRepositoryBase<Languges>, RepositoryBase<Languges>>();
            services.AddScoped<IRepositoryBase<Majales>, RepositoryBase<Majales>>();
            services.AddScoped<IRepositoryBase<Employee>, RepositoryBase<Employee>>();
            services.AddScoped<IRepositoryBase<Student>,RepositoryBase<Student>>();
            services.AddScoped<IRepositoryBase<Travel>, RepositoryBase<Travel>>();
            services.AddScoped<IRepositoryBase<Decerator>,RepositoryBase<Decerator>>();
            services.AddScoped<IRepositoryBase<User>,RepositoryBase<User>>();
            services.AddScoped<IRepositoryBase<Role>,RepositoryBase<Role>>();
            services.AddScoped<IRepositoryBase<Material>, RepositoryBase<Material>>();
            services.AddScoped<IRepositoryBase<ManegmentNet>,RepositoryBase<ManegmentNet>>();
            services.AddScoped<IRepositoryBase<Department>,RepositoryBase<Department>>();
            services.AddScoped<IRepositoryBase<Author>,RepositoryBase<Author>>();
            services.AddScoped<IRepositoryBase<Greeting>, RepositoryBase<Greeting>>();
            services.AddScoped<IRepositoryBase<TSAP>, RepositoryBase<TSAP>>();
            services.AddScoped<IRepositoryBase<PeaNbu>, RepositoryBase<PeaNbu>>();
            services.AddScoped<IRepositoryBase<Academic>, RepositoryBase<Academic>>();
            services.AddScoped<IRepositoryBase<Alumni>, RepositoryBase<Alumni>>();
            services.AddScoped<IRepositoryBase<Ethreaa>,RepositoryBase<Ethreaa>>();
            services.AddScoped<IRepositoryBase<Wigoo>,RepositoryBase<Wigoo>>();
            services.AddScoped<IRepositoryBase<TransVisa>,RepositoryBase<TransVisa>>();
            services.AddScoped<IRepositoryBase<CodeAgent>,RepositoryBase<CodeAgent>>();
            services.AddScoped<IRepositoryBase<Sponser>,RepositoryBase<Sponser>>();
            services.AddScoped<IRepositoryBase<CodeBank>, RepositoryBase<CodeBank>>();

            //localiztion
            services.AddScoped<ISessionConfigService, SessionConfigService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMajalesResx,MajalesResx>();

        }
    }
}
