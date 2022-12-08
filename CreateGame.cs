namespace Lab_2
{
    class CreateGame
    {
        public static BaseGame GetRegular(GameAccount account1, GameAccount account2, int Rating)
        {
            return new RegularGame(account1, account2, Rating);
        }
        public static BaseGame GetSolo(GameAccount account, int Rating)
        {
            return new SoloGame(account, Rating);
        }
        public static BaseGame GetTraining(GameAccount account1, GameAccount account2)
        {
            return new TrainingGame(account1, account2);
        }
    }
}