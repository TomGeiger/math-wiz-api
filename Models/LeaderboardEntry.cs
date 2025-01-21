using System;

namespace MathWizApi.Models
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string QuizType { get; set; } = string.Empty; // Addition, Subtraction, Multiplication, Division
        public decimal TotalTime { get; set; } = 0;
    }
}
