using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

using Microsoft.AspNetCore.Diagnostics;

namespace _7
{
    public class Program
    {
        //diagonistics package middlewares
        public void configure(IApplicationBuilder app)
        {
           app.UseWelcomePage();
          // app.RunTimeInfoPage();
           app.UseDeveloperExceptionPage(); //middleware for exception
        }

        //invoking our csutom middleware that we did 
        //check MyMiddleware.cs class in the solution explorer
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMyMiddleware();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

    
    //-------------------------------------------------------------------------------------------
   // -------------------------------------------------------------------------------------------
    //-------------------------------------------------------------------------------------------
        //accessing environment variables
        public void Configure3(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                // code to be executed in development environment 

            }

            if (env.IsDevelopment())
            {
                // code to be executed in development environment 

            }

            if (env.IsStaging())
            {
                // code to be executed in staging environment 

            }

            if (env.IsProduction())
            {
                // code to be executed in production environment 

            }
        }
        public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);
                var app = builder.Build();

                app.MapGet("/", () => "Hello World!");


                app.Run();
            }


    }
}   