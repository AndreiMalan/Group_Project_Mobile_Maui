using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Proiect_Mobile_Maui_Onetiu_Malan.Models;

namespace Proiect_Mobile_Maui_Onetiu_Malan.Data
{
    
    public class VisitingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public VisitingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CityList>().Wait();
        }
        public Task<List<CityList>> GetCityListsAsync()
        {
            return _database.Table<CityList>().ToListAsync();
        }
        public Task<CityList> GetCityListAsync(int id)
        {
            return _database.Table<CityList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveCityListAsync(CityList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteCityListAsync(CityList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
