

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
            
        }
    }


    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();//henüz oluşmamış nesne için iki kullanıcı aynı anda istekte bulunursa
                                                 //o nesneden iki tane oluşur, o durumun önüne geçmek için lock kullanılır.

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }

}