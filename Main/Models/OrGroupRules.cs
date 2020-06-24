using System;
using System.Collections.Generic;
using System.Text;

class OrGroupRules : IMoveRule
{
    readonly IMoveRule[] rules;

    public OrGroupRules(params IMoveRule[] rules)
    {
        this.rules = rules;
    }

    public bool IsValid(Vector2Int src, Vector2Int dst, Board board)
    {
        var valid = false;
        foreach(var rule in rules)
        {
            valid = valid || rule.IsValid(src, dst, board);
        }
        return valid;
    }
}

