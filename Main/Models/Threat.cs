public class Threat
{
    public static ChessPiece FindPiece(Color player, Vector2Int origin, Board board)
    {
        var moveDirs = Direction.MOVE_DIRECTIONS;
        foreach(var moveDir in moveDirs)
        {
            var currPos = new Vector2Int(origin);
            while (Board.IsWithinBound(currPos))
            {
                currPos.Add(moveDir);
                var (foundThreat, piece) = FindThreatPiece(player, currPos, origin, board);
                if (piece != null && foundThreat) return piece;
                if (piece != null) break;
            }
        }

        var lMovePostions = Direction.L_MOVE_DIRECTIONS;
        foreach (var lMovePos in lMovePostions)
        {
            var currPos = Vector2Int.Add(origin, lMovePos);
            var (foundThreat, piece) = FindThreatPiece(player, currPos, origin, board);
            if (piece != null && foundThreat) return piece;
        }

        return null;
    }

    private static (bool, ChessPiece) FindThreatPiece(Color player, Vector2Int src, Vector2Int target, Board board)
    {
        var piece = board.Occupants.SafeGetValue(src.X, src.Y);
        if (piece == null) return (false, null);
        if (piece.Color == player) return (false, piece);
        if (!piece.CheckValidMove(src, target, board)) return (false, piece);
        return (true, piece);
    }
}

