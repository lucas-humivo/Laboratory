using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Laboratory.Data;
using Laboratory.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<LaboratoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaboratoryContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var myMaxModelBindingCollectionSize = Convert.ToInt32(
           builder.Configuration["MyMaxModelBindingCollectionSize"] ?? "100");

builder.Services.Configure<MvcOptions>(options =>
       options.MaxModelBindingCollectionSize = myMaxModelBindingCollectionSize);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LaboratoryContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(services);
}

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
