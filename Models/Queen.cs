using System;
using System.Collections.Generic;
using System.Text;


public class Queen : ChessPiece
{
    public Queen(Color color) : base(color) 
    {
        moveRules.Add(
            new OrGroupRules(
                new DiagonalMoveRule(),
                new StraightMoveRule()
            )
        );
        moveRules.Add(new CheckBlockingRule());
    }

}

