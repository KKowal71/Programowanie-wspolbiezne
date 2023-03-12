using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1_etap0_.Commands;
using WpfApp1_etap0_.ViewModels;

namespace WpfApp1_etap0_.Model
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string _word1;
        private string _restart;
        private bool _isCircleNow = true;
        private Board board = new Board(); //store symbols at appropriate positions in board - help to set the rules
        private List<Button> buttons = new List<Button>(); //store grid buttons - help to clear board after win or fullfill the board

        public MainViewModel()
        {
            Word1 = "CIRCLE STARTS";
            Word2 = "RESTART GAME";
            PlayCommand = new RelayCommand(Play);
            RestartCommand = new RelayCommand(Restart);
        }


        private void Play(object obj)
        {
            var button = (obj as Button);
            buttons.Add(button);
            if (_isCircleNow)
            {
                _isCircleNow = false;
                drawSymbolAndSetButtonDisable(button, "O");
                changeButtonNameToIndexes(button.Name, "O");
            }
            else
            {
                _isCircleNow = true;
                drawSymbolAndSetButtonDisable(button, "X");
                changeButtonNameToIndexes(button.Name, "X");
            }
            if (board.checkBoard())
            {
                MessageBox.Show("EZ WIN");
                gameRestart();

            }
            if (board.isBoardFullFilled())
            {
                MessageBox.Show("DRAW - TRY AGAIN");
                gameRestart();
            }
        }

        public void drawSymbolAndSetButtonDisable(Button button, string symbol)
        {
            button.Content = symbol;
            button.IsEnabled = false;
        }

        public void changeButtonNameToIndexes(string name, string symbol)
        {
            string[] arr = name.ToString().Split('b');
            int i = int.Parse(arr[1]);
            int j = int.Parse(arr[2]);
            setTheSymbolInAppropriatePlace(i, j, symbol);
        }

        public void setTheSymbolInAppropriatePlace(int rowIndex, int columnIndex, string symbol)
        {
            board.GameBoard[rowIndex, columnIndex] = symbol;
;       }

        public void gameRestart()
        {
            clearButtonsList();
            clearHelperBoard();
        }

        public void clearButtonsList()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Content = "";
                buttons[i].IsEnabled = true;
            }
        }

        public void clearHelperBoard()
        {
            for (int i = 0; i < board.getBoardSize(); i++)
            {
                for (int j = 0; j < board.getBoardSize(); j++)
                {
                    board.GameBoard[i, j] = null;
                }

            }
        }

        private void Restart(object obj)
        {
            gameRestart();
        }

        public ICommand PlayCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public string Word1
        {
            get { return _word1; }
            set
            { _word1 = value;
                OnPropertyChanged(); //po zmianie w modelu zmienia sie dane w widoku
            }

        }
        public string Word2
        {
            get { return _restart; }
            set
            {
                _restart = value;
                OnPropertyChanged(); //po zmianie w modelu zmienia sie dane w widoku
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }    
}
