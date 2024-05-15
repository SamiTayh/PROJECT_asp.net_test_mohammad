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
    public class SurveyssController : BaseController
    {
        private readonly IRepositoryBase<Survey> _repo;
        private readonly IRepositoryBase<Gender> _genderlist;
        private readonly IRepositoryBase<ListBooks> _booklist;
        private IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        private IHostingEnvironment Environment;
        public SurveyssController(IRepositoryBase<Survey>repo,IRepositoryBase<Gender> genderlist,IRepositoryBase<ListBooks> booklist,IMapper mapper, IHostingEnvironment _environment, ISessionConfigService SessionService):base(SessionService)
        {
            _repo = repo;
            _genderlist = genderlist;
            _booklist = booklist;
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
            List<Survey> ser = await _repo.GetList(includes: new List<string>{"Gender", "ListBooks" } );
            List<SurveyVM> viewmodel =  _mapper.Map<List<Survey>, List<SurveyVM>>(ser);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
         {
            SurveyVM vm=new SurveyVM();
            ViewData["gender"] = await _genderlist.GetList();
            ViewData["lists"] = await _booklist.GetList();

            if (id == 0 || id == null)
            {
                return PartialView();

            }
            else
            {
                Survey entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Survey, SurveyVM>(entity);
               return PartialView(vm);
            }


        }
        [HttpPost]
        public async Task<IActionResult> Form(SurveyVM insertsurvey)
        {
            Survey model;
            model=_mapper.Map<SurveyVM,Survey>(insertsurvey);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insertsurvey.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insertsurvey.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if (insertsurvey.Id == null || insertsurvey.Id==0) {
            
              done=await _repo.Add(model);
            }
            else
            {
                done=await _repo.Delete(model);
            }
            if (insertsurvey.Attach != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Attachment");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name = model.Id.ToString() + "." + model.Extention;
                using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                {
                    insertsurvey.Attach.CopyTo(stream);
                }
            }
            return Json(new {done});



        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Survey del)
        {
            bool done = false;
            await _repo.Delete(del);
            return Json(new { done = done });

        }
    }
}
