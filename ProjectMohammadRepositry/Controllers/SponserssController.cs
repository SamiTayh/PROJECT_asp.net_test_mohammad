using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Migrations;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class SponserssController : BaseController
    {
        private readonly IRepositoryBase<Sponser> _repo;
        private readonly IRepositoryBase<Gender> _listgender;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly IRepositoryBase<Author> _listauthor;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        private ISessionConfigService _sessionConfigService;
        public SponserssController(IRepositoryBase<Sponser> repo,
                                   IRepositoryBase<Gender> listgender,
                                   IRepositoryBase<ListBooks> listbooks,
                                   IRepositoryBase<Author> listauthor,
                                   IMapper mapper,
                                   IHostingEnvironment _environment,
                                   ISessionConfigService SessionService
            ) :base(SessionService)
        {
            _repo = repo;
            _listgender = listgender;
            _listbooks = listbooks;
            _listauthor = listauthor;
            Environment = _environment;
            _sessionConfigService = SessionService;
            _mapper = mapper;

            
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Sponser> lists = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks", "Author" });
            List<SponserVM> viewmodel = _mapper.Map<List<Sponser>, List<SponserVM>>(lists);
            foreach (var item in viewmodel)
            {
                item.FilePath = "../Attachment/" + item.Id + "." + item.Extentions + "";

            }
            return Json(lists);

        }
        public async Task<IActionResult> Form(int? id)
        {
            SponserVM vm=new SponserVM();
            ViewData["gender"] = await _listgender.GetList();
            ViewData["lists"]= await _listbooks.GetList();
            ViewData["Author"]=await _listauthor.GetList();
            if (id==0 || id == null)
            {
                return PartialView(vm);
            }

            else
            {
                Sponser entity=await _repo.GetOne(z=>z.Id==id);
                vm = _mapper.Map<Sponser, SponserVM>(entity);
                return PartialView(vm);

            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(SponserVM insert)
        {
            Sponser model;
            model = _mapper.Map<SponserVM, Sponser>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extentions = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done=false;
            if(insert.Id==0 || insert.Id == null)
            {
                done=await _repo.Add(model);

            }
            else
            {
                done=await _repo.Update(model);
            }
            if (insert.Attach != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Attachment");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name = model.Id.ToString() + "." + model.Extentions;
                using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                {
                    insert.Attach.CopyTo(stream);
                }
            }
            return Json(new {done});

        }

        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Sponser del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done = done });

        }
    }
}
