﻿namespace Task2.CommandCreator;

internal static class ArithmeticalOperation
{
    public static readonly Func<float, float, float> Addition = (p1, p2) => p1 + p2;
    public static readonly Func<float, float, float> Subtraction = (p1, p2) => p1 - p2;
    public static readonly Func<float, float, float> Multiplication = (p1, p2) => p1 * p2;
    public static readonly Func<float, float, float> Division = (p1, p2) => p1 / p2;
    public static readonly Func<float, float> SquareRoot = p => (float)Math.Sqrt(p);
}