using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Rusu_Maria_Smaranda_Proiect.Models
{
     public class FilmList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }

        public string Year { get; set; }

    }
}
