using ciftcidenEve.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ciftcidenEve
{
    public static class ProductService
    {
        //ASYNC olarak bir SQLite bağlantısı tanımlıyoruz, henüz boş.
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            //Init metodu ile veritabanı bağlanıtmızı kuruyoruz.
            //Ne zaman veritabanı ile çalışacak olsak, öncelikle bu metodu çağıracağız.
            if(db != null)
            {
                var path = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.db");
                db = new SQLiteAsyncConnection(path);
            }
            //Tablomuzu oluşturuyor, parametre olarak kendi itemimizi veriyoruz.
            await db.CreateTableAsync<ciftcidenEve.Models.Product>();
        }
        //Ürün ekleme metodu
        public static async Task AddProduct(string title, string description, Image image)
        {
            await Init();
            var product = new Product
            {
                Text = title,
                Description = description,
                Image = image
            };
            var id = await db.InsertAsync(product);
        }
        //Ürün çıkarma metodu
        public static async Task RemoveProduct(int id) 
        {
            await Init();
            await db.DeleteAsync<Product>(id);
        }
        //Ürün çağırma metodu
        public static async Task<IEnumerable<Product>> GetProduct()
        {
            await Init();
            var products = await db.Table<Product>().ToListAsync();
            return products;
        }
    }
   
}
