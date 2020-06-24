using System;

public class CheckBlockingRule : IMoveRule
{
    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var vector = Vector2Int.Substract(dst, src);
        var signVector = vector.SignVector;
        var tempVector = new Vector2Int(signVector);
        while (!tempVector.Equal(vector))
        {
            var piece = board.Occupants.SafeGetValue(
                src.X + tempVector.X,
                src.Y + tempVector.Y
            );
            if (piece != null) return false;
            tempVector.Add(signVector);
        }
        return true;
    }
}

