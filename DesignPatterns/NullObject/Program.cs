// Null Object deseni, yazılım geliştirirken Null değer döndürmek yerine ve bu değerleri şartlara göre kontrol etmek için
// fazladan kod yazmamızı engelleyen bir tasarım desenidir.
// hangi durumlarda kullanmak mantıklı anlamadım? sık kullanılır mı?
// Normal dependency injection yaptık



CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
customerManager.Save();
Console.ReadLine();




class CustomerManager// burayı newlediğimde bana logger vericek
{
    private ILogger _logger;//bağımlılığı sıfırlamak için yazıyoruz bunu.yani injection gerçekleştirdik

    public CustomerManager(ILogger logger)
    {
        _logger = logger;
    }
    public void Save()
    {
        Console.WriteLine("Saved");
        _logger.Log();//kaydettiğimize dair bide log atalım.
    }

}
interface ILogger
{
    void Log();
}
class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with Log4NetLogger");
    }
}
class NLogLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with NLogLogger");
    }
}
class StubLogger : ILogger//sahte ILogger yani bir şey yapmıyor. 
{//bir işe yaramadığını için daha performanslı hale getirmek için singelton yapalım bu methodu.

    private static StubLogger _stubLogger;
    private static object _lock = new object();

    private StubLogger(){ }


    public static StubLogger GetLogger()
    {
        lock (_lock)
        {
            if(_stubLogger==null)
            {
                _stubLogger = new StubLogger();
            }
            return _stubLogger;
        }
    }
    public void Log()
    {
    }
}
class CustomerManagerTest
{
    public void SaveTest()
    {
        CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());//içine bir ILogger istiyor, sadece customerManager calıstığında loglama da çalısıcaktı.
        // bosuna calısmasın diye ILogger vermek zorundayız o yüzden içi boş bir class olusturup ILogger ı implemente ediyoruz.
        // null göndersek hata verir o yüzden sahte ILogger kullandık.
    }
}