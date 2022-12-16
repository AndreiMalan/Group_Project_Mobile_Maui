using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Mobile_Maui_Onetiu_Malan.Models
{
    public class ListDestination
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(CityList))]
        public int CityListID { get; set; }
        public int DestinationID { get; set; }
    }
}
