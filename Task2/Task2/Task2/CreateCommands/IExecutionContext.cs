namespace Task2.CreateCommands;

internal interface IExecutionContext
{
    public float PopValue();

    public float PeekValue();

    public void SaveValue(float value);

    public void SaveParameter(string parameterName, float parameterValue);

    public float GetParameterValue(string parameterName);
}