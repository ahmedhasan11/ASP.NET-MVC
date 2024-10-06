using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Diagnostics;

namespace Configure_1___Multiple_Middlewares
{
    public class Program
    {

        //diagonistics package middlewares
        public void Configure1(IApplicationBuilder app)
    {
        app.UseWelcomePage();
      //  app.RunTimeInfoPage();
        app.UseDeveloperExceptionPage(); //middleware for exception
    }
  //  -------------------------------------------------------------------------------------------
   // -------------------------------------------------------------------------------------------
   // -------------------------------------------------------------------------------------------
        //instead of using lambda expressions in  the next configure methods ,the Run method
        //accepts a method as a parameter , that method should accept the HttpContext parameter
        //and retruns Task , SO YOU CAN DO IT LIKE THAT
        public void Configure2(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.Run(MyMiddleware);
    }
    private Task MyMiddleware(HttpContext context)
    {
        return context.Response.WriteAsync("Hello World! ");
    }
    //the last method was not asynchrounous , so it will block the thread until it completes
    //it's excution , so to improve performance we should make it asynchronous by using
    //async , and await keywords
    public void Configure3(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.Run(myMiddleware);
    }

    private async Task myMiddleware(HttpContext context)
    {
        await context.Response.WriteAsync("Hello World! ");
    }
   // -------------------------------------------------------------------------------------------
   // -------------------------------------------------------------------------------------------
   // -------------------------------------------------------------------------------------------
        //confiure 1 middleware using lambda expressions
        public void Configure4(IApplicationBuilder app, IHostingEnvironment env) //configure middleware
    {
        //configure middleware using IApplicationBuilder here..

        app.Run(async (context) =>
        //As you can see above, the Run method accepts a method as a parameter whose signature should match with RequestDelegate. Therefore, the method should accept the HttpContext parameter and return Task. So, you can either specify a lambda expression or specify a function in the Run method
        {
            // await context.Response.WriteAsync("Hello World!");

        });

        //other code removed for clarity..
    }

    //configure of multiple middlewares ,to configure multiple middleware,
    //use Use() extension method. It is similar to Run() method except that it includes next parameter to invoke next middleware in the sequence.
    //Configure multiple middlewares using lambda expression
    public void Configure5(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello World From 1st Middleware!");

            await next();
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World From 2nd Middleware");
        });
    }


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