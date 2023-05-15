// Belli şartlara göre devreye hangi nesneyi sokacağımızı söyler. Bu nesneler arasında hiyerarşik yapı olmak zorundadır.
// örneğin şirketteki takım lideri çalısanlara 100 tlye kadar harcama izni veriyor, 100 tlyi geçtiği zaman müdür yardımcısı onayı gerekiyor,
// 1000 tlyi geçtiğinde ise müdür onayı gerekiyor. böyle bir durumda kullanılır.


Manager manager = new Manager();
VicePresident vicePresident = new VicePresident();
President president = new President();

manager.SetSuccesor(vicePresident);
vicePresident.SetSuccesor(president);

Expense expense = new Expense {Detail="Training", Amount=1055};
manager.HandleExpense(expense);

Console.ReadLine();



public class Expense
{
    public string Detail { get; set; }
    public decimal Amount { get; set; }
}
public abstract class ExpenseHandlerBase// harcama onayını yapma süreci
{
    protected ExpenseHandlerBase Succesor;

    public abstract void HandleExpense(Expense expense);

    public void SetSuccesor(ExpenseHandlerBase succesor)
    {
        Succesor = succesor;
    }
}
class Manager : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount<=100)
        {
            Console.WriteLine("Manager handled the expense!");
        }
        else if (Succesor!=null)// Succesor(bir üst kişi yoksa)
        {
            Succesor.HandleExpense(expense);
        }
    }
}
class VicePresident : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 100 && expense.Amount <= 1000)
        {
            Console.WriteLine("Vice President handled the expense!");
        }
        else if (Succesor != null)// Succesor(bir üst kişi yoksa)
        {
            Succesor.HandleExpense(expense);
        }
    }
}
class President : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 1000 )
        {
            Console.WriteLine("President handled the expense!");
        }
    }
}