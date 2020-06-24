using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public abstract class ChessPiece: IChessRule
{
    public Color Color
    {
        get;  private set;
    }

    public int Forward
    {
        get
        {
            return Color == Color.White ? 1 : -1;
        }
    }

    public bool hasMoved;

    protected List<IMoveRule> moveRules;

    protected ChessPiece(Color color)
    {
        this.Color = color;
        moveRules = new List<IMoveRule>
        {
            new GeneralRule()
        };
        hasMoved = false;
    }

    public virtual bool CheckValidMove(Vector2Int src, Vector2Int dst, Board board)
    {
        foreach(var rule in moveRules)
        {
            if (!rule.IsValid(src, dst, board)) return false;
        }
        return true;
    }
}

