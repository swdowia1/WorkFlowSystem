
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkFlowSystem.Application.DTO;

namespace WorkFlowSystem.Web.Extensions
{
    public static class LookupExtensions
    {
        public static List<SelectListItem> ToSelectList(
    this IEnumerable<LookupDto> source,
    int? selected = null)
        {
            return source.Select(x => new SelectListItem
            {
                Value = x.Value.ToString(),
                Text = x.Text,
                Selected = selected == x.Value
            }).ToList();
        }
      
    }
}
