using ManageProperty.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using ManageProperty.Repositories;
using ManageProperty.Services;

namespace ManageProperty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<EstateDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddControllersWithViews();

            // Add session services
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);// Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            //Add Cors 
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReact", builder =>
                {
                    builder.WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            // SERVICES REGISTRATIONS 
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
            builder.Services.AddScoped<IManagerService, ManagerService>();


            var app = builder.Build();

            app.UseCors("AllowReact");

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
            app.UseSession();

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Serve the react build files 
            var appPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(appPath),
                RequestPath = "/app"
            });

            //React client side routing fallback
            app.MapFallback(context =>
            {
                if (context.Request.Path.StartsWithSegments("/app"))
                {
                    context.Response.ContentType = "text/html";
                    return context.Response.SendFileAsync(Path.Combine(appPath, "index.html"));
                }
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}
