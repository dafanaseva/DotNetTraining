namespace Task2.CreateCommands;

internal interface ICommandCreator
{
    Command CreateCommand(string commandName);
}