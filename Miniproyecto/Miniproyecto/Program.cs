using Microsoft.EntityFrameworkCore;
using MiniProyecto.BLL.Contracts;
using MiniProyecto.BLL.Services;
using MiniProyecto.DAL.Context;
using MiniProyecto.DAL.Interfaces;
using MiniProyecto.DAL.Repositories;
using Registro.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
//add services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISeries, SerieRepository >();
builder.Services.AddScoped<ICategoria, CategoriaRepository>();
builder.Services.AddScoped<IGenero, GeneroRepository>();
builder.Services.AddScoped<IProductor, ProductorRepository>();


builder.Services.AddTransient<ISeriesService, SerieService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddTransient<IGeneroService, GeneroService>(); 
builder.Services.AddTransient<IProductorService, ProductorService>();







// Add services to the container.
string conexion = builder.Configuration.GetConnectionString("MiniContext");
builder.Services.AddDbContext<MiniContext>(e => e.UseSqlServer(conexion));


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
