// bir strateji belirleyip o stratejiye göre methodun çalışma sürecidir.
// örneğin kişi 2010dan önce bankamızın müşterisi ise farklı kredi hesaplama,
// 2010dan sonra ise farklı kredi hesaplama sürecinden geçirme işlemi bu desen ile yapılır.
// if ler ile çalışmak yerine (kod karmaşasını engellemek için) tercih edilir.


CustomerManager customerManager = new CustomerManager();
customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
customerManager.SaveCredit();
Console.ReadLine();



abstract class CreditCalculatorBase
{
    public abstract void Calculator();
}
class Before2010CreditCalculator : CreditCalculatorBase
{
    public override void Calculator()
    {
        Console.WriteLine("CreditCalculator using Before 2010");
    }
}

class After2010CreditCalculator : CreditCalculatorBase
{
    public override void Calculator()
    {
        Console.WriteLine("CreditCalculator using After 2010");

    }
}
class CustomerManager
{
    // prop yerine injection ile de bu kısım yapılabilir.
    public CreditCalculatorBase CreditCalculatorBase { get; set; }// main kısmına bu kısmın örneğini yazmayı unutma ! yani before mu after mi ona karar ver ve newle.
    public void SaveCredit()
    {
        Console.WriteLine("Customer manager business");
        CreditCalculatorBase.Calculator();
    }
}