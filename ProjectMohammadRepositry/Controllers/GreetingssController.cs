using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ProjectMohammadRepositry.Controllers
{
    public class GreetingssController : BaseController
    {
        private readonly IRepositoryBase<Greeting> _repo;
        private readonly IRepositoryBase<Gender> _listGender;
        private readonly IRepositoryBase<ListBooks> _listBooks;
        private readonly IRepositoryBase<Author> _listAuthor;
        private readonly IMapper _mapper;
        private IHostingEnvironment Environment;
        private readonly ISessionConfigService _sessionConfigService;
        public GreetingssController(
            IRepositoryBase<Greeting>repo,
            IRepositoryBase<Gender>listGender,
            IRepositoryBase<ListBooks>listBooks,
            IRepositoryBase<Author>listAuthor
            ,IMapper mapper,IHostingEnvironment _environment,
             ISessionConfigService SessionService
            ):base(SessionService)

        {
            _repo = repo;
            _listGender = listGender;
            _listBooks = listBooks;
            _listAuthor = listAuthor;
            _mapper = mapper;
            Environment= _environment;
            _sessionConfigService = SessionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Greeting> lists = await _repo.GetList(includes: new List<string> { "Author", "Gender", "ListBooks" });
            List<GreetingVM> Viewmodel=_mapper.Map<List<Greeting>,List<GreetingVM>>(lists);
            foreach (var item in Viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extentions + "";

            }
            return Json(Viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
        {
          GreetingVM vm=new GreetingVM();
            ViewData["Author"] = await _listAuthor.GetList();
            ViewData["gender"] = await _listGender.GetList();
            ViewData["lists"] = await _listBooks.GetList();

            if (id==0 || id==null) {

                return PartialView();

            }
            else
            {
                Greeting entity=await _repo.GetOne(z=>z.Id==id);
                vm = _mapper.Map<Greeting, GreetingVM>(entity);
                return PartialView(vm);
            }

        }
        [HttpPost]
        public async Task<IActionResult>Form(GreetingVM insert)
        {
            Greeting model;
            model = _mapper.Map<GreetingVM, Greeting>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extentions = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
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
            return PartialView(await _repo.GetOne(z=>z.Id==id));

        }
        [HttpPost]
        public async Task<IActionResult>Delete(Greeting del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done = done });
        }
    }
}
