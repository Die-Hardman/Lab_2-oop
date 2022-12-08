

namespace Lab_2
{
    class UpgradedAccount : GameAccount
    {
        public UpgradedAccount(string name, int startingrating) : base(name, startingrating)
        {
            AccountType = "Super";
        }
        private static int WinStreak = 0;
        public override void WinGame(string playername, string opponentname, BaseGame game, string gamemode)
        {
            WinStreak++;
            if (WinStreak >= 3)
            {
                var gamewon = new Game(playername, opponentname, game.GetRating + (game.GetRating / 5), "Win", gamemode);
                allGames.Add(gamewon);
            }
            else
            {
                var gamewon = new Game(playername, opponentname, game.GetRating, "Win", gamemode);
                allGames.Add(gamewon);
            }
        }
        public override void LoseGame(string playername, string opponentname, BaseGame game, string gamemode)
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
                WinStreak = 0;
                var lostgame = new Game(playername, opponentname, -game.GetRating, "Lose", gamemode);
                allGames.Add(lostgame);
            }
        }
    }
}