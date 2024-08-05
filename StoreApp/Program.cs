using StoreApp.Infrastructure.Extensions;

namespace StoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Web uygulamasý oluþturucu (builder) tanýmlanýyor
            var builder = WebApplication.CreateBuilder(args);

            // WebApi için ekledik.
            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            // MVC Route için servis ekledik.
            builder.Services.AddControllersWithViews();

            //Razorpage kullanabilmek için ekliyýruz.
            builder.Services.AddRazorPages();

            //ServiceExtension class oluþturup oradan getiriyoruz.
            builder.Services.ConfigureDbContext(builder.Configuration);
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureSession();
            builder.Services.ConfigureRepositoryRegistration();
            builder.Services.ConfigureServiceRegistration();
            builder.Services.ConfigureRouting();
            builder.Services.ConfigureApplicationCookie();


            builder.Services.AddAutoMapper(typeof(Program));

            // Uygulama oluþturuluyor
            var app = builder.Build();

            //wwwroot klasörünü kullanmamýzý saðlar. 
            app.UseStaticFiles();

            app.UseSession();

            // HTTP isteklerini HTTPS'e yönlendirme
            app.UseHttpsRedirection();

            //HTTP isteklerini yönlendirmek için gerekli olan Routing middleware
            app.UseRouting();


            //Routing ve endpoint arasýnda olmak zorundadýr.
            app.UseAuthentication();
            app.UseAuthorization();

            /*
            // MVC Controller Default Rotasý
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                endpoints.MapControllers(); //Webapi controlleri kullanmak için eklendi

            });*/

            // MVC Controller Default Rotasý
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.MapControllers(); // Web API controlleri kullanmak için eklendi


            app.ConfigureAndCheckMigration();
            app.ConfigureLocalization();
            app.ConfigureDefaultAdminUser();

            app.Run();

            /***    Service Extension'a taþýdýk.  ******
             * 
             * //IServiceCollection'a RepositoryContext için bir servis ekler. ctor'da RepositoryContext çaðrýldýðýnda buradan DI çözümler.
            builder.Services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("StoreApp")); //Migration hangi projede oluþmasý gerektiðini belirttik.               

            });
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            { 
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });                 
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();   

             // builder.Services.AddSingleton<Cart>(); //Bu þekilde herkes ayný sepeti görüyor.
            builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c)); // Kullanýcýlarýn sepetleri farklý oldu artýk :)


            //IoC Servis Kayýtlarý.
            //addscoped ile her kullanýcýnýn iþlemi birbiriyle karýþmaz.  (Dipnot singleton yapmýyoruz )
            // IRepositoryManager  istenirse RepositoryManager newleyecek.
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();             
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<IOrderService, OrderManager>();
            */
        }
    }
}