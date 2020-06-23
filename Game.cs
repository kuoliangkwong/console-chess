using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Game
{
    int turnIndex = 0;
    Board board;

    public Game()
    {
        board = new Board();
        board.Reset();
    }

    public string CurrentPlayerName 
    {
        get
        {
            return CurrentTurn == Color.White ? "Player 1" : "Player 2";
        }
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

    }

    public void Move(string srcStr, string dstStr)
    {
        if (!Input.IsValidString(srcStr, dstStr)) throw new Exception("Invalid input");

        var srcVector = Input.ToVector2(srcStr);
        var dstVector = Input.ToVector2(dstStr);

        srcVector.Substract(1, 1);
        dstVector.Substract(1, 1);
        board.Move(
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

