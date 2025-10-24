using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PumpQuestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PdfController : ControllerBase
    {
        private readonly Data.ApplicationDbContext _context;

        public PdfController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetRewardPdf/{userId}/{level}")]
        public async Task<IActionResult> GetRewardPdf(string userId, int level)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Uid == userId);
            if(user == null) return NotFound();

            var generator = new RewardPdfGenerator();
            var pdfBytes = generator.GenerateRewardPdf(user.Username, level);

            return File(pdfBytes, "application/pdf", $"{userId}_Reward_{level}.pdf");
        }

    }
}