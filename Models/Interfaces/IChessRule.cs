using System;
using System.Collections.Generic;
using System.Text;

interface IChessRule
{
    bool CheckValidMove(Vector2Int src, Vector2Int dst, Board board);
}
