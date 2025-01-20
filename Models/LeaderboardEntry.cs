using System;

namespace MathWizApi.Models
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
