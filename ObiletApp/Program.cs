using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ObiletApp.Businesses.Contracts;
using ObiletApp.Businesses.Services;
using ObiletApp.Models.DTOs;
using ObiletApp.Models.Validators;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ISessionService, SessionService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<IJourneyService, JourneyService>();
builder.Services.AddScoped<IValidator<BusLocationDto>, BusLocationDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
