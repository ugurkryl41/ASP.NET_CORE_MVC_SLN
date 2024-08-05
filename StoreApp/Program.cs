using StoreApp.Infrastructure.Extensions;

namespace StoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Web uygulamas� olu�turucu (builder) tan�mlan�yor
            var builder = WebApplication.CreateBuilder(args);

            // WebApi i�in ekledik.
            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            // MVC Route i�in servis ekledik.
            builder.Services.AddControllersWithViews();

            //Razorpage kullanabilmek i�in ekliy�ruz.
            builder.Services.AddRazorPages();

            //ServiceExtension class olu�turup oradan getiriyoruz.
            builder.Services.ConfigureDbContext(builder.Configuration);
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureSession();
            builder.Services.ConfigureRepositoryRegistration();
            builder.Services.ConfigureServiceRegistration();
            builder.Services.ConfigureRouting();
            builder.Services.ConfigureApplicationCookie();


            builder.Services.AddAutoMapper(typeof(Program));

            // Uygulama olu�turuluyor
            var app = builder.Build();

            //wwwroot klas�r�n� kullanmam�z� sa�lar. 
            app.UseStaticFiles();

            app.UseSession();

            // HTTP isteklerini HTTPS'e y�nlendirme
            app.UseHttpsRedirection();

            //HTTP isteklerini y�nlendirmek i�in gerekli olan Routing middleware
            app.UseRouting();


            //Routing ve endpoint aras�nda olmak zorundad�r.
            app.UseAuthentication();
            app.UseAuthorization();

            /*
            // MVC Controller Default Rotas�
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

                endpoints.MapControllers(); //Webapi controlleri kullanmak i�in eklendi

            });*/

            // MVC Controller Default Rotas�
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.MapControllers(); // Web API controlleri kullanmak i�in eklendi


            app.ConfigureAndCheckMigration();
            app.ConfigureLocalization();
            app.ConfigureDefaultAdminUser();

            app.Run();

            /***    Service Extension'a ta��d�k.  ******
             * 
             * //IServiceCollection'a RepositoryContext i�in bir servis ekler. ctor'da RepositoryContext �a�r�ld���nda buradan DI ��z�mler.
            builder.Services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("StoreApp")); //Migration hangi projede olu�mas� gerekti�ini belirttik.               

            });
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            { 
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });                 
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();   

             // builder.Services.AddSingleton<Cart>(); //Bu �ekilde herkes ayn� sepeti g�r�yor.
            builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c)); // Kullan�c�lar�n sepetleri farkl� oldu art�k :)


            //IoC Servis Kay�tlar�.
            //addscoped ile her kullan�c�n�n i�lemi birbiriyle kar��maz.  (Dipnot singleton yapm�yoruz )
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