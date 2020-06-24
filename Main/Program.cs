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
            Console.WriteLine($"\n{game.CurrentTurn}'s turn");
            Console.Write("Source: ");
            var src = Console.ReadLine();
            Console.Write("Destination: ");
            var dst = Console.ReadLine();

            try {
                var (winner, message) = game.Move(src, dst);
                if (message != null)
                {
                    Console.WriteLine(message);
                }
                if (winner != null)
                {
                    Console.WriteLine($"{winner} wins!!");
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

