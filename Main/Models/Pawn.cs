using System;
using System.Collections.Generic;
using System.Text;

public class Pawn: ChessPiece
{
    public Pawn(Color color) : base(color)
    {
        moveRules.Add(new OrGroupRules(
            new PawnAttack(),
            new ForwardMoveRule()
        ));
        moveRules.Add(new CheckBlockingRule());
    }

    class PawnAttack : IMoveRule
    {
        public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
        {
            var srcPiece = board.Occupants.SafeGetValue(src);
            var dstPiece = board.Occupants.SafeGetValue(dst);

            if (dstPiece == null || srcPiece == null) return false;
            if (srcPiece.Color == dstPiece.Color) return false;

            var vector = Vector2Int.Substract(dst, src);

            return (src.Y + srcPiece.Forward == dst.Y) &&
                   (vector.Abs().X == 1);
        }
    }
}

