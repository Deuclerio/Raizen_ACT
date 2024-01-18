using Microsoft.EntityFrameworkCore;
using UPD8.Data.Data.Context;
using UPD8.Data.Data.Repositories;
using UPD8.Data.Domain.Interfaces.Repository;
using UPD8.Data.Domain.Interfaces.Services;
using UPD8.Data.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UPD8Context>
    (options => options.UseSqlServer
    ("Data Source=DEUCLERIO\\SQLEXPRESS;Initial Catalog=testeACT;Integrated Security=True;MultipleActiveResultSets=True"));

builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
