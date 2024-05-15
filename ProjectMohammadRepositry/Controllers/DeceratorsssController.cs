using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class DeceratorsssController :BaseController
    {
        private readonly IRepositoryBase<Decerator> _repo;
        private readonly IRepositoryBase<Gender> _listgender;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly ISessionConfigService _sessionService;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        public DeceratorsssController(
            IRepositoryBase<Decerator> repo
           ,IRepositoryBase<Gender> listgender,
            IRepositoryBase<ListBooks> listbooks, ISessionConfigService SessionService,
            IMapper mapper,
            IHostingEnvironment _environment) : base(SessionService)

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
            List<Decerator> lists = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks" });
            List<DeceratorVM> viewmodel = _mapper.Map<List<Decerator>, List<DeceratorVM>>(lists);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }

            return Json(viewmodel);

        }
        public async Task<IActionResult> Form(int? id)

        {
            DeceratorVM vm=new DeceratorVM();
            ViewData["gender"] = await _listgender.GetList();
            ViewData["lists"]=await _listbooks.GetList();
            if (id==0 || id==null) {

                return PartialView();
            }
            else
            {
                Decerator entity = await _repo.GetOne(z=>z.Id==id);
                vm = _mapper.Map<Decerator, DeceratorVM>(entity);

                return PartialView(vm);

               
            }
        }
        [HttpPost]
        public async Task<IActionResult> Form(DeceratorVM insert)
        {
            Decerator model;
            model = _mapper.Map<DeceratorVM, Decerator>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if (insert.Id==0 || insert.Id==null) {
               
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
            return Json(new { done });

        }

        public async Task<IActionResult> Delete(int? id)
        {
            return PartialView(await _repo.GetOne(z=>z.Id==id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Decerator del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done=done });

        }
    }
}
