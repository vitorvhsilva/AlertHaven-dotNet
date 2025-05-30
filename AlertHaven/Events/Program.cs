using Events.Application.Interfaces;
using Events.Application.Services;
using Events.Domain.Interface;
using Events.Infraestructure.Data.AppData;
using Events.Infraestructure.Data.Repositories;
using Events.Presentation.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(x => {
    x.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

builder.Services.AddAutoMapper(typeof(ControllerMapper));

builder.Services.AddTransient<IIotService, IotService>();
builder.Services.AddTransient<IIotRepository, IotRepository>();

builder.Services.AddTransient<IEventoService, EventoService>();
builder.Services.AddTransient<IEventoRepository, EventoRepository>();

builder.Services.AddTransient<IAlertaService, AlertaService>();
builder.Services.AddTransient<IAlertaRepository, AlertaRepository>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(conf => {
    conf.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();
app.Run();
