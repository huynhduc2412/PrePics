using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrePics.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrePicsDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("PrePicsDBContextConnection")), ServiceLifetime.Singleton);


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<User, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<PrePicsDbContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

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
app.MapRazorPages();

app.Run();
