using System;
using System.Collections.Generic;
using System.Text;


public class King : ChessPiece
{
    public King(Color color) : base(color) 
    {
        moveRules.Add(
            new OrGroupRules(
                new DiagonalMoveRule(1),
                new StraightMoveRule(1)
            )
        );
        moveRules.Add(new CheckBlockingRule());
    }

}

