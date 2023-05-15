// Eve gelip bize yardım eden misafir gibi düşünebilirsin. Evin üyesi değildir gelir yardım eder ve gider.Yani yardımını istediğimiz claasa
// bunu inject ederiz. Inject olduğu süre boyunca onun fonksiyonelliğini kullanabiliriz. Baska visitoru inject ettiğimizde eskisinin hükmü kalmaz.
// örneğin bütün personelin maasına hiyerarşik olarak zam yapmak.


Manager ezgi = new Manager { Name="Ezgi",Salary=40000};
Manager ece = new Manager { Name="Ece",Salary=20000};

Worker elif = new Worker { Name="Elif",Salary=12000};
Worker ecrin = new Worker { Name="Ecrin",Salary=10000};

ezgi.Subordinates.Add(ece);
ece.Subordinates.Add(elif);
ece.Subordinates.Add(ecrin);

OrganisationalSturture organisationalSturture = new OrganisationalSturture(ezgi);//ezgi başlayacağı kişi
PayRollVisitor payRollVisitor = new PayRollVisitor();
PayRiseVisitor payRiseVisitor = new PayRiseVisitor();

organisationalSturture.Accept(payRollVisitor);
organisationalSturture.Accept(payRiseVisitor);
Console.ReadLine();


class OrganisationalSturture
{
    public EmployeeBase Employee;//publicde büyük harf kullanılır.

    public OrganisationalSturture(EmployeeBase firstEmployee)//hiyerarşinin her hangi bir yerinden başlayıo ödeme yapmak için.
    {
        Employee = firstEmployee;
    }
    public void Accept(VisitorBase visitor)//ziyaret işlemini kabul eden method
    {
        Employee.Accept(visitor);
    }

}

abstract class EmployeeBase
{
    public abstract void Accept(VisitorBase visitor);
    public string? Name { get; set; }
    public decimal Salary { get; set; }
}

class Manager : EmployeeBase
{
    public Manager()
    {
        Subordinates = new List<EmployeeBase>();//bu şekilde newlemezsek subordinates çalışmaz.çünkü kendi basına anlamı yoktur.
    }

    public List<EmployeeBase> Subordinates { get; set; }//Managerin altındada managerlar veya workerlar olabilir o yüzden subordinates (hiyerarşi) kullandık.
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);


        foreach (var employee in Subordinates)//visitoru kabul etmeleri için listteki tüm subordinatesleri managerdan başlayıp gezicek.
        {
            employee.Accept(visitor);
        }
    }
}

class Worker : EmployeeBase
{
    public override void Accept(VisitorBase visitor)
    {
        visitor.Visit(this);
    }
}

abstract class VisitorBase//tüm personel için yada bi kısım için ödeme yapıcak olan kısım.
{
    public abstract void Visit(Worker worker);//iki farklı Visit olusturduğumuz için worker içinde manager içinde this olarak belirtmemiz gerekiyor yok
    public abstract void Visit(Manager manager);//yoksa hangisi olduğunu anlamaz.
}

class PayRollVisitor : VisitorBase//visit operasyonunu gerceklestiricek kısım. 
{
    public override void Visit(Worker worker)
    {
        Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
    }

    public override void Visit(Manager manager)
    {
        Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);

    }
}

class PayRiseVisitor : VisitorBase// örneğin workera ayrı managera ayrı zam yapmak istedik.
{
    public override void Visit(Worker worker)
    {
        Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
    }

    public override void Visit(Manager manager)
    {
        Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
    }
}