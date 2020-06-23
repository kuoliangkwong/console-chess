using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

class StraightMoveRule : IMoveRule
{
    readonly int maxStep = 0;

    public StraightMoveRule(int maxStep)
    {
        this.maxStep = maxStep;
    }

    public bool IsValid(Vector2Int src, Vector2Int dst, Board _)
    {
        var isWithinMax = true;
        var absVector = Vector2Int.Substract(src, dst).Abs();
        if (maxStep > 0) 
        {
            isWithinMax = absVector.ContainsValue(maxStep);
        }
        return absVector.ContainsZero() && isWithinMax;
    }
}

