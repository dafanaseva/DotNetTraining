namespace Task2.CreateCommands;

internal interface IExecutionContext
{
    public float PopValue(bool shouldDelete = true);

    public void SaveValue(float value);

    public void SaveParameter(string parameterName, float parameterValue);

    public float GetParameterValue(string parameterName);
}