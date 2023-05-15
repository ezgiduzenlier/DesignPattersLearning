// observer : ilgilendiğimiz nesnenin durumu ile ilgili haber veren yayıncıdır.
// örneğin ürünün fiyatı düştüğünde müşteriyi bilgilendirmek için kullanabiliz.



ProductManager productManager = new ProductManager();
productManager.Attach(new CustomerObserver()); // CustomerObserver bilgilendirildi
productManager.UpdatedPrice();






class ProductManager
{
    // ProductManager'a abone olan kişileri liste şeklinde tutucaz.
    List<Observer> _observers = new List<Observer>();

    public void UpdatedPrice()
    {
        Console.WriteLine("Product price is changed!");
        Notify(); // üründeki değişimi abone varsa abonelere bilgilendirme göndermis olduk.
    }
    public void Attach(Observer observer)//listeye yeni observer eklediğimiz kısım  // içindeki nesneyi şuan ürettik değil mi? normal üretmekten farkı ne?
    {
        _observers.Add(observer);
    }
    public void Detach(Observer observer)//listeden gözlemciyi çıkardığımız kısım yani abobeliği bitirme.
    { 
        _observers.Remove(observer);
    }
    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(); // güncellendi bilgisi vermek için 
        }
    }
}
abstract class Observer
{
    public abstract void Update();
}
class CustomerObserver : Observer // istediğimiz kadar observer kullanabiliriz.
{
    public override void Update()
    {
        Console.WriteLine("Message to customer : product price is changed!");
    }
}
class EmployeeObserver : Observer // istediğimiz kadar observer kullanabiliriz.
{
    public override void Update()
    {
        Console.WriteLine("Employee to customer : product price is changed!");
    }
}