using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Board
{
    public readonly static Dictionary<char, int> CHAR_TO_INT = new Dictionary<char, int>()
    {
        {'a', 1},
        {'b', 2},
        {'c', 3},
        {'d', 4},
        {'e', 5},
        {'f', 6},
        {'g', 7},
        {'h', 8},
    };

    public ChessPiece[,] Occupants
    {
        get
        {
            return occupants;
        }
    }

    ChessPiece[,] occupants = new ChessPiece[8, 8];
    
    public void Reset()
    {
        var whiteElites = new ChessPiece[]
        {
            new Rook(Color.White),
            new Knight(Color.White),
            new Bishop(Color.White),
            new Queen(Color.White),
            new King(Color.White),
            new Bishop(Color.White),
            new Knight(Color.White),
            new Rook(Color.White)
        };

        for (int x = 0; x < 8; x++)
        {
            occupants[x, 0] = whiteElites[x];
        }

        for (int x = 0; x < 8; x++)
        {
            occupants[x, 1] = new Pawn(Color.White);
        }

        var blackElites = new ChessPiece[]
        {
            new Rook(Color.Black),
            new Knight(Color.Black),
            new Bishop(Color.Black),
            new Queen(Color.Black),
            new King(Color.Black),
            new Bishop(Color.Black),
            new Knight(Color.Black),
            new Rook(Color.Black)
        };

        for (int x = 0; x < 8; x++)
        {
            occupants[x, 7] = blackElites[x];
        }

        for (int x = 0; x < 8; x++)
        {
            occupants[x, 6] = new Pawn(Color.Black);
        }
    }

    public Color? Move(Color player, Vector2Int src, Vector2Int dst)
    {
        var srcPiece = occupants.SafeGetValue(src.X, src.Y);
        var dstPiece = occupants.SafeGetValue(dst.X, dst.Y);

        if (srcPiece == null) throw new Exception("Chess piece not found");

        if (srcPiece != null && player != srcPiece.Color) throw new Exception("Cannot move opponent chess piece");

        if (!srcPiece.CheckValidMove(src, dst, this)) throw new Exception("Invalid Move");

        occupants[src.X, src.Y] = null;
        occupants[dst.X, dst.Y] = srcPiece;

        if (dstPiece is King)
        {
            return player;
        }

        return null;
    }
}
