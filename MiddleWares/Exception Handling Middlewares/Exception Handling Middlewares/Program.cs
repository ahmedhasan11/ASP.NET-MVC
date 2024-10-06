using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace Exception_Handling_Middlewares
{
    public class Program
    {
        //exception handling
        //here we use 2 methods 
        //1-UseDeveloperExceptionPage() , we use it in the development phase because of sensitive info
        //2-UseExceptionHandler() , we use it in the production phase 
        public void Configure4(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage(); //adds middleware into the request pipeline which displays developer friendly exception detail page.
                                                 //This helps developers in tracing errors that occur during development phase
                                                 //,it is advisable to add it only in development environment.
            }

            app.Run(context => { throw new Exception("error"); });
        }
        //as we said above ,         //2-UseExceptionHandler() , we use it in the production phase
        //The UseExceptionHandler extension method allows us to configure custom error handling route
        public void Configure5(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); //configure custom error handling route
                //If an error occurred in the MVC application then it will redirect the request to /home/error,
                //which will execute the Error action method of HomeController
            }

            //code removed for clarity 
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