using ciftcidenEve.Models;
using ciftcidenEve.Services;
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
                AppDataDirectory, "product.db3"));
            db.CreateTableAsync<Product>().Wait();
            CategoryService categoryService = new CategoryService();

            ////İlk ürünü otomatik eklesin diye bir örnek- bu yorum satırı sonradan
            ////kaldırılacağı için Türkçe yazıldı.
            //Product darari = new Product
            //{
            //    Id = 21,
            //    Text = "Yerli Domates Fidesiiii",
            //    Description = "10 adet",
            //    Price = 10,
            //    Tag ="Sebze",
            //    Satici = "Hilal Elif Mutlu"
            //    // Image
            //};
            //db.InsertAsync(darari);
        }
        //Get all porudcts
        public List<Product> GetProducts()
        {
            List<Product> returnsfor = db.Table<Product>().ToListAsync().Result;
            return returnsfor;
        }



        //get products by main categories
        public List<Product> GetProductsByTag(string tag)
        {
            List<Product> categoryProducts = db.Table<Product>().Where(i => i.Tag == tag).ToListAsync().Result;

            return categoryProducts;
        }



        //get products by sub-categories
        public List<Product> GetProductsBySubTag(string stag)
        {
            List<Product> categoryProducts = db.Table<Product>().Where(i => i.SubTag == stag).ToListAsync().Result;

            return categoryProducts;
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