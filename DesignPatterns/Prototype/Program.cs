// Prototype deseninde amaç klonlamadır,kod tekrarını önlemek ve nesnelerin bellekte daha az yer kaplaması için kullanılır.
// kaynağın ortak kullanımı da diyebiliriz. 
// (genel) Bir nesne inheritance veya implementasyon görmüyorsa bize ilerde nesnellik zaafiyeti yaşatır.


Customer customer1 = new Customer { FirstName="Ezgi", LastName = "Düzenlier", City= "İstanbul", Id = 1};
Customer customer2 = (Customer)customer1.Clone();
customer2.FirstName = "Mahmut";
Console.WriteLine(customer1.FirstName);
Console.WriteLine(customer2.FirstName);
Console.ReadLine();

public abstract class Person
{
    public abstract Person Clone(); // temel nesneyi prototype haline gelmesi için soyut bir clone methodundan beslenmesi gerekiyor.
    public int Id { get; set; }
    public string ?FirstName { get; set; }
    public string? LastName { get; set; }
}
public class Customer : Person
{
    public string? City { get; set; }

    public override Person Clone()
    {
        return(Person) MemberwiseClone();
    }
}

public class Employee : Person
{
    public decimal salary { get; set; }

    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}

