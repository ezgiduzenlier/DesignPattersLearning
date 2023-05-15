// Singletonda bir nesneden sadece bir kere üretildiği garanti edilirdi.Multitonda ise belli şartlara göre instance üretilip
// o şartlara göre üretilmesidir. Belli şarta uyan aynı instancelara gidiyoruz.



Camera camera1 = Camera.GetCamera("NIKON");
Camera camera2 = Camera.GetCamera("NIKON");
Camera camera3 = Camera.GetCamera("CANON");
Camera camera4 = Camera.GetCamera("CANON");

Console.WriteLine(camera1.Id);
Console.WriteLine(camera2.Id);
Console.WriteLine(camera3.Id);
Console.WriteLine(camera4.Id);


class Camera
{//kameraları markalarına göre tutan bir liste yaptık.

    static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
    static object _lock=new object();
    public Guid Id { get; set; }
    string brand;

    private Camera()
    {
        Id = Guid.NewGuid();//aynı markalar için aynı instnce üretildiğini görmek için.
    }
    public static Camera GetCamera(string brand)
    {
        lock (_lock)
        {
            if (!_cameras.ContainsKey(brand))//liste içinde benim gönderidğim markanın instance ı yoksa
            {
                _cameras.Add(brand, new Camera());//onu listeye ekle 
            }
        }
        return _cameras[brand];
    }

}