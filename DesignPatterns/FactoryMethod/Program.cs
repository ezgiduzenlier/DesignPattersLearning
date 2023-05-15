

CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
Console.ReadLine();



public class LoggerFactory:ILoggerFactory
{
    public ILogger CreateLogger()
    {
        return new EdLogger();
    }
}
public class LoggerFactory2 : ILoggerFactory
{
    public ILogger CreateLogger()
    {
        return new EdLogger();
    }
}
public interface ILoggerFactory
{

}
public interface ILogger
{
    void Log();
}
public class EdLogger:ILogger
{
    public void Log()
    {
        Console.WriteLine("Logger with EdLogger");
    }
}
public class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logger with Log4net");
    }
}
public class CustomerManager
{
    private ILoggerFactory _loggerFactory;
    public CustomerManager(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
    public void Save()
    {
        Console.WriteLine("Saved!");
        ILogger logger = new LoggerFactory().CreateLogger();
        logger.Log();
    }
}




