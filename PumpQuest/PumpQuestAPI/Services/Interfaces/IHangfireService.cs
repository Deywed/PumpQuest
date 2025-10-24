using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpQuestAPI.Services.Interfaces
{
    public interface IHangfireService
    {
        Task ScheduleWorkoutStart(int sessionId, DateTime startTime);
    }
}