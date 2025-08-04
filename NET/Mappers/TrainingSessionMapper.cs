using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class TrainingSessionMapper
    {
        public static TrainingSessionDTO ToDto(this TrainingSession trainingSession)
        {

            return new TrainingSessionDTO
            {
                Id = trainingSession.Id,
                Date = trainingSession.Date,
                SessionStatus = trainingSession.SessionStatus.ToString(),
                RequestStatus = trainingSession.RequestStatus.ToString(),
                ClientAId = trainingSession.ClientAId,
                ClientBId = trainingSession.ClientBId,
                GymId = trainingSession.GymId,
            
                WorkoutId = trainingSession.WorkoutId
            };
        }
        public static TrainingSession ToEntity(this CreateTrainingSessionDTO createTrainingSessionDto)
        {
            return new TrainingSession
            {
                ClientAId = createTrainingSessionDto.ClientAId,
                ClientBId = createTrainingSessionDto.ClientBId,
                GymId = createTrainingSessionDto.GymId,
                Date = createTrainingSessionDto.Date,
                SessionStatus = Enum.Parse<SessionStatus>(createTrainingSessionDto.SessionStatus ?? "Upcoming"),
                RequestStatus = Enum.Parse<RequestStatus>(createTrainingSessionDto.RequestStatus ?? "Pending"),
                WorkoutId = createTrainingSessionDto.WorkoutId,
            };
        }

        public static void UpdateEntity(this TrainingSession trainingSession, UpdateTrainingSessionDTO updateTrainingSessionDto)
        {
            trainingSession.ClientBId = updateTrainingSessionDto.ClientBId ?? trainingSession.ClientBId;
            trainingSession.Date = updateTrainingSessionDto.Date ?? trainingSession.Date;
            trainingSession.SessionStatus = updateTrainingSessionDto.SessionStatus != null
                ? Enum.Parse<SessionStatus>(updateTrainingSessionDto.SessionStatus)
                : trainingSession.SessionStatus;
            trainingSession.RequestStatus = updateTrainingSessionDto.RequestStatus != null
                ? Enum.Parse<RequestStatus>(updateTrainingSessionDto.RequestStatus)
                : trainingSession.RequestStatus;
            trainingSession.WorkoutId = updateTrainingSessionDto.WorkoutId ?? trainingSession.WorkoutId;
        }
    }
}