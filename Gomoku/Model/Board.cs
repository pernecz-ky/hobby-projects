using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Model
{
    public class Board
    {
        public int Size { get; init; }
        public List<List<Piece>> Grid { get; private set; }

        private int emptyPiecesCount;

        public Board(int s)
        {
            Size = s;
            Grid = new();
            for (int i = 0; i < s; i++)
            {
                Grid.Append(new());
                for(int j = 0; j<s; j++)
                {
                    Grid[i].Append(Piece.Empty);
                }
            }
            emptyPiecesCount = Size * Size;
        }

        public Piece GetPiece(int x, int y)
        {
            return Grid[x][y];
        }

        public bool IsValidPlacement(int x, int y)
        {
            return 0 <= x && x <= Size && 0 <= y && y <= Size && Grid[x][y] == Piece.Empty;
        }

        public void PlacePiece(int x, int y, Piece p)
        {
            if (IsValidPlacement(x, y))
            {
                Grid[x][y] = p;
                emptyPiecesCount -= 1;
            }
        }

        public bool CheckWinCondition(int lastX, int lastY, Piece p)
        {
            List<(int, int)> directions = new();
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j<=1; j++)
                {
                    if (lastX + i < 0 || lastX + i > Size || lastY + j < 0 || lastY + j > Size || (i == 0 && j == 0)) continue;
                    if (GetPiece(lastX+i, lastY+j) == p)
                    {
                        directions.Append((i, j));
                    }
                }
            }

            int consecutivePieceCounter = 0;
            foreach ((int dirI, int dirJ) in directions)
            {
                consecutivePieceCounter = 0;
                while (GetPiece(lastX+dirI, lastY+dirJ) == p)
                {
                    consecutivePieceCounter++;
                }
                if(consecutivePieceCounter == 5)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsBoardFull()
        {
            return emptyPiecesCount == 0;
        }

        public void ClearBoard()
        {
            Grid = new();
            for (int i = 0; i < Size; i++)
            {
                Grid.Append(new());
                for (int j = 0; j < Size; j++)
                {
                    Grid[i].Append(Piece.Empty);
                }
            }
            emptyPiecesCount = Size * Size;
        }
    }
}
