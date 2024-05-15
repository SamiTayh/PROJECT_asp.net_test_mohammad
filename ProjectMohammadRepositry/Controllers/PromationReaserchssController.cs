using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Migrations;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ProjectMohammadRepositry.Controllers
{
    public class PromationReaserchssController : BaseController
    {
        private readonly IRepositoryBase<PromationReaserch> _repo;
        private readonly IRepositoryBase<Gender> _genderlist;
        private readonly IRepositoryBase<ListBooks> _booklist;
        private IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        private IHostingEnvironment Environment;
        public PromationReaserchssController(IRepositoryBase<PromationReaserch> repo,
            IRepositoryBase<Gender>genderlist,
            IRepositoryBase<ListBooks>booklist,
            IMapper mapper,
             ISessionConfigService SessionService,
            IHostingEnvironment _environment):base(SessionService)


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
            List<PromationReaserch> reaserch = await _repo.GetList(includes: new List<string> { "Gender", "ListBooks" });
            List<PromationReaserchVM> Viewmodel = _mapper.Map<List<PromationReaserch>, List<PromationReaserchVM>>(reaserch);
            foreach (var item in Viewmodel)
            {
                item.Filepath = "../Attachment/" + item.Id + "." + item.Extention + "";

            }
            return Json(Viewmodel);

        }
        public async Task<IActionResult> Form(int ? id)
        {
            PromationReaserchVM vm =new PromationReaserchVM();
            ViewData["gender"] = await _genderlist.GetList();
            ViewData["lists"] = await _booklist.GetList();


            if (id == 0 || id==null) {

                return PartialView();
            }
            else
            {
              PromationReaserch res  =await _repo.GetOne(z =>z.Id == id);
                vm = _mapper.Map<PromationReaserch, PromationReaserchVM>(res);
                return PartialView(vm);

            }
          

        }
        [HttpPost]
        public async Task<IActionResult> Form(PromationReaserchVM insert)
        {
            PromationReaserch model;
            model = _mapper.Map<PromationReaserchVM, PromationReaserch>(insert);
            model.File = "../Attachment";
            var xx = Path.GetFileName(insert.Attach.FileName).Split(".");
            model.Extention = Path.GetFileName(insert.Attach.FileName).Split(".")[xx.Count() - 1];
            bool done = false;
            if (insert.Id == null || insert.Id==0)
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
            return Json(new { done });

        }
        public async Task<IActionResult> Delete(int ? id)
        {
            return PartialView(await _repo.GetOne(z =>z.Id==id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(PromationReaserch del)
        {
            bool done = false;
            await _repo.Delete(del);
            return Json(new { done=done });

        }
    }
}
