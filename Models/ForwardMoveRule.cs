using System;
using System.Collections.Generic;
using System.Text;

public class ForwardMoveRule : IMoveRule
{
    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var srcPiece = board.Occupants.SafeGetValue(src);
        var dstPiece = board.Occupants.SafeGetValue(dst);

        if (dstPiece != null) return false;

        var vector = Vector2Int.Substract(dst, src);

        if (vector.Abs().X > 0) return false;
        
        var valid = false;
        var validDir = srcPiece.Forward == vector.SignY;
        if (vector.Abs().Y == 2)
        {
            valid = validDir && !srcPiece.hasMoved;
        } else if (vector.Abs().Y == 1)
        {
            valid = validDir;
        }
        return valid;
    }
}

