using System;
using System.Collections.Generic;
using System.Text;

public static class ArrayExt
{
    public static T SafeGetValue<T>(this T[,] array, Vector2Int p)
    {
        return SafeGetValue(array, p.X, p.Y);
    }
    public static T SafeGetValue<T>(this T[,] array, int x, int y)
    {
        try
        {
            return (T)array.GetValue(x, y);
        } catch (Exception)
        {
            return default;
        }
    }
}

