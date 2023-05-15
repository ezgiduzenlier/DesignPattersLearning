// Bağımlılıkların Dışarıdan Enjekte Edilmesidir.
// Bağımlılık oluşturacak nesneleri direkt olarak kullanmak yerine, bu nesneleri dışardan verilmesiyle sistem içerisindeki bağımlılığı minimize eder.
// Bileşenlerin(components) birbirine olan sıkı bağlarının gevşetilmesini(Loosely Coupled) ve yazılımın test edilebilir bir hale getirilmesini amaçlar.
// Yani, temel olarak oluşturacağınız bir sınıf içerisinde başka bir sınıfın nesnesini kullanacaksanız new anahtar sözcüğüyle oluşturmamanız gerektiğini söyleyen bir yaklaşımdır.
// Gereken nesnenin ya Constructor’dan ya da Setter metoduyla parametre olarak alınması gerektiğini vurgular.Böylece iki sınıfı birbirinden izole etmiş olduğumuzu savunur.



ProductManager productManager = new ProductManager(new NhProductDAL());
productManager.Save();


interface IProductDAL
{
    void Save();
}

class EfProductDAL:IProductDAL//product data access layer
{
    public void Save()
    {
        Console.WriteLine("Saved with EF");
    }
}

class NhProductDAL : IProductDAL//bunu sonrada ekledik managera dokunmadan sadece ihtiyazımıc olan kısmı yazdık.
{
    public void Save()
    {
        Console.WriteLine("Saved with NH");
    }
}

class ProductManager
{
    private IProductDAL _productDAL;

    public ProductManager(IProductDAL productDAL)//yani biz buraya hangi productDAL implementasyonu verirsek(en basta çalıstırdığımız kısımda) onunla çalışıcak.
    {
        _productDAL = productDAL;
    }

    public void Save()
    {
        _productDAL.Save();
    }
}