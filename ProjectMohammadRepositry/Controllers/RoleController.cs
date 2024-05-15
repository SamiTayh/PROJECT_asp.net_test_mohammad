using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMohammadRepositry.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRepositoryBase<Role> _repo;
        private readonly IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        // private readonly IRepositoryBase<Role> _repo;
        //private IMapper _mapper;
        public RoleController(IRepositoryBase<Role> repo, IMapper mapper, ISessionConfigService SessionService):base(SessionService)
        {
            _repo = repo;
            _mapper = mapper;
            _sessionService = SessionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Role> lists = await _repo.GetList();
            List<RoleVM> viewmodel = _mapper.Map<List<Role>, List<RoleVM>>(lists);
            return Json(viewmodel);
        }
        public async Task<IActionResult> Form(int? id)

        {
            RoleVM vm = new RoleVM();
            if (id == 0 || id == null)
            {
                return PartialView();
            }
            else
            {
                Role entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Role, RoleVM>(entity);
                return PartialView(vm);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Form(RoleVM insert)
        {
            Role model;
            model = _mapper.Map<RoleVM, Role>(insert);
            bool done = false;
            if (insert.Id == 0 || insert.Id == null)
            {
                done = await _repo.Add(model);
            }
            else
            {
                done = await _repo.Update(model);

            }
            return Json(new { done });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Role del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done = done });
        }
    }
}
