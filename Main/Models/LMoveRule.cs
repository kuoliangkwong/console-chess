using System;
using System.Collections.Generic;
using System.Text;


public class LMoveRule : IMoveRule
{
    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var absVector = Vector2Int.Substract(dst, src).Abs();
        return (absVector.X == 1 && absVector.Y == 2) ||
            (absVector.X == 2 && absVector.Y == 1);
    }
}

