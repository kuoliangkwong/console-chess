using System;
using System.Collections.Generic;
using System.Text;


struct Vector2Int
{
    public int X;
    public int Y;

    static Vector2Int() { }

    public Vector2Int(int x, int y) {
        this.X = x;
        this.Y = y;
    }

    public void Substract(int x, int y)
    {
        this.X -= x;
        this.Y -= y;
    }

    public Vector2Int Abs()
    {
        return new Vector2Int(
            Math.Abs(X),
            Math.Abs(Y)
        );
    }

    public bool IsEqualValues()
    {
        return X == Y;
    }

    public bool ContainsZero()
    {
        return X == 0 || Y == 0;
    }

    public bool ContainsValue(int value)
    {
        return X == value || Y == value;
    }

    public static Vector2Int Substract(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(
            right.X - left.X,
            right.Y - left.Y
        );
    }
}

