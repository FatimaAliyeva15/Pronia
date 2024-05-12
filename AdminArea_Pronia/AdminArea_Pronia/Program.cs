using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaBusiness.Services.Concretes;
using AdminArea_ProniaCore.RepositoryAbstracts;
using AdminArea_ProniaData.DAL;
using AdminArea_ProniaData.RepositoryConcretes;
using Microsoft.EntityFrameworkCore;

namespace AdminArea_Pronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddScoped<ISliderService, SliderServer>();
            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryReposiroty, CategoryRepository>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            

            app.Run();
        }
    }
}
