
namespace Lab_2
{
    public class TrainingGame : BaseGame
    {
        public override int GetRating => 0;
        public TrainingGame(GameAccount account1, GameAccount account2) : base(account1, account2)
        {

        }
        public override void Play()
        {
            Random random = new Random();
            int n = random.Next(0, 2);
            if (n == 0)
            {
                Account1.WinGame(Account1.UserName, Account2.UserName, this, "Training");
                Account2.LoseGame(Account2.UserName, Account1.UserName, this, "Training");
            }
            else
            {
                Account2.WinGame(Account2.UserName, Account1.UserName, this, "Training");
                Account1.LoseGame(Account1.UserName, Account2.UserName, this, "Training");
            }
        }
    }
}