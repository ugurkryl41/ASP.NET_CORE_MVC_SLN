using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("Name") ?? " ";

        public void OnGet()
        {

        }

        public void OnPost([FromForm] string name)
        {
            //  FullName = name;  // class �zerinde tutuyoruz bu sebeple sayfa yenilendi�inde gider.
            if (name is null)
                name = " ";
            HttpContext.Session.SetString("Name", name);
        }
    }
}
