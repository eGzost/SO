using Spectre.Console;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var manipulations = new Dictionary<string, Func<string, string>> {
            {"Remove spaces", ReplaceSpaces.Manipulate},
            {"Mirror text", Mirror.Manipulate},
            {"Mirror words", MirrorWords.Manipulate}
        };

        Prompt(manipulations);
    }

    static void Prompt(Dictionary<string, Func<string, string>> manipulations)
    {
        Console.Clear();
        AnsiConsole.MarkupLine("[green]Text manipulation[/]");
        AnsiConsole.MarkupLine("");
        string text = AnsiConsole.Prompt(new TextPrompt<string>("Text input: "));
        string manipulation = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Select a manipulation")
                .AddChoices(manipulations.Keys)
        );
        string replacedText = manipulations[manipulation](text);
        AnsiConsole.MarkupLine($"Edited text: {replacedText}");
        AnsiConsole.MarkupLine("[blue]Press any key to continue[/]");
        Console.ReadKey(true);
        Prompt(manipulations);
    }
}