namespace Task2.Parse;

internal interface ICommandParser
{
    CommandData Parse(string input);
    List<string> GetMatchedGroupValues(string input);
}