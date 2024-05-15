using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Common.SessionConfig
{
    public interface ISessionConfigService
    {
        string CurrentLang { get; }
        public string CurrentUserId { get;  }
        public string CurrentUserName { get; }


    }
}
