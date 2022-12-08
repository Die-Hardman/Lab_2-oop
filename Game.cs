namespace Lab_2
{
    public class Game
    {
        public string Player { get; }
        public string Opponent { get; }
        public int Rating { get; }
        public string Outcome { get; }
        public string GameMode { get; }
        public Game(string player, string opponent, int rating, string outcome, string gamemode)
        {
            Player = player;
            Opponent = opponent;
            Rating = rating;
            Outcome = outcome;
            GameMode = gamemode;
        }
    }
}