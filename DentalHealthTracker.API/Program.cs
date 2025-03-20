using DentalHealthTracker.Infrastructure.Data;
using DentalHealthTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using DentalHealthTracker.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

//Service Bağlantısı
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserService, UserService>();

// Veritabanı Bağlantısı
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository Katmanını Enjekte Etme
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// API Katmanı
builder.Services.AddControllers();

var app = builder.Build();

// Middleware'ler
app.UseAuthorization();
app.MapControllers();
app.Run();
