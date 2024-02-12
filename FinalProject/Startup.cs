using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Data;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Add DbContext 
        services.AddDbContext<UserDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


        // Add MVC services
        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "registration",
                pattern: "Registration", // Adjust the URL pattern as needed
                defaults: new { controller = "Registration", action = "Index" }); // Assuming Index is the action method for the registration page
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Registration}/{action=Index}/{id?}");
        });
    }
}
