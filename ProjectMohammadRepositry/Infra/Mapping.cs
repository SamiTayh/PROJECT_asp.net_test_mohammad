using Asp.DALL.Entites;
using Asp.DALL.Viewmodel;
using AutoMapper;

namespace ProjectMohammadRepositry.Infra
{
    public class Mapping:Profile
    {
        public Mapping()
        {
           CreateMap < FileextentionVM,Fileextention>().ReverseMap();
           CreateMap<ScientaficPromationVM, ScientaficPromation>().ReverseMap();
           CreateMap<SurveyVM, Survey>().ReverseMap(); 
           CreateMap<PromationReaserchVM,PromationReaserch>().ReverseMap();
           CreateMap<MohammadVM, Mohammad>().ReverseMap();
           CreateMap<LangugesVM,Languges>().ReverseMap();
           CreateMap<MajalesVM, Majales>().ReverseMap();
           CreateMap<EmployeeVM,Employee>().ReverseMap();
           CreateMap<StudentVM,Student>().ReverseMap();
           CreateMap<TravelVM, Travel>().ReverseMap();
           CreateMap<DeceratorVM, Decerator>().ReverseMap();
           CreateMap<UserVM, User>().ReverseMap();
           CreateMap<RoleVM, Role>().ReverseMap();
           CreateMap<MaterialVM, Material>().ReverseMap();
           CreateMap<ManegmentNetVM, ManegmentNet>().ReverseMap();
           CreateMap<DepartmentVM, Department>().ReverseMap();
           CreateMap<AuthorVM, Author>().ReverseMap();
           CreateMap<GreetingVM,Greeting>().ReverseMap();
           CreateMap<TSAPVM, TSAP>().ReverseMap();
           CreateMap<PeaNbuVM,PeaNbu>().ReverseMap();
           CreateMap<AcademicVM, Academic>().ReverseMap();
           CreateMap<AlumniVM, Alumni>().ReverseMap();
           CreateMap<EthreaaVM,Ethreaa>().ReverseMap();
           CreateMap<WigooVM,Wigoo>().ReverseMap();
           CreateMap<TransVisaVM,TransVisa>().ReverseMap();
           CreateMap<CodeAgentVM,CodeAgent>().ReverseMap();
           CreateMap<SponserVM,Sponser>().ReverseMap();
           CreateMap<CodeBankVM, CodeBank>().ReverseMap();
        }
        

    }
}
