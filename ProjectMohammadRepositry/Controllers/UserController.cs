using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMohammadRepositry.Controllers
{
    public class UserController : BaseController
    {
        private readonly IRepositoryBase<User> _repo;
        private readonly IRepositoryBase<Role> _rolelist;
        private IMapper _mapper;
        private readonly ISessionConfigService _sessionService;
        public UserController(IRepositoryBase<User> repo, IRepositoryBase<Role> rolelist, IMapper mapper, ISessionConfigService SessionService):base(SessionService)
        {
            _repo = repo;
            _rolelist = rolelist;
            _mapper = mapper;
            _sessionService = SessionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<User> lists = await _repo.GetList(includes: new List<string> { "Role" });
            List<UserVM> viewmodel = _mapper.Map<List<User>, List<UserVM>>(lists);
            return Json(viewmodel);
        }
        public async Task<IActionResult> Form(int? id)
        {
            UserVM vm = new UserVM();
            ViewData["RoleId"] = await _rolelist.GetList();
            if (id == 0 || id == null)
            {
                return PartialView();
            }
            else
            {
                User entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<User, UserVM>(entity);
            }
            return PartialView(vm);

        }
        [HttpPost]
        public async Task<IActionResult> Form(UserVM insert)
        {
            User model;
            model = _mapper.Map<UserVM, User>(insert);
            bool done = false;
            var user = await _repo.GetOne(e => e.UserName == model.UserName);
            string msg = "";
            if (insert.Id == 0 || insert.Id == null)
            {
                if (user != null)
                {
                    done = false;
                    msg = "مكرر";
                }
                else
                {
                    done = await _repo.Add(model);
                }
            }
            else
            {
                if (user != null && user.Id != model.Id)
                {
                    done = false;
                    msg = "مكرر";
                }
                else
                {
                    done = await _repo.Update(model);
                }

            }
            return Json(new { done = done, msg = msg });


        }
        public async Task<IActionResult> Delete(int? id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User del)
        {
            bool done = false;
            done = await _repo.Delete(del);
            return Json(new { done = done });
        }
    }
}
