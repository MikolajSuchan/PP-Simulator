using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["ActivePage"] = "Home";
        }
    }

}
