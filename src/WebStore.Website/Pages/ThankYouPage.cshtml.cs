using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebStore.Website.Pages
{
    public class ThankYouPageModel : PageModel
    {
        public void OnGet()
        {
            ViewData["ThankYouMessage"] = "Thank you for your order. You'll soon enjoy our delicios pies!";
        }
    }
}
