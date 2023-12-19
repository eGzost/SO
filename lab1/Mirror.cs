using System;
using System.Linq;

public static class Mirror
{
    public static string Manipulate(string text) => new string(text.Reverse().ToArray());
}
