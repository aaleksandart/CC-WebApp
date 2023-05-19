using Auth0.AspNetCore.Authentication;
using CC.Data.Context;
using CC.Data.Repositories;
using CC.Data.Repositories.Interfaces;
using CC.Data.Services;
using CC.Data.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

// Add services to the container.
services.AddControllersWithViews();

    //DB Context
    services.AddDbContext<SqlContext>(context => context.UseSqlServer(config.GetConnectionString("SQL")));
    //Services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IToolService, ToolService>();
    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IAvailabilityService, AvailabilityService>();
    services.AddScoped<IRentDataService, RentDataService>();
    //Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IToolsRepository, ToolsRepository>();
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
    services.AddScoped<IRentDataRepository, RentDataRepository>();

// Add Auth0 Authentication
services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = config["Auth0:Domain"] ?? string.Empty;
    options.ClientId = config["Auth0:ClientId"] ?? string.Empty;
    options.Scope = "openid profile email";
});

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
