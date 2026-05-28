using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Implementations;
using DailyBytesDAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

using DailyBytesServices.Middleware;
using DailyBytesServices.Helpers;

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);



// =========================
// Controllers
// =========================

builder.Services
.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles;
})
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory =
        context =>
        {
            var errors =
                context.ModelState
                .Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return new BadRequestObjectResult(

                new ApiResponse<object>
                {
                    Success = false,
                    Message = "Validation failed",
                    Data = errors
                }

            );
        };
});



// =========================
// Swagger
// =========================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



// =========================
// Database
// =========================

builder.Services.AddDbContext<DailyBytesDbContext>(options =>

    options.UseSqlServer(

        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )

    )

);



// =========================
// Repositories
// =========================

builder.Services.AddScoped<
    IArticleRepository,
    ArticleRepository>();

builder.Services.AddScoped<
    ICategoryRepository,
    CategoryRepository>();

builder.Services.AddScoped<
    IUserRepository,
    UserRepository>();

builder.Services.AddScoped<
    IBookmarkRepository,
    BookmarkRepository>();

builder.Services.AddScoped<
    IRatingRepository,
    RatingRepository>();

builder.Services.AddScoped<
    ICommentRepository,
    CommentRepository>();



// =========================
// CORS
// =========================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAngular",

        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:4200"
                )

                .AllowAnyMethod()

                .AllowAnyHeader();
        }
    );
});



var app = builder.Build();



// =========================
// Swagger
// =========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}



// =========================
// Middleware Pipeline
// =========================

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();