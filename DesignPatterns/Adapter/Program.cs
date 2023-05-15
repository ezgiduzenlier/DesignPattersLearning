// Amacı, farklı sistemlerin kendi sistemimize entegre edilmesi durumunda bizimkinin bozulmadan,
// o sistem bizim sistemimizmiş gibi devam etmesini sağlamaktır.
// örneğin bi bankanın ödeme servisini dahil edebiliriz.

ProductManager productManager = new ProductManager(new Log4NetAdapter()); // ILogger türünde bi parametre girmeliyim, çünkü ProductManagerde ILogger a bağımlıyım.
productManager.Save();
Console.ReadLine();


class ProductManager
{
    private ILogger _logger; 

    public ProductManager(ILogger logger) 
    {
        _logger = logger;
    }

    public void Save()
    {
        _logger.Log("User Data");
        Console.WriteLine("Saved");
    }
}
interface ILogger
{
    void Log(string message);
}
class EdLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Logged, {0}", message);
    }
}
class Log4Net
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Logged with Log4Net, {0}", message);
    }
}
// burda ILogger ın logu gerekli implementasonu gerçekleştiriyor.
class Log4NetAdapter : ILogger // Log4Neti nugetten indirdiğimiz bir kütüphane gibi düşün. Adapter kullanarak projemizin bir sınıfı gibi kullanabiliriz.
{
    public void Log(string message)
    {
        Log4Net log4Net = new Log4Net();
        log4Net.LogMessage(message);
    }
}

