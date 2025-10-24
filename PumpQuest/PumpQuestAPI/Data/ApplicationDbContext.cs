using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Models;

namespace PumpQuestAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<UserStatistics> UserStatistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<WorkoutSessionRequest> WorkoutSessionRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<User>()
        .HasKey(u => u.Uid);

    modelBuilder.Entity<UserStatistics>()
        .HasKey(us => us.Id);

    modelBuilder.Entity<User>()
        .HasOne(u => u.Statistics)
        .WithOne(s => s.User)
        .HasForeignKey<UserStatistics>(s => s.UserUid)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<Workout>()
    .HasOne(w => w.Trainer)
    .WithMany(u => u.CreatedWorkouts)
    .HasForeignKey(w => w.CoachUid)
    .HasPrincipalKey(u => u.Uid)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<WorkoutExercise>(entity =>
    {
        entity.HasKey(we => we.Id);
        entity.Property(we => we.Id).ValueGeneratedOnAdd();

        entity.HasOne(we => we.Workout)
              .WithMany(w => w.WorkoutExercises)
              .HasForeignKey(we => we.WorkoutId);

        entity.HasOne(we => we.Exercise)
              .WithMany(e => e.WorkoutExercises)
              .HasForeignKey(we => we.ExerciseId);
    });
}

    }
}