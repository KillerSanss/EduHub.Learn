using System.Text.Json.Serialization;
using EduHub.StudentService.Api.Middleware;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using EduHub.StudentService.Application.Services.Mapping;
using EduHub.StudentService.Application.Services.Services;
using Eduhub.StudentService.Infrastructure.Data;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories;
using EduHub.StudentService.Infrastructure.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        var enumConverter = new JsonStringEnumConverter(allowIntegerValues: false);
        options.JsonSerializerOptions.Converters.Add(enumConverter);
    });

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IEducatorRepository, EducatorRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEducatorService, EducatorService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<StudentDbContext>>();
builder.Services.AddAutoMapper(typeof(StudentMappingProfile).Assembly);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentDbContext>(o => o.UseNpgsql(EduhubNpgsqlDataSource.Create(connectionString)));

var app = builder.Build();

app.UseMiddleware<MiddlewareExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();