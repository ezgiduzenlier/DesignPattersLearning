/* 
* Ne zaman kullanılır ? Ağaç benzeri bir nesne yapısı uyarlamanız gerekiyorsa composite tasarım desenini kullanabilirsiniz.
* Kompleks Composite ağaçlar oluştururken Builder desenini kullanabilirsiniz. Böylece oluşturma (construction) aşamalarını öz yinelemeli (recursive) olarak belirleyebilirsiniz.
* Chain of Responsibility (Sorumluluk Zinciri) çoğu zaman Composite ile birlikte kullanılır. Böylece yaprak konumundaki bir bileşen istek aldığında zincir şeklinde tüm üst dallara ileterek ağacın en başına kadar iletilmesini sağlar.
* Composite ağaçlar arasında dolaşmak için Iterator kullanabilirsiniz.
* Composite ağacın tamamında bir operasyon çalıştırmak için Visitor kullanabilirsiniz.
* Hafızadan tasarruf sağlamak için Composite ağacın bazı yaprak düğümlerini Flyweight olarak tanımlayabilirsiniz.*/

using System.Collections;

Employee engin = new Employee { Name = "Engin Demiroğ" };
Employee salih = new Employee { Name = "Salih Demiroğ" };
Employee demir = new Employee { Name = "Demir Demiroğ" };
Employee deniz = new Employee { Name = "Deniz Demiroğ" };
Conctractor ali = new Conctractor { Name = "Ali Demiroğ" };

engin.AddSubordinates(salih);// engine alt çalışan olarak salihi ekledik 
engin.AddSubordinates(demir);// engine alt çalışan olarak demiri ekledik
demir.AddSubordinates(deniz);// demire alt çalışan olarak deniz ekledik
salih.AddSubordinates(ali); // sonradan oluşturduğumuz çalısanı denizin alt çalışanı ile ekledik.

Console.WriteLine(engin.Name);
foreach (Employee manager in engin )
{
    Console.WriteLine("  {0}",manager.Name);
    foreach (IPerson employee in manager) // IPerson içinde dön dedik çünkü conctrator ve employee yi kapsıyor
    {
        Console.WriteLine("     {0}",employee.Name);
    }
}
Console.ReadLine();




interface IPerson
{
    string Name { get; set; }
}

class Conctractor:IPerson // tedarikci sınıfı olusturalım bide sonra bunu çalışanlara ekleyelim.
{
    public string Name { get; set; }
}

class Employee : IPerson,IEnumerable<IPerson>// ağacın dallarına ulaşabilmek için IEnumerable kullandık. yani personlara (enumerable: liste içinde dönmemizi sağlar.)
{
    List<IPerson> _subordinates = new List<IPerson>(); // Hiyerarşik yapıyı için alt nesneler belirliyoruz.(subordinates: hiyerarşik yapıda alt sınıf anlamına geliyor.)

    public void AddSubordinates(IPerson person)
    {
        _subordinates.Add(person);
    }
    public void RemoveSubordinates(IPerson person)
    {
        _subordinates.Remove(person);
    }
    public IPerson GetSubordinates(int index)// person ın kaçıncı indexte olduğunu bulmak için.
    {
        return _subordinates[index];
    }

    public string Name { get ; set; }

    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach(var subordinates in _subordinates)
        {
            yield return subordinates; // yield tam anlamadım?
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
