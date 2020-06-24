using System;
using System.Collections.Generic;
using System.Text;


public class Knight : ChessPiece
{
    public Knight(Color color) : base(color) 
    {
        moveRules.Add(new LMoveRule());
    }

}

