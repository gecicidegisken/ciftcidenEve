using ciftcidenEve.Models;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ciftcidenEve
{
    public class ProductService 
    {
        //ASYNC olarak bir SQLite bağlantısı tanımlıyoruz, henüz boş.
        public SQLiteAsyncConnection db;
       
        public ProductService()
        {
            db = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.
                AppDataDirectory, "producttt.db3"));
            db.CreateTableAsync<Product>().Wait();

            //İlk ürünü otomatik eklesin diye bir örnek- bu yorum satırı sonradan
            //kaldırılacağı için Türkçe yazıldı.
            Product darari = new Product
            {
                Id = 21,
                Text = "Yerli Domates Fidesiiii",
                Description = "10 adet",
                Price = 10,
                Tag = "Sebze",
                Satici = "Hilal Elif Mutlu"
               // Image
            };
            db.InsertAsync(darari);
        }
        //Get all porudcts
        public List<Product> GetProducts()
        {
            List<Product> returnsfor = db.Table<Product>().ToListAsync().Result;
            return returnsfor;
        }
        //Get a spesific product
        public Task<Product> GetProduct(int id)
        {
            return db.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        //Add new product
        public void Add(Product product)
        {
            db.InsertAsync(product);
        }
        //Delete a product
        public void Delete(Product product)
        {
            db.DeleteAsync(product);
        }
    }
}