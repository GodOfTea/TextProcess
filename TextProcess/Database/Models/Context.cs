using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcess.Database.Models
{
   
    public class Context : DbContext
    {
        /* Строчка подключения к локальной БД */
        private static string _dbPath = "LocalConnection";

        public Context() : base(_dbPath) { }

        public DbSet<Dictionary> dictionary { get; set; }

    }
}
