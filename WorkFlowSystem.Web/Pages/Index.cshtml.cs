using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.Services;
using WorkFlowSystem.Domain.Entities;

namespace WorkFlowSystem.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UserService _userService;

        public List<User> Users { get; set; } = [];

        public IndexModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGet()
        {
            Users = await _userService.GetUsersAsync();
        }
    }
}
