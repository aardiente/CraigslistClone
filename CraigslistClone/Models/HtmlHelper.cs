using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraigslistClone.Models
{
    public static class HtmlExtensions
    {
        public static IHtmlContent DisabledIf(this IHtmlHelper htmlHelper, bool condition)
                => new HtmlString(condition ? "disabled=\"disabled\"" : "");
    }
}
