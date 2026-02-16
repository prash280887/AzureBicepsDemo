using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using WebAppServiceDemo;

var builder = WebApplication.CreateBuilder(args);

//Add DB context for SQL Server
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//ADD JWT AUthhetication BEarer
builder.Services.AddAuthentication("DefaultScheme").
    AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001"; // IdentityServer URL
       // options.Audience = "*"; // API resource name
        options.RequireHttpsMetadata = false; // For development only, set to true in production
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false // Disable audience validation
          
        };      
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1"); // Ensure the token has the required scope
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
