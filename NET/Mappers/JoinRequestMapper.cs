using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class JoinRequestMapper
    {
        public static JoinRequestDTO ToDto(this JoinRequest joinRequest)
        {
            return new JoinRequestDTO
            {
                Id = joinRequest.Id,
                UserAId = joinRequest.UserAId,
                UserBId = joinRequest.UserBId,
                CreatedAt = joinRequest.CreatedAt,
                Status = joinRequest.Status.ToString(),
            };
        }

        public static JoinRequest ToEntity(this CreateJoinRequestDTO createJoinRequestDto)
        {
            return new JoinRequest
            {

                UserAId = createJoinRequestDto.UserAId,
                UserBId = createJoinRequestDto.UserBId,
                TrainingSessionId = createJoinRequestDto.TrainingSessionId,
                CreatedAt = DateTime.UtcNow,
                Status = Enum.Parse<JoinRequestStatus>(createJoinRequestDto.Status.ToString() ?? "Pending"),
            };
        }
        public static void UpdateEntity(this JoinRequest entity, UpdateJoinRequestDTO dto)
        {
            entity.Status = dto.Status ?? entity.Status;
        }
    }
}