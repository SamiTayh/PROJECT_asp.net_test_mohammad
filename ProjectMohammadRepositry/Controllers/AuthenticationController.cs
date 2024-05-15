using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMohammadRepositry.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepositoryBase<User> _repo;
        private readonly IHttpContextAccessor _accessor;
        public AuthenticationController(IRepositoryBase<User> repo, IHttpContextAccessor accessor)
        {
            _repo = repo;
            _accessor = accessor;

        }

        public IActionResult Login()
        {
            UserVM model = new UserVM();
            model.MSG = string.Empty;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserVM model)
        {
            var user = await _repo.GetOne(e => e.UserName == model.UserName && e.Password == model.Password);
            if (user == null )
            {
               
                model.MSG = "Invalid User Name Or Password";
                return View(model);
            }
            _accessor.HttpContext.Session.SetString("CurrentUserId", model?.Id.ToString());
            _accessor.HttpContext.Session.SetString("CurrentUserName", model?.UserName);
            return View("../Home/Index");
        }
        public IActionResult Logout()
        {
            _accessor.HttpContext.Session.SetString("CurrentUserId", string.Empty);
            _accessor.HttpContext.Session.SetString("CurrentUserName", string.Empty);
            return RedirectToAction("Login");
        }
    }
}
