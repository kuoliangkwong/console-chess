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
}

