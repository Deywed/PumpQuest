using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PumpQuestAPI.Data;
using PumpQuestAPI.Models;
using PumpQuestAPI.Services;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutSessionRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly HangfireService _scheduler;
        private readonly IHubContext<SessionsHub> _hubContext;

        public WorkoutSessionRequestController(ApplicationDbContext context, HangfireService scheduler, IHubContext<SessionsHub> hubContext)
        {
            _context = context;
            _scheduler = scheduler;
            _hubContext = hubContext;
        }

        [HttpPost("SendRequest")]
        public async Task<IActionResult> SendRequest([FromBody] WorkoutSessionRequest request)
        {
            await _context.WorkoutSessionRequests.AddAsync(request);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.Group($"user-{request.ReceiverUid}")
                                     .SendAsync("ReceiveRequestSent", request.SessionId, request.SenderUid);

            var session = await _context.WorkoutSessions.FindAsync(request.SessionId);
            if (session != null)
            {
                _scheduler.ScheduleWorkout(session.Date, session.Id, request.SenderUid, request.ReceiverUid);
            }

            return Ok(request);
        }


        [HttpGet("GetRequestsForUser/{receiverUid}")]
        public async Task<IActionResult> GetRequestsForUser(string receiverUid)
        {
            var requests = await _context.WorkoutSessionRequests
                .Where(r => r.ReceiverUid == receiverUid && r.Status == "Pending")
                .Include(r => r.Sender)
                .Include(r => r.Session)
                .Select(r => new
                {
                    r.Id,
                    r.SenderUid,
                    SenderUsername = r.Sender!.Username,
                    r.ReceiverUid,
                    r.SessionId,
                    SessionName = r.Session!.Workout!.Name,
                    r.Status,
                    r.SentAt
                })
                .ToListAsync();

            return Ok(requests);
        }


        [HttpPut("AcceptRequest/{id}")]
        public async Task<IActionResult> UpdateRequestStatus(int id)
        {
            var request = await _context.WorkoutSessionRequests.FindAsync(id);
            if (request == null) return NotFound();
            var session = await _context.WorkoutSessions.FindAsync(request.SessionId);
            request.Status = "Accepted";
            if (session != null)
            {
                session.BuddyUid = request.SenderUid;
                await _hubContext.Clients.Group($"user-{request.SenderUid}") .SendAsync("", session.Id);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

            return Ok(request);
        }
        [HttpDelete("DeleteRequest/{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.WorkoutSessionRequests.FindAsync(id);
            if (request == null) return NotFound();

            _context.WorkoutSessionRequests.Remove(request);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("TestNavigate/{userUid}")]
        public async Task<IActionResult> TestNavigate(string userUid)
        {
            // Id sesije koju šaljemo za test
            int testSessionId = 999;

            // Šalje SignalR event korisniku
            await _hubContext.Clients.Group($"user-{userUid}")
                                    .SendAsync("NavigateToWorkout", testSessionId);

            return Ok(new { message = $"NavigateToWorkout sent to user {userUid}" });
        }

    }   
     
}