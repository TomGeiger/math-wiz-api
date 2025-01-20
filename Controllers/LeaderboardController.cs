using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MathWizApi.Data;
using MathWizApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly MathWizContext _context;

    public LeaderboardController(MathWizContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaderboardEntry>>> GetLeaderboardEntries()
    {
        return await _context.LeaderboardEntries.OrderByDescending(e => e.Score).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<LeaderboardEntry>> PostLeaderboardEntry(LeaderboardEntry entry)
    {
        _context.LeaderboardEntries.Add(entry);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLeaderboardEntries), new { id = entry.Id }, entry);
    }
}
