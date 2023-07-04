using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TicTacToeLibary.Players;
using TicTacToeLibary.Players.Bots;

namespace TicTacToeWPF.Model
{
    internal class PlayerType
    {
        private readonly Type _type;

        public PlayerType(Type type)
        {
            _type = type;
            IsBot = type.IsSubclassOf(typeof(BotPlayer));
        }
        public string Display => _type.Name;

        public bool IsBot { get; }

        public bool IsHuman => !IsBot;

        public Player CreatePlayer(string? name = null)
        {
            if (IsBot)
                return (Player)Activator.CreateInstance(_type)!;
            else
                return (Player)Activator.CreateInstance(_type, name)!;
        }

        public static List<PlayerType> GetPlayerTypes()
        {
            var result = new List<PlayerType>();
            result.Add(new PlayerType(typeof(HumanPlayer)));
            Type[] botTypes = Assembly.GetAssembly(typeof(BotPlayer))!
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(BotPlayer)))
                .ToArray();
            foreach (var botType in botTypes)
            {
                result.Add(new PlayerType(botType));
            }
            return result;
        }

        //var res = Assembly.GetAssembly(typeof(Player))!
        //    .GetTypes()
        //    .Where(type => type.IsSubclassOf(typeof(Player)))
        //    .Where(type => !type.IsAbstract)
        //    .Select(type => new PlayerType(type))
        //    .ToList();
        //return res;
    }



}