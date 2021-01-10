using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Rusu_Maria_Smaranda_Proiect.Models
{
    public class ListCategory
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(FilmList))]
        public int FilmListID { get; set; }

        public int CategoryID { get; set; }
    }
}
