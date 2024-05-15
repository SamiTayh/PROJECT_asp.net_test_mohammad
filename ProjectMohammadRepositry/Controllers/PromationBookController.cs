using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMohammadRepositry.Controllers
{
    public class PromationBookController : BaseController
    {
        private readonly IRepositoryBase<PromationBook> _repo;
        private readonly ISessionConfigService _sessionService;

        public PromationBookController(IRepositoryBase<PromationBook> repo, ISessionConfigService SessionService):base(SessionService)
        {
            _repo = repo;
            _sessionService = SessionService;
            
        }
        public async Task< IActionResult> Index()
        {
         
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<PromationBook> listpromation = await _repo.GetList();
            return Json(listpromation);
        }
        public async Task<IActionResult> Form(int ? id)
        {
            if (id == 0 || id==null)
            {
                return PartialView();
            }
            else
            {
                return PartialView(await _repo.GetOne(z => z.Id == id));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Form(PromationBook pro)
        {
            bool done = false;
            if (pro.Id == 0 || pro.Id==null) { 
                done=await _repo.Add(pro);
            
            }
            else
            {
                done=await _repo.Update(pro);
            }
            return Json(done);

        }
        public async Task<IActionResult> Delete(int ? id)
        {

            return PartialView(await _repo.GetOne(z => z.Id == id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(PromationBook del)
        {
            bool done = false;
            await _repo.Delete(del);
            return Json(new {done=done});

        }

    }
}
