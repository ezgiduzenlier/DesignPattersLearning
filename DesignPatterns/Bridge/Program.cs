

CustomerManager customerManager = new CustomerManager();// şuan newledik ama projelerde injection ile yapılır - bu açıklama ne demek?
customerManager.MessageSenderBase = new SmsSender();// MessageSenderBase i çalıştırdık ama abstract olduğu için ve base de olduğu için neyi çalıştırwacağımızı belli etmemiz gerekiyor.
customerManager.UpdateCustomer();
Console.ReadLine();

abstract class MessageSenderBase //farklı mesaj gönderme sınıflarında değişiklik yapacağı için abstaract yapmak mantıklı.
{// bu class bizim değişicek sınfımız.
    public void Save()
    {
        Console.WriteLine("Message saved!");
    }
    public abstract void Send(Body body);// send in yapacağı işlemi bridge(köprü) yöntemi ile bir nevi injection yaparak gerçekleştirelim.
}// Send kısmı değişecek olan kısım.
class Body
{
    public string Title { get; set; }
    public string Text { get; set; }

}
class SmsSender : MessageSenderBase//değişim seçeneklerinin implementasyonu
{
    public override void Send(Body body) // body burda yardımcı nesne. yardımcı nesnenin normal nesneden farkı?
    {
        Console.WriteLine("{0} it was sent via SmsSender.",body.Title);
    }
}
class EmailSender : MessageSenderBase//değişim seçeneklerinin implementasyonu
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} it was sent via EmailSender.",body.Title);
    }
}
class CustomerManager// yukardaki sınıflarımızı kullandığımız bir yer.
{// istediğimiz mesaj yöntemini seçmek için o sınıfı newlemek yerine bridge oluştururuz.

    public MessageSenderBase MessageSenderBase { get; set; }
    public void UpdateCustomer()
    {
        MessageSenderBase.Send(new Body {Title="About the course!"});
        Console.WriteLine("Customer updated!");
    }
}