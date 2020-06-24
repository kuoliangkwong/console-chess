using System;
using System.Collections.Generic;
using System.Text;

public interface IMoveRule
{
    bool IsValid(Vector2Int src, Vector2Int dst, Board board);
}
