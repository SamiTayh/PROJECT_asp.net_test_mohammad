using Asp.Common.SessionConfig;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Common.Sessions
{
    public class InitializationSessionConfig
    {
        private readonly IHttpContextAccessor _accessor = new HttpContextAccessor();
        public void Initialization(out ISessionConfigService _session)
        {
            _session = new SessionConfigService(_accessor);
        }
    }
}
