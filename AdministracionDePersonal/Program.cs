
using AdministracionDePersonal.Repository;
using AdministracionDePersonal.Services;
using AdministracionDePersonal.Services.Abstract;
using AdministracionDePersonal;
using AdministracionDePersonal.Servicess.Abstract;
using AdministracionDePersonal.Servicess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<AccionRepository>();
builder.Services.AddScoped<IAccionService, AccionService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<EmpleadoRepository>();

builder.Services.AddScoped<IRequisitoService, RequisitoService>();
builder.Services.AddScoped<RequisitoRepository>();
builder.Services.AddScoped<OferenteRepository>();
builder.Services.AddScoped<PuestoRepository>();
builder.Services.AddScoped<IOferenteService, OferenteService>();
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<IPuestoService, PuestoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.UseDeveloperExceptionPage();

app.Run();

