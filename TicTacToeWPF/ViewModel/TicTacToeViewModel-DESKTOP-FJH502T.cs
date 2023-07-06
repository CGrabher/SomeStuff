using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TicTacToeLibary;
using TicTacToeLibary.Players;
using TicTacToeLibary.Players.Bots;
using TicTacToeWPF.Model;

namespace TicTacToeWPF.ViewModel
{
    internal class TicTacToeViewModel : BaseViewModel
    {
        private TicTacToeGame _game;
        private ObservableCollection<string> _board;
        private RelayCommand _cellCommand;

        public TicTacToeViewModel()
        {

            SelectableTypes = PlayerType.GetPlayerTypes();

            _playerOneSelection = SelectableTypes.First();






            _game = new TicTacToeGame(new HumanPlayer("Player 1"), new BobBot());
            _board = new ObservableCollection<string>(new string[9]);

            _cellCommand = new RelayCommand(CellClick, CanCellClick);
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
            } 
        }




        public ObservableCollection<string> Board
        {
            get { return _board; }
            set { _board = value; OnPropertyChanged(); }
        }

        public ICommand CellCommand => _cellCommand;

        private bool CanCellClick(object? parameter)
        {
            if (_game.GameOver)
                return false;

            var index = int.Parse(parameter?.ToString() ?? "");
            return _game.GetBoardContent(index % 3, index / 3) == default;
        }

        private void CellClick(object? parameter)
        {
            var index = int.Parse(parameter?.ToString() ?? "");
            var x = index % 3;
            var y = index / 3;
            var move = new Move(x, y);

            _game.UpdateBoard(move);

            var symbol = _game.GetBoardContent(x, y);
            Board[index] = symbol.ToString();

            if (_game.GameOver)
            {
                if (_game.Winner != null)
                    System.Windows.MessageBox.Show($"Player {_game.Winner.Name} wins!");
                else
                    System.Windows.MessageBox.Show("It's a draw!");
            }
        }
    }
}
