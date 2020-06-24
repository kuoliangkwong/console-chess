using System;
using System.Collections.Generic;
using System.Text;

public class Pawn: ChessPiece
{
    public Pawn(Color color) : base(color)
    {
        moveRules.Add(new ForwardMoveRule());
        moveRules.Add(new CheckBlockingRule());
    }
}

