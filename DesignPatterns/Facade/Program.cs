// ortak amaç için kullandığımız sınıflara her zaman ayrı ayrı ulaşmaktansa bir cephe üzerinden ulaşmak.
// farklı tasarım desenleri ve dependence inveksion ile birlikte daha güzel kullanılabilir.

CustomerManager customerManager = new CustomerManager();
customerManager.Save();
Console.ReadLine();


interface ILogging
{
     void Log();
}
interface ICaching
{
     void Cache();
}
interface IAutorize
{
     void ChechUser();
}
interface IValidation
{
    void Validate();
}
class Logging:ILogging
{
    public void Log()
    {
        Console.WriteLine("Logged");
    }
}
class Caching:ICaching
{
    public void Cache()
    {
        Console.WriteLine("Cached");
    }
}
class Autorize:IAutorize
{
    public void ChechUser()
    {
        Console.WriteLine("User Checked ");
    }
}
class Validation : IValidation
{
    public void Validate()
    {
        Console.WriteLine("Validated");
    }
}
/*class CustomerManager 
{
// yazılan methodları iş katmanında kullanalım
// bu sekilde kullanmak yerine CrossCuttongConcersFasad kullanmak daha mantıklı.

    private ILogging _logging;
    private ICaching _caching;
    private IAutorize _autorize;

    public  CustomerManager (ILogging logging, ICaching caching, IAutorize ChechUser)
    {

        _logging = logging;
        _caching = caching;
        _autorize = ChechUser;

    }
    public void Save()
    {
        _logging.Log();
        _caching.Cache();
        _autorize.ChechUser();
        Console.WriteLine("Saved");
    }
}*/
class CustomerManager 
{
    private CrossCuttongConcersFasad _concerns;
    public CustomerManager() // constructor
    {
        _concerns = new CrossCuttongConcersFasad();// bu şekilde daha temiz kod yazmış olduk.
    }
    public void Save()
    {
        _concerns.Caching.Cache();
        _concerns.Logging.Log();
        _concerns.Autorize.ChechUser();
        _concerns.Validation.Validate();
        Console.WriteLine("Saved");
    }
}

class CrossCuttongConcersFasad // buraya bir şey eklediğimizde CustomerManagerde bir değişim olmayacak yani oraya tekrar invection yapmaya gerek kalmaaycak.
{
    public ILogging Logging;
    public ICaching Caching;
    public IAutorize Autorize;
    public IValidation Validation;

    public CrossCuttongConcersFasad() // bu bir constructor, yani class kullanıldığında ilk çalısacak olan kısım.
    {
        Logging = new Logging();
        Caching = new Caching();
        Autorize = new Autorize();
        Validation = new Validation();

    }
}