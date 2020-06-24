using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

public class Input
{
    public static bool IsValidString(params string[] srcArr)
    {
        foreach (var src in srcArr)
        {
            if (src == null) return false;
            if (src.Length != 2) return false;
            var charArr = src.ToCharArray();
            if (!char.IsLetter(charArr[0]) || !char.IsDigit(charArr[1])) return false;
            if (!Board.CHAR_TO_INT.ContainsKey(charArr[0])) return false;
        }
        return true;
    }

    public static Vector2Int ToVector2(string src)
    {
        // Will add more checking here to prevent null or index-out-of-range crash
        var charArr = src.ToLower().ToCharArray();
        return new Vector2Int(
            Board.CHAR_TO_INT[charArr[0]], 
            int.Parse(charArr[1].ToString())
        );
    }
}

