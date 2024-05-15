using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Resources.cs
{
    public class MajalesResx :IMajalesResx
    {
        private IStringLocalizer<MajalesResx> _localizer;
        public MajalesResx(IStringLocalizer<MajalesResx> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
}
