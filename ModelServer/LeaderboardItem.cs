using System;
using System.Collections.Generic;

namespace PROG7312_POE_ST10117020.ModelServer
{
    public partial class LeaderboardItem
    {
        public LeaderboardItem(string leaderboardId, string leaderboardGameType, int leaderboardScore, string userId)
        {
            LeaderboardId = leaderboardId;
            LeaderboardGameType = leaderboardGameType;
            LeaderboardScore = leaderboardScore;
            UserId = userId;
        }

        public LeaderboardItem()
        {

        }

        public string LeaderboardId { get; set; } = null!;
        public string LeaderboardGameType { get; set; } = null!;
        public int LeaderboardScore { get; set; }
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
