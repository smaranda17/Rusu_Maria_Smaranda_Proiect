using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Rusu_Maria_Smaranda_Proiect.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        [OneToMany]
        public List<ListCategory> ListCategories { get; set; }
    }
}
