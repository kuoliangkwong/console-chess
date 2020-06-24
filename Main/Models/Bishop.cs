using System;
using System.Collections.Generic;
using System.Text;


public class Bishop : ChessPiece
{
    public Bishop(Color color) : base(color) 
    {
        moveRules.Add(new DiagonalMoveRule());
        moveRules.Add(new CheckBlockingRule());
    }

}

