using System;
using System.Collections.Generic;
using System.Text;

public struct Vector2Int
{
    public int X;
    public int Y;

    public int SignX
    {
        get
        {
            if (X == 0) return 0;
            return X / Math.Abs(X);
        }
    }

    public int SignY
    {
        get
        {
            if (Y == 0) return 0;
            return Y / Math.Abs(Y);
        }
    }

    public Vector2Int SignVector
    {
        get
        {
            return new Vector2Int(SignX, SignY);
        }
    }

    static Vector2Int() { }

    public Vector2Int(int x, int y) {
        X = x;
        Y = y;
    }

    public Vector2Int(Vector2Int v)
    {
        X = v.X;
        Y = v.Y;
    }

    public void Substract(int x, int y)
    {
        X -= x;
        Y -= y;
    }

    public void Add(int x, int y)
    {
        X += x;
        Y += y;
    }

    public void Add(Vector2Int v)
    {
        Add(v.X, v.Y);
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

    public bool IsZero()
    {
        return X == 0 && Y == 0;
    }

    public bool Equal(Vector2Int v)
    {
        return X == v.X && Y == v.Y;
    }

    public bool ContainsValue(int value)
    {
        return X == value || Y == value;
    }

    public static Vector2Int Substract(Vector2Int left, Vector2Int right)
    {
        return new Vector2Int(
            left.X - right.X,
            left.Y - right.Y
        );
    }

}

