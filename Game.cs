using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Game
{
    int turnIndex;
    Board board;

    public Game()
    {
        board = new Board();
        Reset();
    }

    public Color CurrentTurn
    {
        get
        {
            return IndexToColor(turnIndex);
        }
    }

    public void Reset()
    {
        board.Reset();
        turnIndex = 0;
    }

    public Color? Move(string srcStr, string dstStr)
    {
        if (!Input.IsValidString(srcStr, dstStr)) throw new Exception("Invalid input");

        var srcVector = Input.ToVector2(srcStr);
        var dstVector = Input.ToVector2(dstStr);

        srcVector.Substract(1, 1);
        dstVector.Substract(1, 1);

        return board.Move(
            CurrentTurn,
            srcVector,
            dstVector
        );
    }

    public Color NextTurn()
    {
        turnIndex++;
        if (turnIndex > 9)
        {
            turnIndex = 0;
        }
        return IndexToColor(turnIndex);
    }

    public Color IndexToColor(int index)
    {
        return index % 2 == 0 ? Color.White : Color.Black;
    }
}

