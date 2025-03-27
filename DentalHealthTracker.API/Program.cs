using DentalHealthTracker.Infrastructure.Data;
using DentalHealthTracker.Infrastructure.Repositories;
using DentalHealthTracker.Infrastructure.Services;
using DentalHealthTracker.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JWT Ayarlarını Al
var jwtKey = builder.Configuration["JwtSettings:Key"];
var key = Encoding.UTF8.GetBytes(jwtKey!);

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// **JWT Token Generator'ü DI Container'a Ekle**
builder.Services.AddScoped<JwtTokenGenerator>();

// **Service Katmanını Enjekte Etme**
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IHealthSuggestionService, HealthSuggestionService>();
builder.Services.AddSingleton<MailService>();


// **Veritabanı Bağlantısı**
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// **Repository Katmanını Enjekte Etme**
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IHealthSuggestionRepository, HealthSuggestionRepository>();

// **API ve Swagger Ayarları**
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.SetIsOriginAllowed(origin => true) // Her kaynağa (origin) izin ver
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Çıkış yapmış token'ları kontrol eden middleware ekleniyor
app.UseMiddleware<JwtBlacklistMiddleware>();

// **Middleware'ler**
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
