using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class AlumnissssController : BaseController
    {
        private readonly IRepositoryBase<Alumni> _repo;
        private readonly IRepositoryBase<Gender> _gender;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly IRepositoryBase<Author> _author;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        private readonly ISessionConfigService _sessionConfigService;
        public AlumnissssController(
            IRepositoryBase<Alumni> repo,
            IRepositoryBase<Gender> gender,
            IRepositoryBase<ListBooks> lists,
            IRepositoryBase<Author> author,
            IMapper mapper,
            IHostingEnvironment _environment,
            ISessionConfigService SessionService

            ):base(SessionService)

        {   
             _repo = repo;
            _gender = gender;
            _listbooks = lists;
            _author = author;
            _mapper = mapper;
            Environment = _environment;
           _sessionConfigService = SessionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Alumni> lists= await _repo.GetList(includes: new List<string> { "gender", "ListBooks", "Author"} );
            List<AlumniVM> viewmodel = _mapper.Map<List<Alumni>, List<AlumniVM>>(lists);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extentions + "";

            }
            return Json(viewmodel);


        }
    }
}
