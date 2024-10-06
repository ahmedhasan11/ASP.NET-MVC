using Microsoft.Extensions.FileProviders;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace mvc
{
    public class Program
    {

        //serving static files using root
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); //adds static files(that is in wwroot folder) middleware into the request pipeline

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
        //serve static files from outside of web root folder , like images folder in soultion explorer
        public void Configure1(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions() //thie method server images from the folder
            {
                //File Provider :specify Images folder from which static files will be served 
                FileProvider = new PhysicalFileProvider( 
                                    Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
                RequestPath = new PathString("/images")
                //in routing search about images/imagename.extension
            });
        }


        //there is a method called UseDefaultFiles ,
        //this configures the DefaultFiles middleware which is a part of StaticFiles middleware.
        //This will automatically serve html file named default.html
        public void Configure2(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }

        // UseFileServer = UseDefaultFiles + UseStaticFiles , instead of using them both
        public void Configure3(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseFileServer();

           // UseFileServer = UseDefaultFiles + UseStaticFiles

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }

        -----------------------------------------

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
        }
    }
}