namespace Task2;

internal static class CancelKeyPressedObserver
{
    public static void WaitCancelKeyPressed()
    {
        Console.CancelKeyPress += HandleCancelKeyPressed;
    }

    private static void HandleCancelKeyPressed(object? sender, EventArgs eventArgs)
    {
        Environment.Exit(0);
    }
}
