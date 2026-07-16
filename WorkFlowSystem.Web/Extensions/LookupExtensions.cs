
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkFlowSystem.Application.DTO;

namespace WorkFlowSystem.Web.Extensions
{
    public static class LookupExtensions
    {
        public static List<SelectListItem> ToSelectList(
            this IEnumerable<LookupDto> source)
        {
            return source.Select(x => new SelectListItem
            {
                Value = x.Value.ToString(),
                Text = x.Text
            }).ToList();
        }
    }
}
