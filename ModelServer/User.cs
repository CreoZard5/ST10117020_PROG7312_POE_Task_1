using System;
using System.Collections.Generic;

namespace PROG7312_POE_ST10117020.ModelServer
{
    public partial class User
    {
        public User()
        {
            LeaderboardItems = new HashSet<LeaderboardItem>();
        }

        public User(string userId, string userUsername, string userEmail, string userPassword)
        {
            UserId = userId;
            UserUsername = userUsername;
            UserEmail = userEmail;
            UserPassword = userPassword;
        }

        public string UserId { get; set; } = null!;
        public string UserUsername { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<LeaderboardItem> LeaderboardItems { get; set; }
    }
}
