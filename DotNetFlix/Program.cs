global using DotNetFlix.DbEntities;
global using DotNetFlix.DbHelpers;
global using Microsoft.EntityFrameworkCore;
using DotNetFlix.aMyBLL.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container
services.AddDbContext<DflixContext>(x => x.UseSqlServer(connectionString));
services.AddControllersWithViews();
services.AddControllers();

// services van Mathias
services.AddScoped<DflixRepo<UserDAL>>();
services.AddScoped<UserService>();

services.AddScoped<DflixRepo<ShoppingCartItemDAL>>();
services.AddScoped<ShoppingCartService>();

services.AddScoped<DflixRepo<MovieDAL>>();
services.AddHttpClient<MovieService>(c => { c.BaseAddress = new Uri("https://imdb-api.com/en/API/"); });


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();