
namespace Lab_2
{
    class VipAccount : GameAccount
    {
        public VipAccount(string name, int startingrating) : base(name, startingrating)
        {
            AccountType = "VIP";
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
                var lostgame = new Game(playername, opponentname, -(game.GetRating / 2), "Lose", gamemode);
                allGames.Add(lostgame);
            }
        }
    }
}