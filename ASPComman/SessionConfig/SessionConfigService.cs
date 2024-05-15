using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPComman.SessionConfig
{
    public class SessionConfigService:ISessionConfigService
    {
        private readonly IHttpContextAccessor _accessor;
        public SessionConfigService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string CurrentLang => _accessor.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;

    }
}
