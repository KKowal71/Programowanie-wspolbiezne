using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfApp1_etap0_.ViewModels
{
    public class Board
    {
        private const int boardSize = 3;
        private string[,] gameBoard = new string[boardSize, boardSize];

        public string[,] GameBoard { get => gameBoard; set => gameBoard = value; }
        public int getBoardSize()
        {
            return boardSize;
        }

        public bool checkBoard()
        {
            
            for (int i = 0; i < boardSize; i++)
            {
                if (CheckRowAndColumn(i, true) || CheckRowAndColumn(i, false) || checkDiagonal())
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckRowAndColumn(int index, bool isRow) 
        {
            string[] arr = new string[boardSize];
            for (int i=0; i<boardSize; i++)
            {
                if(isRow) arr[i] = gameBoard[index, i];
                else arr[i] = gameBoard[i, index];
                if (arr.Count(x => x == "X") == 3 || arr.Count(x => x == "O") == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkDiagonal()
        {
            if (gameBoard[0,0] !=null && gameBoard[1, 1] != null && gameBoard[2, 2] != null)
            {
                if (gameBoard[0,0]==gameBoard[1,1] && gameBoard[0, 0]==gameBoard[2, 2])
                {
                    return true;
                }
            return false;
            }
            if (gameBoard[0, 2] != null && gameBoard[1, 1] != null && gameBoard[2, 0] != null)
            {
                if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[0, 2] == gameBoard[2, 0])
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool isBoardFullFilled()
        {
            for(int i=0; i< boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (gameBoard[i, j] == null) return false;
                }
            }
            return true;
        }
        
        

    }
}
