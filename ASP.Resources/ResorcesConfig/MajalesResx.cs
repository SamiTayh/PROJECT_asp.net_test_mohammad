using ASP.Resources.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Resources.cs
{
    public class MajalesResx:IMajalesResx
    {
        private IStringLocalizer<Resources.MajalesResx> _localizer;
        public MajalesResx(IStringLocalizer<Resources.MajalesResx> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
}
