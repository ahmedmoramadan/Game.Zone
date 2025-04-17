// video 11 or  12 mmmm
using APPPlay.Services;
using Microsoft.AspNetCore.Identity;

namespace APPPlay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var con = builder.Configuration.GetConnectionString("Default") ?? 
                throw new InvalidOperationException("not database found");
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(con));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IDevicesService , DevicesServices >();
            builder.Services.AddScoped<IGamesService, GamesService>();
            builder.Services.AddIdentity<Appuser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}