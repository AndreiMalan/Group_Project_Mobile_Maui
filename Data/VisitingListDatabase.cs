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
            _database.CreateTableAsync<Destination>().Wait();
            _database.CreateTableAsync<ListDestination>().Wait();
            _database.CreateTableAsync<City>().Wait();
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
        public Task<int> SaveProductAsync(Destination destination)
        {
            if (destination.ID != 0)
            {
                return _database.UpdateAsync(destination);
            }
            else
            {
                return _database.InsertAsync(destination);
            }
        }
        public Task<int> DeleteProductAsync(Destination product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Destination>> GetProductsAsync()
        {
            return _database.Table<Destination>().ToListAsync();
        }
        public Task<int> SaveListDestinationAsync(ListDestination listd)
        {
            if (listd.ID != 0)
            {
                return _database.UpdateAsync(listd);
            }
            else
            {
                return _database.InsertAsync(listd);
            }
        }
        public Task<List<Destination>> GetListDestinationsAsync(int citylistid)
        {
            return _database.QueryAsync<Destination>(
            "select D.ID, D.Description from Destination D"
            + " inner join ListDestination LD"
            + " on D.ID = LD.DestinationID where LD.CityListID = ?",
            citylistid);
        }
        public Task<List<City>> GetCitiesAsync()
        {
            return _database.Table<City>().ToListAsync();
        }
        public Task<int> SaveCityAsync(City city)
        {
            if (city.ID != 0)
            {
                return _database.UpdateAsync(city);
            }
            else
            {
                return _database.InsertAsync(city);
            }
        }

    }
}
