using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Log
{


    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Program>();



        //if you want to configure logging providers you can do :
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logBuilder =>
            {
        logBuilder.ClearProviders(); // removes all providers from LoggerFactory
        logBuilder.AddConsole();
        logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
             })
        .UseStartup<Program>();



        //if you want to store logs in a text file :
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // other code remove for clarity 
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
        }

        //if you want to create logs in the controller :CHECK HomeController.cs




        public static void Main(string[] args)
        {
            //install the packages to remove the errors
            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole((_, __) => true);
            //this was an extension method to make a console logging provider

            ILogger logger = loggerFactory.CreateLogger<Program>();
            //this creates a logger specific to the program class

            logger.LogInformation("this is log info");

            //you can also do the follwing
            logger.LogCritical("Logging critical information.");
            logger.LogDebug("Logging debug information.");
            logger.LogError("Logging error information.");
            logger.LogTrace("Logging trace");
            logger.LogWarning("Logging warning.");


            CreateWebHostBuilder(args).Build().Run();
            //adds the Console, Debug, and EventSource logging providers






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

        }


    }
    
}