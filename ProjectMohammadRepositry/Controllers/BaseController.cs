using Asp.Common.SessionConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectMohammadRepositry.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISessionConfigService _SessionService;
        public BaseController(ISessionConfigService SessionService)
        {
            _SessionService = SessionService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(_SessionService.CurrentUserId) || _SessionService.CurrentUserName == null )
            {
                Response.Redirect("/Authentication/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
