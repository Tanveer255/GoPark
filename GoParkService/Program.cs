using GoParkService.Entity.Common.Model;
using GoParkService.Entity.Data;
using GoParkService.Entity.Entity.Identity;
using GoParkService.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<SendGridSetting>(builder.Configuration.GetSection("SendGrid"));
builder.Services.Configure<ReCaptchaSetting>(builder.Configuration.GetSection("ReCaptcha"));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddDbContext<GoParkServiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<GoParkServiceDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers();
#region For Swagger
builder.Services
      .AddSwaggerGen(c =>
      {
          c.AddSecurityDefinition("Bearer", 
          new OpenApiSecurityScheme
          {
              Description = "JWT Authorization header using the Bearer scheme.",
              Type = SecuritySchemeType.Http,
              Scheme = "bearer" 
          });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                 {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", 
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
        });
          c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      });
# endregion
builder.Services.AddAllCustomServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:51076") // React frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();
// Use CORS
app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
