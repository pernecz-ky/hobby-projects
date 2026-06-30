using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Model
{
    public class Game
    {
        public Board CurrentBoard{ get; init; }
        public Piece CurrentPlayer { get; private set; }

        public bool GameOver { get; private set; }

        public Piece Winner { get; private set; }

        public Game(Board cb)
        {
            CurrentBoard = cb;
            CurrentPlayer = Piece.White;
            GameOver = false;
            Winner = Piece.Empty; //signifies that no winner has been detected yet
        }

        public bool TryPlayMove(int x, int y)
        {
            if (!GameOver && CurrentBoard.IsValidPlacement(x,y))
            {
                CurrentBoard.PlacePiece(x, y, CurrentPlayer);
                if (CurrentBoard.CheckWinCondition(x, y, CurrentPlayer))
                {
                    GameOver = true;
                    Winner = CurrentPlayer;
                    return true;
                }
                else if (CurrentBoard.IsBoardFull())
                {
                    GameOver = true;
                    return true;
                }
            }
            return false;
        }

        public void ResetGame()
        {
            CurrentBoard.ClearBoard();
            GameOver = false;
            CurrentPlayer = Piece.White;
            Winner = Piece.Empty;
        }
    }
}
