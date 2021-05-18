using ciftcidenEve.Models;
using ciftcidenEve.ViewModels;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace ciftcidenEve
{
    public class CardService
    {
        //ASYNC olarak bir SQLite bağlantısı tanımlıyoruz, henüz boş.
        public SQLiteAsyncConnection db;
        public CardService()
        {
            db = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.
                AppDataDirectory, "card.db3"));
            db.CreateTableAsync<Product>().Wait();

        }

        //Lİst all products in card
        public List<Product> ListProducts()
        {
            List<Product> returnsfor = db.Table<Product>().ToListAsync().Result;
            return returnsfor;
        }
        public Product GetProduct(int id)
        {
            return db.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync().Result;
        }

        //Add new product to the card
        public void AddToCard(Product product)
        {
            db.InsertAsync(product);


        }
        //Remove a product from card
        public void RemoveFromCard(Product product)
        {
            db.DeleteAsync(product);
        }
    }
}