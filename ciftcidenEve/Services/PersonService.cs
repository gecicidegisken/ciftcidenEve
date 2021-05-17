using System;
using System.Collections.Generic;
using System.Text;
using ciftcidenEve.Models;
using SQLite;
using System.IO;
using System.Linq;


namespace ciftcidenEve.Services
{
  public class PersonService
    {
        
        public SQLiteAsyncConnection memberDB;
      

        public PersonService()
        {
            memberDB = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.
            AppDataDirectory, "members.db3"));
            memberDB.CreateTableAsync<Person>().Wait();
         

        }

        //Add new member
        public void Add(Person member)
        {
            memberDB.InsertAsync(member);
            
        }

        public List<Person> GetMembers()
        {
            List<Person> returnsfor = memberDB.Table<Person>().ToListAsync().Result;
            return returnsfor;
        }
       

        //kayıt olurken aynı adresle başka üye olup olmadığının kontrolü
        public bool IsEmailUsed(string email)
        {
          
           var results= memberDB.Table<Person>().Where(person => person.Email==email);

            return (results.CountAsync().Result > 0);
        }

        public bool MemberLogin(string email, string password)
        {

            var results = memberDB.Table<Person>().Where(p => p.Email == email && p.Password == password);

            if (results.CountAsync().Result > 0)
            {
                App.currentUser = results.ElementAtAsync(0).Result;
                return true;
               
            }
            
            return false;
        }

      
    }
}

