﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class DiagonalMoveRule : IMoveRule
{
    readonly int maxStep = 0;

    public DiagonalMoveRule() { }

    public DiagonalMoveRule(int maxStep)
    {
        this.maxStep = maxStep;
    }

    public bool IsValid(Vector2Int src, Vector2Int dst, Board _)
    {
        var isWithinMax = true;
        var absVector = Vector2Int.Substract(dst, src).Abs();
        if (maxStep > 0) 
        {
            isWithinMax = absVector.X <= maxStep && absVector.Y <= maxStep;
        }
        return absVector.IsEqualValues() && isWithinMax;
    }
}

