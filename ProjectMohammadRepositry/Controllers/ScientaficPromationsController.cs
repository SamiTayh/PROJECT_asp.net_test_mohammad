using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ProjectMohammadRepositry.Controllers
{
    public class ScientaficPromationsController : BaseController
    {
        private readonly IRepositoryBase<ScientaficPromation> _repo;
        private readonly IRepositoryBase<Gender> _Genderlist;
        private readonly IRepositoryBase<ListBooks> _listBooks;
        private readonly IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        private IHostingEnvironment Environment;

        public ScientaficPromationsController(IRepositoryBase <ScientaficPromation> repo, IRepositoryBase<Gender>Genderlist,IRepositoryBase<ListBooks> ListBooks,
            IMapper mapper , IHostingEnvironment _environment, ISessionConfigService SessionService):base(SessionService)

        {
            _repo = repo;
            _Genderlist = Genderlist;
            _listBooks= ListBooks;
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
           
            List<ScientaficPromation> scientafic = await _repo.GetList(includes: new List<string> {"Gender", "ListBooks" });
            List<ScientaficPromationVM> Viewmodel = _mapper.Map<List<ScientaficPromation>, List<ScientaficPromationVM>>(scientafic);
            foreach (var item in Viewmodel)
            {
                item.FilePath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(Viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
        {
            ScientaficPromationVM vm=new ScientaficPromationVM();
            ViewData["gender"] = await _Genderlist.GetList();
            ViewData["lists"] = await _listBooks.GetList();
            if (id == null || id==0 ) 
            
            {

                return PartialView();
            
            
            }
            else
            {
                ScientaficPromation entity=await _repo.GetOne(z =>z.Id == id);
                vm=_mapper.Map<ScientaficPromation,ScientaficPromationVM>(entity);
               return PartialView(vm);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(ScientaficPromationVM scientafic)
        {
            ScientaficPromation model;
            model = _mapper.Map<ScientaficPromationVM, ScientaficPromation>(scientafic);
            model.File = "../Attachment";
            var xx = Path.GetFileName(scientafic.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(scientafic.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done=false;
            if(scientafic.Id == 0 || scientafic.Id == 0)
            {

                done=await _repo.Add(model);
            }
            else
            {
                done = await _repo.Update(model);
            }
            if (scientafic.Attach != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Attachment");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name = model.Id.ToString() + "." + model.Extention;
                using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                {
                    scientafic.Attach.CopyTo(stream);
                }
            }
            return Json(new { done });
        }
        public async Task<IActionResult> Delete(int ? id)

        {
            return PartialView(await _repo.GetOne(z => z.Id == id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(ScientaficPromation del)
        {
            bool done = false;
            await _repo.Delete(del);
            return Json(new { done=done });

        }
    }
}
