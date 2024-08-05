using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        //Servis üzerinden gitmezse logic işlemez yani belki 100 tane ürün var ama 20si pasif    80 yerine 100 gösterir vs.
        //RepositoryContext yerine servismanager kullanmamız doğru olacaktır.

       
        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }
      
    }
}
