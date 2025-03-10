using BCITGO_FINAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BCITGO_FINAL
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Get the connection string from appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container. - added
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add Identity services - added
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Add services to the container. - added - removed
            //builder.Services.AddControllersWithViews(); - removed
            //builder.Services.AddRazorPages(); // ✅ Add this line above `builder.Build(); - removed

            // Add Razor Pages for Identity - added
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Apply migrations and ensure the database is created - added
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                // Apply migrations instead of EnsureCreated - added
                context.Database.Migrate();  // Apply pending migrations to the database

                // Initialize database with seed data - added
                DbInitializer.Initialize(context);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else // - added
            {
                app.UseDeveloperExceptionPage(); // ✅ Show detailed errors in development mode
                app.UseMigrationsEndPoint(); // ✅ Allow database migrations in development
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Required for Identity - added
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages(); // Enable Razor Pages for Identity - added

            app.Run();
        }
    }
}
