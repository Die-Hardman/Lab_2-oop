namespace Lab_2
{
    public abstract class BaseGame
    {
        public virtual int GetRating { get; }
        public GameAccount Account1;
        public GameAccount Account2;
        public abstract void Play();
        public BaseGame(GameAccount account1, GameAccount account2, int Rating)
        {
            Account1 = account1;
            Account2 = account2;
            GetRating = Rating;
        }
        public BaseGame(GameAccount account1, int Rating)
        {
            Account1 = account1;
            GetRating = Rating;
        }
        public BaseGame(GameAccount account1, GameAccount account2)
        {
            Account1 = account1;
            Account2 = account2;
            GetRating = 0;
        }
    }
}