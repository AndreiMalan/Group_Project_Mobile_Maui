using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLiteNetExtensions.Attributes;

namespace Proiect_Mobile_Maui_Onetiu_Malan.Models
{
    public class City
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string CityDetails
        {
            get
            {
                return CityName + " "+Country;} 
        }
        [OneToMany]
        public List<CityList> ShopLists { get; set; }
    }
}
