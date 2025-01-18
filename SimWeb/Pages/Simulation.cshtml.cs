using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        public void OnGet()
        {
            ViewData["ActivePage"] = "Simulation";
        }
    }

}
