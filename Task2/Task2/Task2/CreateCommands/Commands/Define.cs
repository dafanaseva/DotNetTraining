﻿using Task2.CreateCommands.Exceptions;

namespace Task2.CreateCommands.Commands;

internal sealed class Define : Command
{
    private const int ParameterNameIndex = 0;
    private const int ParameterValueIndex = 1;
    private const int MinArgumentsCount = 2;

    public override void Execute(IExecutionContext executionContext, params object[] arguments)
    {
        if (arguments == null || arguments.Length < MinArgumentsCount)
        {
            throw new InvalidCommandArgumentException("Need two arguments in format '{name} {number}'");
        }

        try
        {
            var argumentName = (string)arguments[ParameterNameIndex];
            var argumentValue = Convert.ToSingle(arguments[ParameterValueIndex]);

            executionContext.SaveParameter(argumentName, argumentValue);
        }
        catch (Exception e)
        {
            Log.Exception(e);

            throw new InvalidCommandArgumentException("Failed to define a new parameter");
        }
    }
}