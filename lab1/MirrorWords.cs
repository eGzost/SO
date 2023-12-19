using System;
using System.Linq;

public static class MirrorWords
{
    public static string Manipulate(string text) => string.Join(" ", text.Split(" ").Select(Mirror.Manipulate));
}