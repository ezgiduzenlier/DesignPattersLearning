//Farklı kişilere farklı şeyler göstermek istediğimizde kullanılır, örneğin çok ürün alan müşterilere indirim yapmak için kullanabiliriz. 

var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };
SpecialOffer specialOffer = new SpecialOffer(personalCar);
specialOffer.DiscountPercentage = 50;

Console.WriteLine("Special Offer: {0}", personalCar.HirePrice);
Console.WriteLine("Special Offer: {0}", specialOffer.HirePrice );
Console.ReadLine();




abstract class CarBase
{
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }
}
class PersonalCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}
class CommericalCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}
abstract class CarDecoratorBase : CarBase
{
    private CarBase _carBase;

    protected CarDecoratorBase(CarBase carBase)// burdaki carBase nerden geldi biz şuan mı oluşturduk? burda oluşturuluyor mu?
    {
        _carBase= carBase;
    }
}
class SpecialOffer : CarDecoratorBase
{//CarDecoratorBase bir consractora ihtiyaç duyduğu için, SpecialOffera hangi araç türü ile çalışıcaksak onu göndermiş oluyoruz.

    private readonly CarBase _carBase;
    public int DiscountPercentage { get; set; }

    public SpecialOffer(CarBase carBase) : base(carBase)
    {
        _carBase = carBase;
    }
    // bu değerleri set etmezsek SpecialOffer sonucu sıfır döner
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice
    { get { return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage/100; }
      set { }
    }
}