using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStoreSite.Data;
using BookStoreSite.Models;
using System;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookStoreSiteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreSiteContext")
        ?? throw new InvalidOperationException("Connection string 'BookStoreSiteContext' not found.")));

builder.Services.AddDefaultIdentity<DefaultUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<BookStoreSiteContext>();
//builder.Services.AddDbContext<BookStoreSiteContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreSiteContext")));
//builder.Services.AddDefaultIdentity<DefaultUser>().AddEntityFrameworkStores<BookStoreSiteContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
});
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
app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
SeedData.Initialize(app);
UserRoleInitializer.InitializeAsync(app.Services);

app.Run();
