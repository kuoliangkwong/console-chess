using System;
using System.Collections.Generic;
using System.Text;


public class Rook : ChessPiece
{
    public Rook(Color color) : base(color) 
    {
        moveRules.Add(new StraightMoveRule());
        moveRules.Add(new CheckBlockingRule());
    }

}

