using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class MohammadtayehController : BaseController
    {
        private readonly IRepositoryBase<Mohammad> _repo;
        private readonly IRepositoryBase<Gender> _genderlist;
        private readonly IRepositoryBase<ListBooks> _booklist;
        private IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        private IHostingEnvironment Environment;

        public MohammadtayehController(IRepositoryBase<Mohammad>repo,
            IRepositoryBase<Gender>genderlist,
            IRepositoryBase<ListBooks>booklist,
            IMapper mapper,
            ISessionConfigService SessionService,
            IHostingEnvironment _environment
            ):base(SessionService)
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
            List<Mohammad> res = await _repo.GetList(includes: new List<string> { "Gender" , "ListBooks" });
            List<MohammadVM> viewmodel = _mapper.Map<List<Mohammad>, List<MohammadVM>>(res);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
        {
            MohammadVM vm=new MohammadVM();
            ViewData["gender"] = await _genderlist.GetList();
            ViewData["lists"] =await _genderlist.GetList();
            if(id == 0 || id == null)
            {
                return PartialView();
            }
            else
            {
                Mohammad res =await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Mohammad, MohammadVM>(res);
                return PartialView(vm);

            }


        }
        [HttpPost]
        public async Task<IActionResult> Form(MohammadVM insert)
        {
            Mohammad model;
            model = _mapper.Map<MohammadVM, Mohammad>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if(insert.Id==0 || insert.Id == null)
            {
                done=await _repo.Add(model);
            }
            else
            {
                done = await _repo.Update(model);

            }
            if (insert.Attach != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Attachment");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name = model.Id.ToString() + "." + model.Extention;
                using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                {
                    insert.Attach.CopyTo(stream);
                }
            }
            return Json(new {done});

        }
    }
}
