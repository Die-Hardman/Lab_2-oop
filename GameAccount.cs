namespace Lab_2
{
    public class GameAccount
    {
        protected int GamesCount;
        protected string AccountType;
        public string AccountID { get; }
        public string UserName { get; set; }
        public int CurrentRating
        {
            get
            {
                int currentrating = 0;
                foreach (var item in allGames)
                {
                    currentrating += item.Rating;
                }
                return currentrating;
            }
        }
        private static int accountNumberSeed = 1234567890;
        public GameAccount(string username, int rating)
        {
            AccountID = accountNumberSeed.ToString();
            accountNumberSeed++;
            UserName = username;
            SetInitialRating(username, rating);
            AccountType = "Free";
        }
        protected List<Game> allGames = new List<Game>();
        public virtual void WinGame(string playername, string opponentname, BaseGame game, string gamemode)
        {
            var gamewon = new Game(playername, opponentname, game.GetRating, "Win", gamemode);
            allGames.Add(gamewon);
        }
        public virtual void LoseGame(string playername, string opponentname, BaseGame game, string gamemode)
        {
            if (CurrentRating - game.GetRating < 1)
            {
                var negativerating = new Game(playername, opponentname, -CurrentRating + 1, "Lose", gamemode);
                allGames.Add(negativerating);
            }
            else
            {
                if (game.GetRating < 0)
                {
                    throw new InvalidOperationException("The rating cannot be negative");
                }
                var lostgame = new Game(playername, opponentname, -game.GetRating, "Lose", gamemode);
                allGames.Add(lostgame);
            }
        }
        public void SetInitialRating(string playername, int rating)
        {
            if (rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "The minimum rating cannot be less than 1");
            }
            var setrating = new Game(playername, "....", rating, "....", "....");
            allGames.Add(setrating);
        }
        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            int currentrating = 0;
            report.AppendLine("Rate\tCurrent rating\tPlayer\t\tOpponent\t\tNumber of games\tW / L\t\tGame type");
            foreach (var item in allGames)
            {
                currentrating += item.Rating;
                GamesCount++;
                if (GamesCount - 1 == 0)
                {
                    report.AppendLine($"....\t\t{currentrating}\t\t{item.Player}\t\t....\t\t{GamesCount - 1}\t\t\t{item.Outcome}\t\t....");
                }
                else
                {
                    report.AppendLine($"{Math.Abs(item.Rating)}\t\t{currentrating}\t\t{item.Player}\t\t{item.Opponent}\t\t{GamesCount - 1}\t\t\t{item.Outcome}\t\t{item.GameMode}");
                }
            }
            Console.WriteLine($"account id : {AccountID}\tAccount type : {AccountType}\n");
            return report.ToString();
        }
    }
}