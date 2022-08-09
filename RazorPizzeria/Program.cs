using RazorPizzeria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.
    AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Checkout/AccessDenied";
        options.Cookie.HttpOnly = true;
    });

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {

//        options.LoginPath = "/Login";
//        options.AccessDeniedPath = "/Checkout/AccessDenied";
//    });

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("MyCookieAuth", options =>
//{
//    options.Cookie.Name = "MyCookieAuth";
//    options.LoginPath = "/Login";
//    options.AccessDeniedPath = "/Checkout/AccessDenied";
//});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBelongToHRDepartment",
        policy => policy.RequireClaim("Department", "HR"));
});

builder.Services.AddRazorPages( options =>
{
    options.Conventions.AuthorizePage("/Orders", "MustBelongToHRDepartment");
    options.Conventions.AllowAnonymousToPage("/Index");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
