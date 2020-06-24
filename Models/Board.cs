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

    }

    public Color? Move(Color player, Vector2Int src, Vector2Int dst)
    {
        var srcPiece = occupants.SafeGetValue(src.X, src.Y);
        var dstPiece = occupants.SafeGetValue(dst.X, dst.Y);

        if (srcPiece == null) throw new Exception("No chess piece found");

        if (dst.X < 0 || dst.X > 7 || dst.Y < 0 || dst.Y > 7) throw new Exception("Destination is out of range");

        if (player != srcPiece.Color) throw new Exception("Cannot move opponent chess piece");

        if (dstPiece != null && dstPiece.Color == srcPiece.Color) throw new Exception("Cannot move to same color chess piece");

        if (srcPiece.CheckValidMove(src, dst, this)) throw new Exception("Invalid Move");

        occupants[dst.X, dst.Y] = srcPiece;

        if (dstPiece is King)
        {
            return player;
        }

        return null;
    }
}
