using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ProjectMohammadRepositry.Controllers
{
    public class EmployeesssController :BaseController
    {
        private readonly IRepositoryBase<Employee> _repo;
        private readonly IRepositoryBase<Gender> _genderlist;
        private readonly IRepositoryBase<ListBooks> _listbooks;
        private readonly ISessionConfigService _sessionService;
        private IMapper _mapper;
        private IHostingEnvironment Environment;

        public EmployeesssController(IRepositoryBase<Employee> repo,
            IRepositoryBase<Gender> genderlist,
            IRepositoryBase<ListBooks> listbooks, ISessionConfigService SessionService,
            IMapper mapper, 
            IHostingEnvironment _environment):base(SessionService)
        {
            _repo = repo;
            _genderlist = genderlist;
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
            List<Employee> lista = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks" });
            List<EmployeeVM> viewmodel = _mapper.Map<List<Employee>,List< EmployeeVM>>(lista);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(viewmodel);

        }
        public async Task<IActionResult> Form(int ? id)
        {
            EmployeeVM vm=new EmployeeVM();
            ViewData["gender"] = await _genderlist.GetList();
            ViewData["lists"]=await _listbooks.GetList();
            if(id==0 || id == null)
            {
                return PartialView();
            }
            else
            {
                Employee entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Employee, EmployeeVM>(entity);
                return PartialView(vm);
            }


        }
        [HttpPost]
        public async Task<IActionResult> Form(EmployeeVM insert)
        {
            Employee model;
            model = _mapper.Map<EmployeeVM, Employee>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if(insert.Id==0 || insert.Id == null)
            {
                done = await _repo.Add(model);
            }
            else
            {
                done= await _repo.Update(model);
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
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));


        }
        [HttpPost]
        public async Task<IActionResult> Delete(Employee del)
        {
            bool done = false;
           await _repo.Delete(del);
            return Json(new { done = done });

        }
    }
}
