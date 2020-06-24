using System;

public class GeneralRule : IMoveRule
{
    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var srcPiece = board.Occupants.SafeGetValue(src.X, src.Y);
        var dstPiece = board.Occupants.SafeGetValue(dst.X, dst.Y);

        if (src.Equal(dst)) return false;

        if (srcPiece == null) return false;

        if (dst.X < 0 || dst.X > 7 || dst.Y < 0 || dst.Y > 7) return false;

        if (dstPiece != null && dstPiece.Color == srcPiece.Color) return false;

        return true;
    }
}

