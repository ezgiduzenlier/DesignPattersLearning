// Bir nesne örneği kullanmayı hedefler. Bu nesne örneği birbiri arkasına atılacak adımların sırasıyla işlenmesi sonucunda ortaya çıkar.
// if if kullanmak yerine ilgili üreticiye enjekte edilip nesne üreterek kullanılır.

using System.Reflection;

ProductDirector productDirector = new ProductDirector();
var builder = new NewCustomerProductBuilder(); // yeni kullanıcının görmesi gereken kısımları getiricek, eski kullanıcı için istersek sadece bu kısmı değiştiricez.
productDirector.GenerateProduct(builder);
var model = builder.GetModel();

Console.WriteLine(model.Id);
Console.WriteLine(model.CategoryName);
Console.WriteLine(model.DiscountApplied);
Console.WriteLine(model.Discounted);
Console.WriteLine(model.UnitPrice);

// yukardaki kısmı en son yazdım


class ProductViewModel
{
    public int Id { get; set; }
    public string? CategoryName { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discounted { get; set; }
    public bool DiscountApplied { get; set; }
}
abstract class ProductBuilder
{
    public abstract void GetProductData();
    public abstract void ApplyDiscount();
    public abstract ProductViewModel GetModel();
}

class NewCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();

    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;
    }

    public override void ApplyDiscount()
    {
        model.Discounted = model.UnitPrice*(decimal)0.50; // UnitPrice ı bir önceki kısımdan dolayı 20 aldı. 
        model.DiscountApplied = true;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }
}

class OldCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();

    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;
    }

    public override void ApplyDiscount()
    {
        model.Discounted = model.UnitPrice; 
        model.DiscountApplied = false;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }// artık ihtiyacımız olan tek şey bu productı üretmek bunun için direktor.
}

class ProductDirector
{
    public void GenerateProduct(ProductBuilder productBuilder)
    {
        productBuilder.GetProductData();
        productBuilder.ApplyDiscount();
    }
}