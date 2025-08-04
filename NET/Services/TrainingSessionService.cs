using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Mappers;
using NET.Services.Interfaces;

namespace NET.Services
{
    public class TrainingSessionService : ITrainingSessionService
    {
        private readonly ApplicationDbContext _context;

        public TrainingSessionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TrainingSessionDTO> CreateTrainingSessionAsync(CreateTrainingSessionDTO createTrainingSessionDto)
        {
            var trainingSession = createTrainingSessionDto.ToEntity();
            await _context.TrainingSessions.AddAsync(trainingSession);
            await _context.SaveChangesAsync();
            
            return trainingSession.ToDto();
        }

        public async Task<bool> DeleteTrainingSessionAsync(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null) return false;

            _context.TrainingSessions.Remove(trainingSession);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TrainingSessionDTO>> GetAllTrainingSessionsAsync()
        {
            var trainingSessions = await _context.TrainingSessions
                .Select(ts => ts.ToDto())
                .ToListAsync();

            return trainingSessions;
        }


        public async Task<TrainingSessionDTO> GetTrainingSessionByIdAsync(int id)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null) return null!;
            return trainingSession.ToDto();
        }

        public async Task<TrainingSessionDTO> UpdateTrainingSessionAsync(int id, UpdateTrainingSessionDTO trainingSessionDto)
        {
            var trainingSession = await _context.TrainingSessions.FindAsync(id);
            if (trainingSession == null) return null!;

            trainingSession.UpdateEntity(trainingSessionDto);
            await _context.SaveChangesAsync();

            return trainingSession.ToDto();
        }

        }
    }