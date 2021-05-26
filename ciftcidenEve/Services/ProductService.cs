using ciftcidenEve.Models;
using ciftcidenEve.Services;
using SQLite;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

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

        }


        //Get all porudcts
        public List<Product> GetProducts()
        {
            List<Product> returnsfor = db.Table<Product>().ToListAsync().Result;
            return returnsfor;
        }


        //Get products by main categories
        public List<Product> GetProductsByTag(string tag)
        {
            List<Product> categoryProducts = db.Table<Product>().Where(i => i.Tag == tag).ToListAsync().Result;

            return categoryProducts;
        }



        //Get products by sub-categories
        public List<Product> GetProductsBySubTag(string stag)
        {
            List<Product> categoryProducts = db.Table<Product>().Where(i => i.SubTag == stag).ToListAsync().Result;

            return categoryProducts;
        }

        //Get products by City
        public List<Product> GetProductsByCity(string city)
        {
            List<Product> filterProducts = db.Table<Product>().Where(i => i.City == city).ToListAsync().Result;

            return filterProducts;
        }
        //Get products by Seller
        public List<Product> GetProductsBySeller(string seller)
        {
            List<Product> filterProducts = db.Table<Product>().Where(i => i.Satici == seller).ToListAsync().Result;

            return filterProducts;
        }

        //Get products by Price
        public List<Product> GetProductsByPrice(float price)
        {
            var x = price + 10.0;
            List<Product> filterProducts = db.Table<Product>().Where(i => i.Price >= price && i.Price <= x).ToListAsync().Result;

            return filterProducts;
        }

        public List<Product> GetProductsBySearch(string keyw)
        {
            List<Product> getProducts = db.Table<Product>().Where(i => i.Text.ToLower().Contains(keyw.ToLower()) || keyw.ToLower().Contains(i.Text.ToLower())).ToListAsync().Result;
            return getProducts;
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

        public void AddDefaultProducts()
        {
            List<Product> defaultUrunler = new List<Product>();
            CategoryService cs = new CategoryService();

            Product aciBiber = new Product("Acı Biber", "Bir kilo acı biber gönderilecektir. Yüzde yüz doğaldır.", "Yeşil Çiftlik", 3, "Sebze", "Biber", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fkirmizibiber.jpeg?alt=media&token=3b236881-a4da-4c5e-8117-2d194224840c"));
            defaultUrunler.Add(aciBiber);

            Product avokado = new Product("Avokado", "Tane fiyatıdır.", "Arif Karaçalıoğlu", 5, "Meyve", "Avokado", "Adana", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Favokado.jpeg?alt=media&token=f4abd8d2-22de-4883-a98f-f86bb7b6cf2f"));
            defaultUrunler.Add(avokado);

            Product bal = new Product("Doğal Çam Balı", "500 gr. \n%100 doğal.", "Hilal Elif Mutlu", 50, "Kahvaltılık", "Bal", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fbal.jpeg?alt=media&token=6a6abffd-72da-4c84-9207-f3a3e9f9de08"));
            defaultUrunler.Add(bal);

            Product bogurtlenReceli = new Product("Böğürtlen Reçeli", "500 gr \nEv yapımıdır.", "Hilal Elif Mutlu", 20, "Kahvaltılık", "Reçel", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Frecel.jpeg?alt=media&token=a8b16277-7d26-4d59-acf3-1e2b1f759078"));
            defaultUrunler.Add(bogurtlenReceli);

            Product cilek = new Product("Çilek", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 15, "Meyve", "Çilek", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fcilek.jpeg?alt=media&token=eb92d888-ad04-44c8-864b-2483e2d97004"));
            defaultUrunler.Add(cilek);

            Product cilekReceli = new Product("Çilek Reçeli", "500 gr\nEv yapımıdır.", "Hilal Elif Mutlu", 20, "Kahvaltılık", "Reçel", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fcilekreceli.jpeg?alt=media&token=24c7d68e-07b8-4cf3-bdf8-2205d7711768"));
            defaultUrunler.Add(cilekReceli);

            Product dolmalikBiber = new Product("Dolmalık Biber", "Bir kilogram dolmalık biber gönderilecektir.\nYüzde yüz doğaldır.", "Yeşil Çiftlik", 7, "Sebze", "Biber", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fdolmal%C4%B1kbiberikirenk.jpeg?alt=media&token=38db5a2d-8c0a-4615-8d8f-78834bcb91c4"));
            defaultUrunler.Add(dolmalikBiber);

            Product domates = new Product("Domates", "Bir kilo domates gönderilecektir. Yüzde yüz doğaldır.", "Yeşil Çiftlik", 5, "Sebze", "Domates", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fdomates.jpeg?alt=media&token=560447c9-f5f9-4fbb-9ab7-03f297e8ff53"));
            defaultUrunler.Add(domates);

            Product domatesFidani = new Product("Domates Fidesi", "Bir adet dikime hazır domates fidanı.", "Arif Karaçalıoğlu", 10, "Çiçek, Fidan, Tohum", "Sebze Fidanı", "Adana", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Feldefidan.jpeg?alt=media&token=b03f674b-98af-4b7d-a184-32f8d5509b8a"));
            defaultUrunler.Add(domatesFidani);

            Product domatesFidani2 = new Product("Domates Fidesi", "Bir adet domates fidesi", "Hilal Elif Mutlu", 15, "Çiçek, Fidan, Tohum", "Sebze Fidanı", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Ffidan1.jpeg?alt=media&token=94dbe4d7-aec6-4685-a9c5-8e03b134a4de"));
            defaultUrunler.Add(domatesFidani2);

            Product elmaFidani = new Product("Elma Fidanı", "Bir adet orta büyüklükte elma fidanı", "Hilal Elif Mutlu", 15, "Çiçek, Fidan, Tohum", "Meyve Fidanı", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Ffidan2.jpeg?alt=media&token=2d6c24d1-ff18-4ef5-a65a-804b4774972e"));
            defaultUrunler.Add(elmaFidani);

            Product havuc = new Product("Havuç", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 3, "Sebze", "Havuç", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fhavuc.jpeg?alt=media&token=c5ef5af2-19d1-4281-af9d-8e046a2effa4"));
            defaultUrunler.Add(havuc);

            Product kahve = new Product("Kahve Çekirdeği", "100 gram çekilmemiş kahve çekirdeği.\n 100% doğaldır.", "Hilal Elif Mutlu", 15, "Sağlıklı İçecek", "Kahve", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fkahve.jpeg?alt=media&token=f97bc380-ab1f-40c9-8abc-518c8d4cf09d"));
            defaultUrunler.Add(kahve);

            Product bitkiCayi = new Product("Karışık Bitki Çayı", "300 gram karışık bitki çayı.\n 100% doğaldır. \n İçindekiler: Melisa, Roybos, Mayıs Papatyası, Portakal Yaprağı, Tarçın", "Hilal Elif Mutlu", 15, "Sağlıklı İçecek", "Çay", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fbaharatlar.jpeg?alt=media&token=67598d40-5a2a-4133-bd2d-8356418c9e34"));
            defaultUrunler.Add(bitkiCayi);

            Product karisikTohum = new Product("Karışık Çiçek Tohumları", "Bahçenize ekebileceğiniz karışık çiçek tohumları.", "Yeşil Çiftlik", 10, "Çiçek, Fidan, Tohum", "Meyve Tohumu", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fkasikbaharat.jpeg?alt=media&token=6e5c49a1-e6f4-4609-a160-6c639e54acb7"));
            defaultUrunler.Add(karisikTohum);

            Product kirmiziElma = new Product("Kırmızı Elma", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 3, "Meyve", "Elma", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fkirmizielma.jpeg?alt=media&token=8dba3525-4c68-41e2-b912-3f3ab7cd8b89"));
            defaultUrunler.Add(kirmiziElma);

            Product yesilElma = new Product("Yeşil Elma", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 3, "Meyve", "Elma", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fyesilelma.jpeg?alt=media&token=f4716c66-d55f-4eb2-8ee7-6949497dd894"));
            defaultUrunler.Add(yesilElma);

            Product mandalina = new Product("Mandalina", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 5, "Meyve", "Mandalina", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fportakal.jpeg?alt=media&token=d21942cf-80f8-4a48-9c07-092728387b7a"));
            defaultUrunler.Add(mandalina);

            Product uzum = new Product("Üzüm", "1 kilogram çekirdeksiz üzüm fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 8, "Meyve", "Üzüm", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fuzum.jpeg?alt=media&token=3deaa7ea-0667-4283-a3c9-9cddfff91fae"));
            defaultUrunler.Add(uzum);

            Product papatyaCayi = new Product("Papatya Çayı", "Bir kutuda 20 paket papatya çayı bulunur.\n 100% doğaldır.", "Hilal Elif Mutlu", 7, "Sağlıklı İçecek", "Çay", "Yalova", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fposetcay.jpeg?alt=media&token=b25b72df-48c1-4b92-9342-a1c794d90eac"));
            defaultUrunler.Add(papatyaCayi);

            Product patlican = new Product("Patlıcan", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 5, "Sebze", "Patlıcan", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fpatlican.jpeg?alt=media&token=a1a3829e-7317-426f-b339-a460d2cc263f"));
            defaultUrunler.Add(patlican);

            Product salatalik = new Product("Taze Salatalık", "1 kilogram fiyatıdır.\nÜrünlerimiz tamamen doğaldır ve taze gönderilir.", "Ahmet Dede'nin Manavı", 5, "Sebze", "Salatalık", "İstanbul", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fkabak.jpeg?alt=media&token=58200492-01db-49de-a6ce-09af6158d710"));
            defaultUrunler.Add(salatalik);

            Product peynir = new Product("Taze peynir", " Yüzde yüz doğaldır.", "Yeşil Çiftlik", 30, "Kahvaltılık", "Peynir", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fpeynir.jpeg?alt=media&token=b08c8b1d-451c-436e-9d32-c3ddaaa8627a"));
            defaultUrunler.Add(peynir);

            Product salgamSuyu = new Product("Şalgam Suyu", "Bir porsiyon 250 ml'dir. \nYüzde yüz doğal ev yapımıdır.", "Arif Karaçalıoğlu", 3, "Sağlıklı İçecek", "Şalgam Suyu", "Adana", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Felderecel.jpeg?alt=media&token=0d39744c-4537-493c-ac53-6ece677833f5"));
            defaultUrunler.Add(salgamSuyu);

            Product smoothie = new Product("Smoothie", "Çilekli smoothie.\nYüzde yüz doğaldır.\nBir porsiyon 300 ml.", "Yeşil Çiftlik", 12, "Sağlıklı İçecek", "Meyve Suyu", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fs%C3%BCrahiliicecek.jpeg?alt=media&token=5016eee7-46d5-4879-a4b2-4039dd1a9fef"));
            defaultUrunler.Add(smoothie);

            Product sut = new Product("Günlük İnek Sütü", "Yüzde yüz doğaldır.\n Bir litre fiyatıdır.", "Yeşil Çiftlik", 5, "Sağlıklı İçecek", "Süt", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fayran.jpeg?alt=media&token=4c169758-1834-4873-b83d-5c3e35cd4636"));
            defaultUrunler.Add(sut);

            Product yumurta = new Product("Günlük Yumurta", "Yüzde yüz doğaldır.\n 5 adet fiyatıdır.", "Yeşil Çiftlik", 5, "Kahvaltılık", "Yumurta", "Bursa", new Uri("https://firebasestorage.googleapis.com/v0/b/ciftcideneve-6894d.appspot.com/o/Images%2Fyumurta.jpeg?alt=media&token=78988ac5-417e-4a4d-99ce-37b22edfe477"));
            defaultUrunler.Add(yumurta);

            foreach (var item in defaultUrunler)
            {
                Add(item);
            }

        }

    }


}