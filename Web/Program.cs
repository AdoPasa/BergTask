using Infrastructure;
using Application;
using Web.Middlewares;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/Errors/{0}");

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Synonym}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
