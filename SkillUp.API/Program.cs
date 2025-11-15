using Microsoft.EntityFrameworkCore;
using SkillUp.API.Data;
using SkillUp.API.Repositories;
using SkillUp.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SkillUp API v1",
        Version = "v1",
        Description = "API para gerenciamento de competências profissionais do futuro",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "SkillUp Team",
            Email = "contato@skillup.com"
        }
    });

    c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SkillUp API v2",
        Version = "v2",
        Description = "API para gerenciamento de competências profissionais do futuro - Versão 2",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "SkillUp Team",
            Email = "contato@skillup.com"
        }
    });
});

// Database Context - Usando SQLite para facilitar (pode trocar para SQL Server depois)
builder.Services.AddDbContext<SkillUpDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=SkillUpDB.db"));

// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserSkillRepository, UserSkillRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger sempre habilitado para facilitar testes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillUp API v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "SkillUp API v2");
    c.RoutePrefix = "swagger"; // Define a rota do Swagger
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

