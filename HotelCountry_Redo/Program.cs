using HotelCountry_Redo;
using HotelCountry_Redo.Core.Configuration;
using HotelCountry_Redo.Core.IRepository;
using HotelCountry_Redo.Core.Repository;
using HotelCountry_Redo.Core;
using HotelCountry_Redo.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using HotelCountry_Redo.Core.Services;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File(
        path: "Logger\\logs-.txt",
        outputTemplate: "\"{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Levelu3}] {Message:lj}{NewLine}{Exception}\"",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Information
));

//Cors
builder.Services.ConfigureCors();

//API Versoning
builder.Services.ConfigureVersioning();

//Caching
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.ConfigureCustomCaching();

//SqlConnection
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
);

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitializer));

//NewtonSoft
builder.Services.AddControllers().AddNewtonsoftJson(op =>
    op.SerializerSettings.ReferenceLoopHandling = 
        Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//Configure RateLimiting
builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication();   
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseCors("Allowall");

app.UseResponseCaching();

app.UseHttpCacheHeaders();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
