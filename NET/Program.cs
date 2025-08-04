   using Microsoft.EntityFrameworkCore;
   using NET;
using NET.Services;
using NET.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

   builder.Services.AddScoped<IExerciseService, ExerciseService>();
   builder.Services.AddScoped<IGymService, GymService>();
   builder.Services.AddScoped<ICityService, CityService>();
   builder.Services.AddScoped<IUserService, UserService>();
   builder.Services.AddScoped<IWorkoutService, WorkoutService>();
   builder.Services.AddScoped<IPrService, PRService>();
   builder.Services.AddScoped<ITrainingSessionService, TrainingSessionService>();
   builder.Services.AddScoped<IStatisticsService, StatisticsService>();
   builder.Services.AddScoped<IJoinRequestService, JoinRequestService>();
   


   
   builder.Services.AddScoped<ApplicationDbContext>();
   
   builder.Services.AddDbContext<ApplicationDbContext>(options =>
   {
   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
   });
   builder.Services.AddCors(options =>
   {
      options.AddPolicy("CORS", policy =>
      {
         policy.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://localhost:5500",
                           "https://localhost:5500",
                           "http://127.0.0.1:5500",
                           "https://127.0.0.1:5500");
      });
   });
   builder.Services.AddControllers();
   builder.Services.AddEndpointsApiExplorer();
   builder.Services.AddSwaggerGen();
   var app = builder.Build();
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
   app.UseCors("CORS");
   app.UseHttpsRedirection();
   app.UseAuthorization();
   app.MapControllers();
   app.Run();