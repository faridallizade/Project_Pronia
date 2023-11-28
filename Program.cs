using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Pronia.DAL;

namespace Project_Pronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("server=DESKTOP-4R5RDF2;database=ProniaDB;trusted_connection=true;Integrated security=true;Encrypt=false"));
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name: "HomePage",
                pattern: "{controller=home}/{action=index}/{id?}");
            app.Run();
        }
    }
}