namespace Lab_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nEnter your nickname:");
            string? nickname1 = Console.ReadLine();
            Console.WriteLine("\nEnter opponent's nickname:");
            string? nickname2 = Console.ReadLine();
            Console.WriteLine("\nEnter initial rating:");
            int initialrating = Convert.ToInt32(Console.ReadLine());
            var acc1 = new UpgradedAccount(nickname1!, initialrating);
            var acc2 = new VipAccount(nickname2!, initialrating);
            Console.WriteLine("\nEnter the number of games:");
            int gamescount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nRating of each games:");
            int bid = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < gamescount; i++)
            {
                Console.WriteLine($"\nGame type {i + 1} :\n1 - Ordinary, 2 - For one player, 3 - Training");
                int gametype = Convert.ToInt32(Console.ReadLine());
                switch (gametype)
                {
                    case 1: var regulargame = CreateGame.GetRegular(acc1, acc2, bid); regulargame.Play(); break;
                    case 2: var sologame = CreateGame.GetSolo(acc1, bid); sologame.Play(); break;
                    case 3: var traininggame = CreateGame.GetTraining(acc1, acc2); traininggame.Play(); break;
                }
            }
            Console.WriteLine($"\nPlayer statistics {nickname1!} :\n");
            Console.WriteLine(acc1.GetStats());
            Console.WriteLine($"\nPlayer statistics {nickname2!} :\n");
            Console.WriteLine(acc2.GetStats());
        }
    }
}