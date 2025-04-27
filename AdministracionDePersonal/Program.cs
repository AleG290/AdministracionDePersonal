using AdministracionDePersonal.Servicess.Abstract;
using AdministracionDePersonal.Servicess;
using AdministracionDePersonal.Repository;
using AdministracionDePersonal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<OferenteRepository>();
builder.Services.AddScoped<IOferenteService, OferenteService>();
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
