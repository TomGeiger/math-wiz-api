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

    [HttpDelete("admin/{id}")]
    public async Task<IActionResult> DeleteLeaderboardEntry(int id)
    {
        var entry = await _context.LeaderboardEntries.FindAsync(id);
        if (entry == null)
        {
            return NotFound();
        }

        _context.LeaderboardEntries.Remove(entry);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("admin/{id}")]
    public async Task<IActionResult> PutLeaderboardEntry(int id, LeaderboardEntry entry)
    {
        if (id != entry.Id)
        {
            return BadRequest();
        }

        _context.Entry(entry).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaderboardEntryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool LeaderboardEntryExists(int id)
    {
        return _context.LeaderboardEntries.Any(e => e.Id == id);
    }
}
