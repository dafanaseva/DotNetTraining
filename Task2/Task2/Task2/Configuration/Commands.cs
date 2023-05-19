﻿using System.Collections.ObjectModel;

namespace Task2.Configuration;

internal sealed class Commands
{
    public string? Namespace => null;

    private ReadOnlyDictionary<string, string>? CommandNameClassName { get; } = new(new Dictionary<string, string>());

    public Dictionary<string, Type?> ToDictionary()
    {
        return CommandNameClassName?.ToDictionary(
                   t => t.Key,
                   t => Type.GetType($"{Namespace}.{t.Value}")) ??
               new Dictionary<string, Type?>();
    }
}