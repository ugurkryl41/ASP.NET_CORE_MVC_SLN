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
            //  FullName = name;  // class üzerinde tutuyoruz bu sebeple sayfa yenilendiðinde gider.
            if (name is null)
                name = " ";
            HttpContext.Session.SetString("Name", name);
        }
    }
}
