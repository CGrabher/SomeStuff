using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows;
using System.Windows.Input;
using TicTacToeLibary;
using TicTacToeLibary.Players;
using TicTacToeLibary.Players.Bots;
using TicTacToeWPF.Model;
using System.Reflection.Metadata;
using System.Reflection;
using System.Threading;
using TicTacToeLibary.Database;

namespace TicTacToeWPF.ViewModel
{
    internal class TicTacToeViewModel : BaseViewModel
    {
        private TicTacToeGame _game;
        private DatabaseFacade _dbFacade;

        public TicTacToeViewModel()
        {
            SelectableTypes = PlayerType.GetPlayerTypes();
            _playerOneSelection = SelectableTypes.First();
            _playerTwoSelection = SelectableTypes.First();
            CellCommand = new RelayCommand(CellClick, CanCellClick);
            _dbFacade = new DatabaseFacade();
            //MessageBox.Show(Player.InitializeDatabase());

            
        }

        public List<PlayerType> SelectableTypes { get; }

        private PlayerType _playerOneSelection;
        private PlayerType _playerTwoSelection;

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
        public string _playerOneName;
        public string PlayerOneName
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
        public string _playerTwoName;
        public string PlayerTwoName
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
        public bool IsHumanPlayerSelectedTwo => PlayerTwoSelection.IsHuman;

        public string _gameDialogue;
        public string GameDialogue
        {
            get => _gameDialogue;
            set
            {
                if (value == _gameDialogue)
                    return;

                _gameDialogue = value;
                OnPropertyChanged();
            }
        }
        private void UpdateGameDialogue()
        {
            if (_game == null)
            {
                GameDialogue = "";
            }
            else if (_game.GameOver)
            {
                if (_game.Winner != null)
                    GameDialogue = $"{_game.Winner.Name} wins!";
                else
                    GameDialogue = "It's a draw!";

                // update database
                var p1 = _dbFacade.addPlayerToDatabase(_game.Player1.Name);
                var p2 = _dbFacade.addPlayerToDatabase(_game.Player2.Name);

                if (_game.Winner == _game.Player1)
                {
                    _dbFacade.addResultToPlayer(p1, 10);
                    _dbFacade.addResultToPlayer(p2, 0);
                } else if (_game.Winner == _game.Player2)
                {
                    _dbFacade.addResultToPlayer(p1, 0);
                    _dbFacade.addResultToPlayer(p2, 10);
                }
                else
                {
                    //draw
                    _dbFacade.addResultToPlayer(p1, 5);
                    _dbFacade.addResultToPlayer(p2, 5);
                }
                _dbFacade.UpdateDatabase();

            }
            else
            {
                GameDialogue = $"It's {_game.CurrentPlayer?.Name}'s turn";
            }
        }


        private RelayCommand _playCommand;
        public ICommand PlayCommand => _playCommand ??= new RelayCommand(param => StartGame(), param => CanStartGame());

        private RelayCommand _highScoreCommand;
        public ICommand HighScoreCommand => _highScoreCommand ??= new RelayCommand(param => MessageBox.Show(_dbFacade.getHighScoreOfCurrentMonth()), param => true);
        public void StartGame()
        {
            var player1 = PlayerOneSelection.CreatePlayer(PlayerOneName);
            var player2 = PlayerTwoSelection.CreatePlayer(PlayerTwoName);

            _game = new TicTacToeGame(player1, player2);
            OnPropertyChanged(nameof(Board));
            UpdateGameDialogue();
        }
        private bool CanStartGame()
        {
            bool gameNotInProgress = _game == null || _game.GameOver;



            bool playerNamesAreSet = !(
                PlayerOneSelection.IsHuman && string.IsNullOrWhiteSpace(PlayerOneName) ||
                PlayerTwoSelection.IsHuman && string.IsNullOrWhiteSpace(PlayerTwoName));

            //if (!playerNamesAreSet)
            //{
            //    GameDialogue = "Choose a name";
            //}
            return gameNotInProgress && playerNamesAreSet;
        }

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
            var index = int.Parse(parameter?.ToString() ?? "");
            var x = index % 3;
            var y = index / 3;
            var move = new Move(x, y);

            _game.UpdateBoard(move);


            OnPropertyChanged(nameof(Board));
            UpdateGameDialogue();

            //if (_game.GameOver)
            //{
            //    if (_game.Winner != null)
            //        MessageBox.Show($"Player {_game.Winner.Name} wins!");
            //    else
            //        MessageBox.Show("It's a draw!");
            //}
        }
        private bool CanCellClick(object? parameter)
        {
            if (_game is null || _game.GameOver)
                return false;

            var index = int.Parse(parameter?.ToString() ?? "");
            var x = index % 3;
            var y = index / 3;
            var moves = _game.GetPossibleMoves();
            foreach(var move in moves)
            {
                if (move.X == x && move.Y == y)
                    return true;
            }
            
            return false;

            //var index = int.Parse(parameter?.ToString() ?? "");
            //var result = _game.GetBoardContent(index % 3, index / 3) == default;
            //return result;
        }
    }
}