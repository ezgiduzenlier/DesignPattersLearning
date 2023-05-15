// Basit bir cacheleme mekanizması diyebiliriz.
// Bir işlem yaptığımızda ve bu işlemin sonucunu tekrar kullanmak istediğimizde nasıl hızlıca erismek için kullanılır.






//CreditBase manager = new CredictManagerProxy();
//Console.WriteLine(manager.Calculate());
//Console.WriteLine(manager.Calculate()); // normalde çalıştırdığımızda ikinci hesabı yaparkenki süre ilk süre ile aynı bu süreyi kısaltmak için proxy sınıfı kullanılır.
//Console.ReadLine();



abstract class CreditBase
{
    public abstract int Calculate();
}
class CreditManager:CreditBase
{
    public override int Calculate()
    {
        int result = 1;
        for (int i = 1; i < 5; i++)
        {
            result *= i;
            Thread.Sleep(1000); // her operasyonun arasında 1 sn beklesin.
        }
        return result; 
    }
}
class CredictManagerProxy : CreditBase
{
    private CredictManagerProxy _credictManager; //CredictManager in nesnesini mi _creditManager? neden normal değişkenlerden farklı yazılıyor.
    private int _cachedValue;
    public override int Calculate()
    {
        if (_credictManager==null) // ilk hesaplamada _credictManager null olduğu için ife girip hesaplamayı yapıcak.
        {
            _credictManager = new CredictManagerProxy ();
            _cachedValue = _credictManager.Calculate();
        }
        return _cachedValue;// sonrakilerde döngüye girmeden ilk hesaplamayı attığımız _cacheValue değişkenini döndürücek.
    }
}


public class PersonUserManager
{
    private IUserPerson userPerson1;
    public void kullanikullan()
    {
        Kullan kullan = new Kullan(new Person());
    }
}


public class Kullan
{
    private IUserPerson _userPerson ;

    public Kullan(IUserPerson userPerson)
    {
        _userPerson = userPerson;
    }

    public void insanmisininkullanimi()
    {
        _userPerson.Insanmisin();
    }
}


public interface IUserPerson
{
    bool Insanmisin();
}

public class Person : IUserPerson
{
    public bool Insanmisin()
    {
        throw new NotImplementedException();
    }

    public void Kadinmisin()
    {

    }
}

public class User : IUserPerson
{
    public bool Insanmisin()
    {
        throw new NotImplementedException();
    }


    public void Erkekmisin()
    {

    }
}