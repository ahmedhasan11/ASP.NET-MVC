using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Logging_in_asp.net_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();

            CreateWebHostBuilder(args).Build().Run(); //the call to the WebHost.CreateDefaultBuilder(args) method in the Program.cs
                                                      //internally adds the Console, Debug, and EventSource logging providers.
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();

        //to configure logging providers
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .ConfigureLogging(logBuilder =>
    {
        logBuilder.ClearProviders(); // removes all providers from LoggerFactory
        logBuilder.AddConsole();
        logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
    })
    .UseStartup<Startup>();


    }
}