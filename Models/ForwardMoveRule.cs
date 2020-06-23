using System;
using System.Collections.Generic;
using System.Text;

class ForwardMoveRule : IMoveRule
{
    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var vector = Vector2Int.Substract(src, dst);
        var srcPiece = board.Occupants.SafeGetValue(src);
        var signY = vector.Y / Math.Abs(vector.Y);

        var valid = false;
        var validDir = srcPiece.Forward == signY;
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

