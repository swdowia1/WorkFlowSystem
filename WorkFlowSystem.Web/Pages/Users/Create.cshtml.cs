using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkFlowSystem.Application.DTO;
using WorkFlowSystem.Application.Services;

namespace WorkFlowSystem.Web.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserService _service;
        [BindProperty]
        public UserDto User { get; set; } = new();

        public CreateModel(UserService service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.AddUserAsync(User);

           // return RedirectToPage("Index");
            return RedirectToPage("/Index");
        }
        public void OnGet()
        {
        }
    }
}
