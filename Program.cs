using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TaskTrackerBackend.Services;
using TaskTrackerBackend.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<AppService>();
builder.Services.AddScoped<BoardService>();

var ConnectionStrings = builder.Configuration.GetConnectionString("TaskTracker");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(ConnectionStrings));

builder.Services.AddCors(options => options.AddPolicy("TaskTrackerPolicy",
 builder =>
 {
     builder.WithOrigins("http://localhost:5217", "http://localhost:3000", "http://localhost:3001")
     .AllowAnyHeader()
     .AllowAnyMethod();
 }
));



builder.Services.AddControllers();



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

app.UseCors("TaskTrackerPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
