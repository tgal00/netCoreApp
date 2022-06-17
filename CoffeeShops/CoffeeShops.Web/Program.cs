using CoffeeShops.DAL;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CoffeeShopManagerDbContext");
builder.Services.AddDbContext<CoffeeShopManagerDbContext>(options =>
    options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly("CoffeeShops.DAL")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

/*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CoffeeShopManagerDbContext>();
builder.Services.AddControllersWithViews();*/

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CoffeeShopManagerDbContext>();
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = "";
    facebookOptions.AppSecret = "";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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


var supportedCultures = new[]
{
    new CultureInfo("hr"), new CultureInfo("en-US")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("hr"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CoffeeShop}/{action=Index}");


app.MapControllerRoute(
    name: "whereToGo",
    pattern: "whereToGo",
    defaults: new { controller = "CoffeeShop", action = "Index" });


app.MapRazorPages();

app.Run();
