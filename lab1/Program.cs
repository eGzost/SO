using Spectre.Console;


var manipulations = new Dictionary<string, Func<string, string>> {
    {"Remove spaces", TextManipulations.ReplaceSpaces},
    {"Mirror text", TextManipulations.Mirror},
    {"Mirror words", TextManipulations.MirrorWords}
};

void Prompt()
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
    Prompt();
}
Prompt();

public static class TextManipulations
{
    public static string ReplaceSpaces(string text) => text.Replace(" ", "");
    public static string Mirror(string text) => new(text.Reverse().ToArray());
    public static string MirrorWords(string text) => string.Join(" ", text.Split(" ").Select(Mirror));
}