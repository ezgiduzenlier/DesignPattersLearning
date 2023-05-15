// interface ile başlanır.(isimlendirmelere desenin önerdiği şekilde yaptım.)
// bir nesnenin drumunu belirlemek için kullanılır.
// örneğin müzik çalarda şarkıyı başlatmak durdurmak gibi.
// IState ve Contexti her durum yönetimi için kullabiliriz örn: ORM.



Context context = new Context();
ModifiedState modified = new ModifiedState();
modified.DoAction(context);// hangi contexti kullanacaksak onu giriyoruz.
DeletedState deleted = new DeletedState();
deleted.DoAction(context);
Console.WriteLine(context.GetSatate());//genelde context ne durumda diye bakarız biz.en son nerde kaldıysa onu döner bize.
//bu kodu kullanabilmek için this olarak belirtmeliyiz aşağıda.
Console.ReadLine(); 



interface IState
{
    void DoAction(Context context);// bütün stateler aynı contexten geçmeli.Şimdi aşağıdaki bu contextin classını oluşturalım 
}

class ModifiedState : IState
{
    public void DoAction(Context context)//burda context verdiğim için yukarda contexti çağırdım dimi?
    {
        Console.WriteLine("State : Modified");
        context.SetState(this);
    }
}

class DeletedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Deleted");
        context.SetState(this);
    }
}

class AddedState : IState
{
    public void DoAction(Context context)
    {
        Console.WriteLine("State : Added");
    }
}

class Context
{
    private IState _state;

    public void SetState(IState state)//contextin stateini set ettik.
    {
        _state = state;
    }
    public IState GetSatate()
    {
        return _state;
    }
}
