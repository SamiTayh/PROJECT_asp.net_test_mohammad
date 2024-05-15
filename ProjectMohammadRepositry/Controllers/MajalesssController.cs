using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class MajalesssController : BaseController
    {
        private readonly IRepositoryBase<Majales> _repo;
        private readonly IRepositoryBase<Gender> _listgender;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly ISessionConfigService _sessionService;
        private IMapper _mapper;
        private IHostingEnvironment Environment;

        public MajalesssController(IRepositoryBase<Majales> repo,
            IRepositoryBase<Gender> listgender,
            IRepositoryBase<ListBooks> listbooks,
            IMapper mapper,
            ISessionConfigService SessionService,
            IHostingEnvironment _environment
            
            ):base(SessionService)
        {
            _repo = repo;
            _listgender = listgender;
            _listbooks = listbooks;
            _mapper = mapper;
            Environment = _environment;
            _sessionService = SessionService;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Majales> res = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks" });
            List<MajalesVM> Viewmodel = _mapper.Map<List<Majales>, List<MajalesVM>>(res);
            foreach (var item in Viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(Viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
        {
            MajalesVM vm= new MajalesVM();
            ViewData["gender"] = await _listgender.GetList();
            ViewData["lists"] =await _listbooks.GetList();
            if(id == 0 || id == null)
            {
               return PartialView();
            }
            else
            {
                Majales res  = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Majales, MajalesVM>(res);
                return PartialView(vm);
            }
            

        }
        [HttpPost]
        public async Task<IActionResult> Form(MajalesVM insert)
        {
            Majales model;
            model = _mapper.Map<MajalesVM, Majales>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if (insert.Id==0 || insert.Id==null)
            {
              done=await _repo.Add(model);
            }
            else
            {
                done = await _repo.Update(model);
            }
            return Json(new { done });

        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z=>z.Id==id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Majales del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done=done });

        }
    }
}
