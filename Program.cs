using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to KKL Chess Game");
        var game = new Game();
        game.Reset();
        while (true)
        {
            Console.WriteLine($"{game.CurrentPlayerName}'s turn");
            Console.Write("Source: ");
            var src = Console.ReadLine();
            Console.Write("Destination: ");
            var dst = Console.ReadLine();

            try {
                var winnerName = game.Move(src, dst);
                if (winnerName != null)
                {
                    Console.WriteLine($"{winnerName} wins!!");
                    Console.Write("Press enter to play again.");
                    Console.ReadLine();
                    game.Reset();
                    continue;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            game.NextTurn();
        }
    }
}

