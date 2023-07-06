using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TicTacToeLibary;
using TicTacToeWPF.Model;

namespace TicTacToeWPF.ViewModel
{
    internal class TicTacToeViewModel : BaseViewModel
    {

        public TicTacToeViewModel()
        {
            SelectableTypes = PlayerType.GetPlayerTypes();
            _playerOneSelection = SelectableTypes.First();
            _playerTwoSelection = SelectableTypes.First();
            CellCommand = new RelayCommand(CellClick, CanCellClick);
        }

        public List<PlayerType> SelectableTypes { get; }

        private PlayerType _playerOneSelection;
        public PlayerType PlayerOneSelection
        {
            get => _playerOneSelection;
            set
            {
                if (value == _playerOneSelection)
                    return;

                _playerOneSelection = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayerOneNameVisibility));
            }
        }
        public string? _playerOneName;
        public string? PlayerOneName
        {
            get => _playerOneName;
            set
            {
                if (value == _playerOneName)
                    return;

                _playerOneName = value;
                OnPropertyChanged();
            }
        }
        public Visibility PlayerOneNameVisibility => PlayerOneSelection.IsHuman ? Visibility.Visible : Visibility.Hidden;
 
        private PlayerType _playerTwoSelection;
        public PlayerType PlayerTwoSelection
        {
            get => _playerTwoSelection;
            set
            {
                if (value == _playerTwoSelection)
                    return;

                _playerTwoSelection = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayerTwoNameVisibility));
            }
        }
        public string? _playerTwoName;
        public string? PlayerTwoName
        {
            get => _playerTwoName;
            set
            {
                if (value == _playerTwoName)
                    return;

                _playerTwoName = value;
                OnPropertyChanged();
            }
        }
        public Visibility PlayerTwoNameVisibility => PlayerTwoSelection.IsHuman ? Visibility.Visible : Visibility.Hidden;

        [MemberNotNullWhen(false, nameof(_game))] //help the stupid compiler
        public bool IsGamePreparation => _game is null || _game.GameOver;

        private TicTacToeGame? _game;

        private RelayCommand? _playCommand;
        public ICommand PlayCommand => _playCommand ??= new RelayCommand(param => StartGame(), param => CanStartGame());
        public void StartGame()
        {
            var player1 = PlayerOneSelection.CreatePlayer(PlayerOneName);
            var player2 = PlayerTwoSelection.CreatePlayer(PlayerTwoName);

            _game = new TicTacToeGame(player1, player2);

            OnPropertyChanged(nameof(Board));
            OnPropertyChanged(nameof(IsGamePreparation));
            OnPropertyChanged(nameof(GameDialogue));

        }
        private bool CanStartGame()
        {
            bool playerNamesAreSet = !(
                PlayerOneSelection.IsHuman && string.IsNullOrWhiteSpace(PlayerOneName) ||
                PlayerTwoSelection.IsHuman && string.IsNullOrWhiteSpace(PlayerTwoName));
            return 
                IsGamePreparation && playerNamesAreSet;
        }
        //private bool CanStartGame() => 
        //    IsGamePreparation &&
        //    (PlayerOneSelection.IsBot || !string.IsNullOrWhiteSpace(PlayerOneName)) &&
        //    (PlayerTwoSelection.IsBot || !string.IsNullOrWhiteSpace(PlayerTwoName));

        public string[] Board
        {
            get
            {
                var result = new string[9];

                if (_game is null)
                    return result;


                for (int i = 0; i < 9; i++)
                {
                    var x = i % 3;
                    var y = i / 3;
                    result[i] = _game.GetBoardContent(x, y).ToString();
                };
                return result;
            }
        }

        public ICommand CellCommand { get; }
        private void CellClick(object? parameter)
        {
            if (IsGamePreparation)
                return; //a bit redundant, but actually makes it water-tight

            var index = int.Parse(parameter?.ToString() ?? "");
            var x = index % 3;
            var y = index / 3;

            _game.UpdateBoard(new Move(x, y));
           
            OnPropertyChanged(nameof(Board));
            OnPropertyChanged(nameof(IsGamePreparation));
            OnPropertyChanged(nameof(GameDialogue));
        }
        private bool CanCellClick(object? parameter)
        {
            if (IsGamePreparation)
                return false;

            var index = int.Parse(parameter?.ToString() ?? "");
            var x = index % 3;
            var y = index / 3;
           
            var m = new Move(x, y);
            return _game.GetPossibleMoves().Any(pm => pm.Equals(m));

            //var moves = _game.GetPossibleMoves();
            //foreach (var move in moves)
            //{
            //    if (move.X == x && move.Y == y)
            //        return true;
            //}

            //return false;

        }

        public string GameDialogue
        {
            get
            {
                if (_game == null)
                    return "";
                else if (_game.GameOver)
                {
                    if (_game.Winner != null)
                        return $"{_game.Winner.Name} wins!";
                    else
                        return "It's a draw!";
                }
                else
                    return $"It's {_game.CurrentPlayer?.Name}'s turn";
            }
        }
        //public string GameDialogue =>
        //    _game is null
        //        ? string.Empty
        //        : !_game.GameOver
        //            ? $"It's {_game.CurrentPlayer?.Name}'s turn"
        //            : _game.Winner is null
        //                ? "It's a draw!"
        //                : $"{_game.Winner.Name} wins!";

        //public string GameDialogue => (_game is null, _game?.GameOver == true, _game?.Winner is not null) switch
        //{
        //    (true, _, _) => string.Empty,
        //    (_, false, _) => $"It's {_game?.CurrentPlayer?.Name}'s turn",
        //    (_, _, true) => $"{_game!.Winner!.Name} wins!",
        //    (_, _, false) => "It's a draw!"
        //};


    }
}