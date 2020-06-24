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
        get; private set;
    }

    public Board()
    {
        Occupants = new ChessPiece[8, 8];
    }
    
    public void Reset()
    {
        Occupants = new ChessPiece[8, 8];
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
            Occupants[x, 0] = whiteElites[x];
        }

        for (int x = 0; x < 8; x++)
        {
            Occupants[x, 1] = new Pawn(Color.White);
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
            Occupants[x, 7] = blackElites[x];
        }

        for (int x = 0; x < 8; x++)
        {
            Occupants[x, 6] = new Pawn(Color.Black);
        }
    }

    public (Color?, string) Move(Color player, Vector2Int src, Vector2Int dst)
    {
        var srcPiece = Occupants.SafeGetValue(src.X, src.Y);
        var dstPiece = Occupants.SafeGetValue(dst.X, dst.Y);

        if (srcPiece == null) throw new Exception("Chess piece not found");

        if (srcPiece != null && player != srcPiece.Color) throw new Exception("Cannot move opponent chess piece");

        if (!srcPiece.CheckValidMove(src, dst, this)) throw new Exception("Invalid Move");

        Occupants[src.X, src.Y] = null;
        Occupants[dst.X, dst.Y] = srcPiece;

        if (dstPiece is King)
        {
            return (player, null);
        }

        var opponent = player == Color.White ? Color.Black : Color.White;
        var (checkmate, kingInCheck) = KingState(opponent);

        if (checkmate) return (player, "Checkmate!!");

        if (kingInCheck) return (null, "Check!!");

        return (null, null);
    }

    public static bool IsWithinBound(Vector2Int origin)
    {
        return origin.X >= 0 && origin.X < 8 && origin.Y >= 0 && origin.Y < 8;
    }

    public Vector2Int[] AvailableMoveAroundLocations(Vector2Int origin)
    {
        var moveDirs = Direction.MOVE_DIRECTIONS;
        var result = new List<Vector2Int>();

        foreach(var dir in moveDirs)
        {
            var pos = Vector2Int.Add(origin, dir);
            if (!IsWithinBound(pos)) continue;
            var piece = Occupants.SafeGetValue(pos);
            if (piece == null)
            {
                result.Add(pos);
            }
        }
        
        return result.ToArray();
    }

    public Vector2Int FindKingPosition(Color color)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                var piece = Occupants.SafeGetValue(i, j);
                if (piece != null && piece.Color == color && piece is King)
                {
                    return new Vector2Int(i, j);
                }
            }
        }
        throw new Exception("Cannot find King");
    }

    public (bool, bool) KingState(Color color)
    {
        var kingPos = FindKingPosition(color);
        var availablePositions = AvailableMoveAroundLocations(kingPos);
        var isKingChecked = Threat.FindPiece(color, kingPos, this) != null;
        var isAroundInThreat = true;
        foreach (var pos in availablePositions)
        {
            isAroundInThreat = isAroundInThreat && Threat.FindPiece(color, pos, this) != null;
        }
        return (isKingChecked && isAroundInThreat, isKingChecked);
    }
}
