using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Mobile_Maui_Onetiu_Malan.Models
{
    public class CityList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(typeof(City))]
        public int CityID { get; set; }

    }
}
