using System.Reflection;
using log4net;
using log4net.Config;

namespace Task2;

internal static class LogManager
{
    public static ILog GetLogger(this Type type)
    {
        var logRepository = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        return log4net.LogManager.GetLogger(type);
    }
}