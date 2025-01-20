using Microsoft.EntityFrameworkCore;
using MathWizApi.Models;

namespace MathWizApi.Data
{
    public class MathWizContext : DbContext
    {
        public MathWizContext(DbContextOptions<MathWizContext> options)
            : base(options)
        {
        }

        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }
    }
}