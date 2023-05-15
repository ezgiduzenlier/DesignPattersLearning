
ProductManager productManager = new ProductManager(new factory1());
productManager.GetAll();
Console.ReadLine();
// tüm sayfayı yazdım en son yukardaki kısmı yazdım

public abstract class Logging
{
    public abstract void Log(string message);
}
public class Log4NetLogger : Logging // Log4Net bir loglama methodu
{
    public override void Log(string message)
    {
        Console.WriteLine("Logged with Log4Net ");
    }
}
public class NLogger : Logging // NLogger bir loglama methodu
{
    public override void Log(string message)
    {
        Console.WriteLine("Logged with NLogger ");
    }
}

public abstract class Caching
{
    public abstract void Cache(string data);
    
    
}
public class MemCache:Caching// Memcache bir caching yöntemi
{
    public override void Cache(string data)
    {
        Console.WriteLine("Caching with MemCache");
    }
    
}
public class RedisCache:Caching // Rediscache bir caching yöntemi
{
    public override void Cache(string data)
    {
        Console.WriteLine("Caching with MemCache");
    }

}

// bu noktadan sonra artık fabrikalara ihtiyacımız var
// bu da bizim abstract factory miz oluyor. bu fabrikada nesne üreticez.

public abstract class CrossCuttingConcersFactory // fabrikamız da soyut, yani bundanda yeni fabrika üretebiliriz
{
    public abstract Logging CreateLogger(); // temellerden nesne üretiyoruz (logging,caching)
    public abstract Caching CreateCaching();
}

public class factory1 : CrossCuttingConcersFactory
{
    public override Caching CreateCaching()
    {
        return new RedisCache();// artık sadece burayı değiştirerek istediğim cacheleme ve loglama yönetemini kullanabilirim
    }

    public override Logging CreateLogger()
    {
        return new Log4NetLogger();
    }
}

public class factory2 : CrossCuttingConcersFactory // bir çok fabrika üretebilirim
{
    public override Caching CreateCaching()
    {
        return new MemCache();
    }

    public override Logging CreateLogger()
    {
        return new NLogger();
    }
}

public class ProductManager
{
    private CrossCuttingConcersFactory _crossCuttingConcersFactory;
    private Logging _logging;
    private Caching _caching;

    public ProductManager(CrossCuttingConcersFactory crossCuttingConcersFactory)// burda dependency inversion kulladık 
    { // Dependency Inversion : üst sınıflar, alt sınıflara bağlı olmamalı. bunu yapabilmek için her ikisi de soyut kavramlar
      // üzerinden yönetilmeliidr. burda fabrikamız ve ? soyut.

        _crossCuttingConcersFactory = crossCuttingConcersFactory;
        _logging =  _crossCuttingConcersFactory.CreateLogger();
        _caching = _crossCuttingConcersFactory.CreateCaching();
    }

    public void GetAll()
    {
        _logging.Log("Logged");
        _caching.Cache("Data");
        Console.WriteLine(("Products listed"));
    }

}