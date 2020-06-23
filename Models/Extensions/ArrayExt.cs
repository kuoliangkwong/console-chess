using System;
using System.Collections.Generic;
using System.Text;

static class ArrayExt
{
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

