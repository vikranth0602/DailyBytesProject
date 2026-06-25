using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Implementations;
using DailyBytesDAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
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

// -_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-
builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
    options.ListenAnyIP(int.Parse(port));
});

// =========================
// CORS
// =========================


builder.Services.AddCors(options =>
{
    options.AddPolicy( "AllowAngular", policy =>
        {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
        }
    );
});



var app = builder.Build();

// =========================
// Seed Data
// =========================

using (var scope = app.Services.CreateScope())
{
    var context =
        scope.ServiceProvider
             .GetRequiredService<DailyBytesDbContext>();

    context.Database.Migrate();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(

            new Category
            {
                Name = "Technology"
            },

            new Category
            {
                Name = "Programming"
            },

            new Category
            {
                Name = "Artificial Intelligence"
            },

            new Category
            {
                Name = "Cloud Computing"
            }

        );

        context.SaveChanges();
    }

    if (!context.Articles.Any())
    {
        var technology =
            context.Categories
                   .First(c => c.Name == "Technology");

        var programming =
            context.Categories
                   .First(c => c.Name == "Programming");

        var ai =
            context.Categories
                   .First(c => c.Name == "Artificial Intelligence");

        context.Articles.AddRange(

            new Article
            {
                Title = "Introduction to ASP.NET Core",
                Content =
                    "ASP.NET Core is a modern framework used for building web applications and APIs.",

                CategoryId = programming.Id
            },

            new Article
            {
                Title = "What is Cloud Computing?",
                Content =
                    "Cloud computing provides on-demand access to computing resources over the internet.",

                CategoryId = technology.Id
            },

            new Article
            {
                Title = "Getting Started with Artificial Intelligence",
                Content =
                    "Artificial Intelligence enables machines to simulate human intelligence.",

                CategoryId = ai.Id
            }

        );

        context.SaveChanges();
    }
}


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

//app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAngular");

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();




app.Run();