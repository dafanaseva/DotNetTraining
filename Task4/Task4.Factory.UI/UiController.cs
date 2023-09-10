using System.IO;
using Task4.Factory.Configuration;

namespace Task4.Factory.UI;

internal sealed class UiController
{
    private readonly Factory _factory;

    public UiController(TextWriter textWriter, FactoryConfig factoryConfig)
    {
        _factory = new Factory(textWriter, factoryConfig);
    }

    public void Start()
    {
        _factory.Start();
    }

    public void Stop()
    {
        _factory.Stop();
    }
}