using Yapti.Web.Services;
using Yapti.Web.Services.IServices;

namespace Yapti.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient<IOrderService, OrderService>();
            SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"];

            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";

            })
               .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
               .AddOpenIdConnect("oidc", option =>
               {
                   option.Authority = "https://localhost:7139"; //builder.Configuration["ServiceUrls:IdentityAPI"];
                   option.GetClaimsFromUserInfoEndpoint = true;
                   option.ClientId = "mango";
                   option.ClientSecret = "secret";
                   option.ResponseType = "code";
                   option.TokenValidationParameters.NameClaimType = "name";
                   option.TokenValidationParameters.RoleClaimType = "role";
                   option.Scope.Add("mango");
                   option.SaveTokens = true;
               });


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for orderion scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
