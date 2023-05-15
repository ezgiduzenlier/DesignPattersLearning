// Kullanıcıların yaptıkları değişikliklikleri geri alabilmelerini sağlamak için kullanılıyor.
// Bu desen nesnenin durum kopyasını memento adı verilen özel bir nesnede saklamayı öneriyor.
// isimlendirmeler desenin klasik isimlendirmeleri.


Book book = new Book
{
    Title = "Sefiller",
    Author="Victor Hugo",
    ISBN="12345"
};

book.ShowBook();
CareTaker history = new CareTaker();// kullanıcı daha değiştirmeye başlamadan hafızayı çekiyoruz.
history.Memento = book.CreateUndo();// burda da bir yedeğini oluşturuyoruz.

book.ISBN = "54321";

book.ShowBook();
book.RestoreFromUndo(history);//eski haline getirdik.
book.ShowBook();

Console.ReadLine();

class Book
{
    private string _title; // recharper ne? prob yazım teknikleri. yükle?
    private string _author;
    private string _isbn;
    private DateTime _lastEdited;

    public string Title
    {
        get { return _title; }// değeri okuma
        set
        {// yazma,değiştirme. geri alma işlemi yapacağımız için bu kısma ihtiyacımız var.
            _title = value;
            SetLastEdited();//nesnenin değiştirğini ispat edicek bu kısım
        }

    }
    public string Author
    {
        get { return _author; }
        set
        {
            _author = value;
            SetLastEdited();
        }
    }
    public string ISBN
    {
        get { return _isbn; }
        set
        {
            _isbn = value;
            SetLastEdited();
        }
    }
    private void SetLastEdited()
    {
        _lastEdited = DateTime.UtcNow;
        SetLastEdited();
    }
    public Memento CreateUndo()//nesnenin son hali
    {
        return new Memento(_title, _author, _isbn, _lastEdited); 
    }
    public void RestoreFromUndo(Memento memento)// istediğimiz zaman geri dönebilmek için parametre olarak hafızayı göndericez.
    {
        _title = memento.Title;
        _author = memento.Author;
        _isbn = memento.ISBN;
        _lastEdited = memento.LastEdited;
    }
    public void ShowBook()
    {
        Console.WriteLine("{0},{1},{2} edited : {3}", Title, Author, ISBN, _lastEdited); ;
    }
    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)//hafızaya bu değeleri gönderiyoruz.
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            LastEdited = lastEdited;
        }
    }
    class CareTaker// yukarıdaki hafızayı döndürücek olan kısım. Buraya neden ihtiyaç duyduk anlamadım?
    {
        public Memento Memento { get; set; }
    }
}