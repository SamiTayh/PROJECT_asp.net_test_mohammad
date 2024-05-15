using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class FileextentionsController : BaseController
    {
        private readonly IRepositoryBase<Fileextention> _repo;
        private readonly IRepositoryBase<Gender> _repoGender;
        private IHostingEnvironment Environment;
        private readonly IMapper _mapper;
        private readonly ISessionConfigService _sessionService;


        public FileextentionsController(IRepositoryBase<Fileextention> repo, IRepositoryBase<Gender> repoGender, IHostingEnvironment _environment
            , IMapper mapper, ISessionConfigService SessionService
            ):base(SessionService)
        {
             
            _repo = repo;
            _repoGender = repoGender;
            Environment = _environment;
            _mapper = mapper;
            _sessionService = SessionService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
           
            List<Fileextention> filees = await _repo.GetList(includes: new List<string> { "Gender" });
            //List<Fileextention> filees = await _repo.GetList();
            List<FileextentionVM> ViewModel = _mapper.Map<List<Fileextention>, List<FileextentionVM>>(filees);
            foreach (var item in ViewModel)
            {
                item.FilePath = "../Attachment/" + item.Id + "." + item.Extention + "";
            }
            return Json(ViewModel);
        }
        public async Task<IActionResult> Form(int ? id)

        {
            FileextentionVM ViewModel = new FileextentionVM();
            //var x = await _repoGender.GetList();
            ViewData["gender"] = await _repoGender.GetList();

            if (id == 0 || id==null) {

                return PartialView();
            }
            else
            {
                Fileextention entity = await _repo.GetOne(z => z.Id == id);
                ViewModel = _mapper.Map<Fileextention, FileextentionVM>(entity);
                return PartialView(ViewModel);

            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(FileextentionVM Insert)
        {
            Fileextention model;
            model = _mapper.Map<FileextentionVM, Fileextention>(Insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(Insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(Insert.Attach.FileName).Split(".")[xx.Count()-1];
            bool done = false;
            if (Insert.Id == null || Insert.Id == 0) {
                done = await _repo.Add(model);
            }
            else
            {

                done = await _repo.Update(model);

            }
                if (Insert.Attach != null)
                {
                    string path = Path.Combine(this.Environment.WebRootPath, "Attachment");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string name = model.Id.ToString() + "." + model.Extention;
                    using (FileStream stream = new FileStream(Path.Combine(path, name), FileMode.Create))
                    {
                        Insert.Attach.CopyTo(stream);
                    }
                }


            
            return Json(new {done});

        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Fileextention del)
        {
           bool done = false;
            await _repo.Delete(del);
            return Json(new {done=done});

        }
    }
}
