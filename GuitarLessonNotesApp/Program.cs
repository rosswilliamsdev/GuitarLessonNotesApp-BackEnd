using GuitarLessonNotesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using GuitarLessonNotesApp.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddLogging();

// Configure database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add JWT Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],  // Get from configuration
            ValidAudience = builder.Configuration["Jwt:Audience"],  // Get from configuration
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))  // Get from configuration
        };
    });

// Register JwtTokenHelper as a Singleton
builder.Services.AddSingleton<JwtTokenHelper>(provider => new JwtTokenHelper(
    builder.Configuration["Jwt:SecretKey"],  // Get from configuration
    builder.Configuration["Jwt:Issuer"],  // Get from configuration
    builder.Configuration["Jwt:Audience"]  // Get from configuration
));

// CORS Policy to allow frontend access (adjust the URL as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:5173")  // Adjust to match your frontend URL
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure CORS to allow requests from your frontend
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable authentication and authorization middleware
app.UseAuthentication();  // This must be before `UseAuthorization`
app.UseAuthorization();

// Map your controllers
app.MapControllers();

app.Run();
