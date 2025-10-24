using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.Services;
using PumpQuestAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGymService, GymService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IUserStatistics, UserStatisticsService>();
builder.Services.AddScoped<IWorkoutSessionService, WorkoutSessionService>();
builder.Services.AddScoped<HangfireService>();

builder.Services.AddHangfire(config =>
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UsePostgreSqlStorage(options => 
          {
              options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
          }));

builder.Services.AddHangfireServer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();

    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


var app = builder.Build();
app.UseHangfireDashboard("/hangfire");



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapHub<SessionsHub>("/sessionsHub");
app.UseCors("CORS");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();