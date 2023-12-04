using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Data;
using WebApp1.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApp1ContextConnection") ?? throw new InvalidOperationException("Connection string 'WebApp1ContextConnection' not found.");

builder.Services.AddDbContext<WebApp1Context>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<WebApp1User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApp1Context>();

builder.Services.AddIdentity<WebApp1User, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<WebApp1Context>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
});



// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
