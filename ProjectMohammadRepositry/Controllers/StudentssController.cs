using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class StudentssController : BaseController
    {
        private readonly IRepositoryBase<Student> _repo;
        private readonly IRepositoryBase<Gender> _genderlist;
        private readonly IRepositoryBase<ListBooks> _bookslist;
        private readonly ISessionConfigService _sessionService;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        public StudentssController(IRepositoryBase<Student> repo,
            IRepositoryBase<Gender> genderlist,
            IRepositoryBase<ListBooks> booklist,
            IMapper mapper,
             ISessionConfigService SessionService,
            IHostingEnvironment _environment ):base(SessionService)


        {
            _repo = repo;
            _genderlist = genderlist;
            _bookslist = booklist;
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
            List<Student> resourse = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks" });
            List<StudentVM> viewmodel = _mapper.Map<List<Student>, List<StudentVM>>(resourse);

            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Studentid + "." + item.Extentions + "";

            }
            return Json(viewmodel);

        }
        public async Task<IActionResult> Form(int ? id)
        {
            StudentVM vm = new StudentVM();
            ViewData["gender"] = await _genderlist.GetList();
            ViewData["lists"]=await _bookslist.GetList();

            if(id==0 || id==null)
            {
                return PartialView();
            }
            else
            {
                Student entity = await _repo.GetOne(z => z.Studentid == id);
                vm = _mapper.Map<Student, StudentVM>(entity);
                return PartialView(vm);

                
            }
           

        }
        [HttpPost]
        public async Task<IActionResult> Form(StudentVM insert)
        {
            Student model;
            model = _mapper.Map<StudentVM, Student>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extentions = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if(insert.Studentid == 0 || insert.Studentid == null)
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
                string name = model.Studentid.ToString() + "." + model.Extentions;
                using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                {
                    insert.Attach.CopyTo(stream);
                }
            }
            return Json(new { done });
        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Studentid == id));

        }
        [HttpPost]
        public async Task<IActionResult>Delete(Student del)
        {
            bool done = false;
            await _repo.Delete(del);
            return Json(new { done=done });
        }

    }
}
