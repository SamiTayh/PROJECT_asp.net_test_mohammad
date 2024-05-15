using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace ProjectMohammadRepositry.Controllers
{
    public class EthreaasssController : BaseController
    {
        private readonly IRepositoryBase<Ethreaa> _repo;
        private readonly IRepositoryBase<Gender> _Listgender;
        private readonly IRepositoryBase<ListBooks> _Listbooks;
        private readonly IRepositoryBase<Author> _ListAuthor;
        private IMapper _mapper;
        private IHostingEnvironment Environment;
        private readonly ISessionConfigService _sessionConfigService;
        public EthreaasssController(IRepositoryBase<Ethreaa> repo,
                                    IRepositoryBase<Gender> Listgender,
                                    IRepositoryBase<ListBooks> Listbooks,
                                    IRepositoryBase<Author> ListAuthor,
                                    IMapper mapper,
                                    IHostingEnvironment _environment,
                                    ISessionConfigService SessionService

            ):base(SessionService)
        {
            
            _repo = repo;
            _Listgender= Listgender;
            _Listbooks= Listbooks;
            _ListAuthor= ListAuthor;
            _mapper= mapper;
            Environment= _environment;
            _sessionConfigService = SessionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Ethreaa> lists = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks", "Author" });
            List<EthreaaVM> viewmodel = _mapper.Map<List<Ethreaa>, List<EthreaaVM>>(lists);
            foreach (var item in viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(viewmodel);
        }
        public async Task<IActionResult> Form(int ? id)
        {
            EthreaaVM vm=new EthreaaVM();
            ViewData["gender"] = await _Listgender.GetList();
            ViewData["lists"] = await _Listbooks.GetList();
            ViewData["Author"] = await _ListAuthor.GetList();
            if(id==null || id == 0)
            {
                return PartialView(vm);
            }
            else
            {
                Ethreaa entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Ethreaa, EthreaaVM>(entity);
                return PartialView(vm);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(EthreaaVM insert)
        {
            Ethreaa model;
            model = _mapper.Map<EthreaaVM, Ethreaa>(insert);
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
                done=await _repo.Update(model);

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
        public async Task<IActionResult> Delete(Ethreaa del) {
            bool done= false;
            done=await _repo.Delete(del);
            return Json(new { done = done });
        
        }
    }
}
