using Spectre.Console;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using TicTacToeLibary;
using TicTacToeLibary.Players;
using TicTacToeLibary.Players.Bots;
using System;
using System.Collections.Generic;
using System.IO;

namespace TicTacToeConsoleApp;

internal class Program
{
    public static void Main()
    {
        var player1 = GetHumanPlayer(1);
        var player2 = GetOpponent();

        do
        {
            Play(new(player1, player2));
        } while (AskPlayAgain());

    }

    private static bool AskPlayAgain()
    {
        Console.WriteLine();
        var again = AnsiConsole.Prompt(
            new SelectionPrompt<bool>()
            .Title("Play again?")
            .UseConverter(x => x ? "Yes" : "No")
            .AddChoices(new[] { true, false }));
        return again;
    }

    private static void Play(TicTacToeGame game)
    {
        while (!game.GameOver)
        {
            DrawBoard(game);
            var move = GetPlayerMove(game);
            game.UpdateBoard(move);

        }
        DrawBoard(game);

        //if (game.Winner is Player winner)
        //    Console.WriteLine($"{winner.Name} wins!");
        //else  
        //    Console.WriteLine("It's a draw!");

        Console.WriteLine();
        var message = game.Winner is Player winner
            ? $"{winner.Name} wins!"
            : "It's a draw!";
        Console.WriteLine(message);
    }

    private static Move GetPlayerMove(TicTacToeGame game)
    {
        var possibleMoves = game.GetPossibleMoves();
        Console.WriteLine();
        while (true)
        {
            Console.WriteLine($"{game.CurrentPlayer?.Name}, enter your move (1-9):");
            if (!int.TryParse(Console.ReadLine(), out var number) || number is < 1 or > 9)
            {
                Console.WriteLine("Please choose a number, 1 to 9...");
                continue;
            }

            int x = (number - 1) % 3;
            int y = (number - 1) / 3;

            //if (!possibleMoves.Any(m => m.X == x && m.Y == y))

            if (possibleMoves.All(m => m.X != x || m.Y != y))
            {
                Console.WriteLine("Already occupied, choose a free spot");
                continue;
            }

            return new Move(x, y);
        }
    }

    private static void DrawBoard(TicTacToeGame game)
    {
        Console.Clear();
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var val = game.GetBoardContent(col, row);
                string content;
                if (val is 'X' or 'O')
                {
                    content = val.ToString();
                    Console.ForegroundColor = val is 'X' ? ConsoleColor.Green : ConsoleColor.Red;
                }
                else
                {
                    content = (3 * row + col + 1).ToString();
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.Write(" {0} ", content);
                Console.ResetColor();
                if (col < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if (row < 2)
                Console.WriteLine("---+---+---");
        }
    }

    private static Player GetHumanPlayer(int playerNumber)
    {
        Console.WriteLine($"Enter name of player {playerNumber}");
        string? npo = Console.ReadLine();

        while (string.IsNullOrEmpty(npo))
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Enter Name of Player 1");
            npo = Console.ReadLine();
        }
        return new HumanPlayer(npo);
    }

    private static Player GetOpponent()
    {
        Type[] botTypes = ReflectionHelper.GetSubclasses(typeof(BotPlayer));
        //List<string> botNames = new ()
        //{
        //    "Player"
        //};
        //foreach (Type subclass in botTypes)
        //{
        //    botNames.Add(subclass.Name);
        //}

        var botNames = botTypes
            .Select(x => x.Name)
            .ToList();
        botNames.Insert(0, "Player");

        Console.WriteLine();
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Choose your opponent")
            .AddChoices(botNames));

        if (selection == "Player")
        {
            return GetHumanPlayer(2);
        }


        Type botType = botTypes.First(subclass => subclass.Name == selection);
        return (Player)Activator.CreateInstance(botType)!;
    }

public static class ReflectionHelper
    {
        public static Type[] GetSubclasses(Type baseClass)
        {
            return Assembly.GetAssembly(baseClass)!
                .GetTypes()
                .Where(type => type.IsSubclassOf(baseClass))
                .ToArray();
        }
    }
}
