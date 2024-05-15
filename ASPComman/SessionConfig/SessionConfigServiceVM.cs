using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPComman.SessionConfig
{
    public class SessionConfigServiceVM
    {
        private readonly IHttpContextAccessor _accessor = new HttpContextAccessor();
        public void setSessionConfig(out ISessionConfigService _sessionConfig)
        {
            _sessionConfig = new SessionConfigService(_accessor);
        }

    }
}
