using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent: ViewComponent
    {
        private readonly IServiceManager serviceManager;

        public ShowcaseViewComponent(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke(string page = "default")
        {
            var products = serviceManager.ProductService.GetShowcaseProducts(false);
            return page.Equals("default")
                ? View(products) 
                : View("List",products);
        }
    }
}
