// kullanıcı editör gibi uygulmalara bir süre hafızaya alır geri alma durumun karşılık en son veritabanına gönderir.
// sipariş takip sistemi örneği.




StockManager stockManager = new StockManager();
BuyStock buyStock = new BuyStock(stockManager);
SellStock sellStock = new SellStock(stockManager);
StockController stockController = new StockController();
stockController.TakeOrder(buyStock);
stockController.TakeOrder(sellStock);
stockController.TakeOrder(buyStock);

stockController.PlaceOrders();
Console.ReadLine();


class StockManager
{
    private string _name = "Lapton";//private değişkenler altyazı ile yazılır.
    private int _quantity = 10;

    public void Buy()
    {
        Console.WriteLine("Stock : {0}, {1} bought!", _name, _quantity);
    }

    public void Sell()
    {
        Console.WriteLine("Stock : {0}, {1} sold!", _name, _quantity);
    }
}

interface IOrder//birden fazla komutumuz olacağı için önce base olarak olarak oluşturuyoruz.
    {
        void Execute();
    }


class BuyStock : IOrder
{
    private StockManager _stockManager;//komut kodunu yani buy ı kullanabilmek için StockManageri tutarız.

    public  BuyStock(StockManager stockManager)
    {
        _stockManager = stockManager;
    }
    public void Execute()
    {
        _stockManager.Buy();
    }
}

class SellStock : IOrder
{
    private StockManager _stockManager;//komut kodunu yani buy ı kullanabilmek için StockManageri tutarız.

    public SellStock(StockManager stockManager)
    {
        _stockManager = stockManager;
    }
    public void Execute()
    {
        _stockManager.Sell();
    }
}

class StockController//bir de bu stokları kontrol ettiğimiz bir yere ihtiyazımız var.
{
    List<IOrder> _orders = new List<IOrder>();//orderı hepsine implemente ettiğimiz için sadece onu kontrol etsek yeterli.

    public void TakeOrder(IOrder order)
    {
        _orders.Add(order);
    }
    public void PlaceOrders()// kullanıcı isterse işi bittiğinde komutları çalıştırması için 
    {
        foreach (var order in _orders)
        {
            order.Execute();// IOrder ile olan değişime göre BuyOrder veya SellOrder yapıcak.
        }
        _orders.Clear();
        }
}

