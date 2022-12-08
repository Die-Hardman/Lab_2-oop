

namespace Lab_2
{
    public class SoloGame : BaseGame
    {
        public SoloGame(GameAccount account1, int Rating) : base(account1, Rating)
        {

        }
        public override void Play()
        {
            Random random = new Random();
            int n = random.Next(0, 2);
            if (n == 0)
            {
                Account1.WinGame(Account1.UserName, "---", this, "Single player");
            }
            else
            {
                Account1.LoseGame(Account1.UserName, "---", this, "Single player");
            }
        }
    }
}