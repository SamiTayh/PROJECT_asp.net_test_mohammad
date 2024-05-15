using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ProjectMohammadRepositry.Controllers
{
    public class AcademicsssController : BaseController
    {
        private readonly IRepositoryBase<Academic> _repo;
        private readonly IRepositoryBase<Gender> _listgender;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly IRepositoryBase<Author> _listauthor;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        private readonly ISessionConfigService _sessionConfigService;
        public AcademicsssController(
            IRepositoryBase<Academic>repo,
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
            List<Academic> lists = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks", "Author" });
            List<AcademicVM> viewmodel = _mapper.Map<List<Academic>, List<AcademicVM>>(lists);
          
              foreach (var item in viewmodel)
              {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extentions + "";

               }
            return Json(viewmodel);


        }
        public async Task<IActionResult> Form(int ? id)
        {
           AcademicVM vm=new AcademicVM();
            ViewData["gender"] = await _listgender.GetList();
            ViewData["lists"] = await _listbooks.GetList();
            ViewData["Author"] = await _listauthor.GetList();
            if(id==0 || id == null)
            {
                return PartialView(vm);
            }
            else
            {
                Academic entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Academic, AcademicVM>(entity);
                return PartialView(vm);
             
            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(AcademicVM insert)
        {
            Academic model;
            model = _mapper.Map<AcademicVM, Academic>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extentions = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;

            if (insert.Id==0 || insert.Id==null)
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
            return Json(new { done });
        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Academic del)
        {
            bool done = false;
            done=await _repo.Delete(del);
            return Json(new { done = done });


        }
    }
}
