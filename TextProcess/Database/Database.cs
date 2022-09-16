using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcess.Database.Models;

namespace TextProcess.Database
{
    public class Database
    {
        /* ищи меня в папке: "\TextProcess\bin\Debug\DB" */
        private string _databasePath = @".\DB\TextProcessDictionary.db";

        // string _connectionPath = "Data Source=TextProcessDictionary.db";

        private string _createTable = @"CREATE TABLE IF NOT EXISTS [Dictionary] (
        [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
        [Word] varchar(150) NOT NULL,
        [WordCount] integer NOT NULL);";

        private Context _context;

        public Database()
        {
            _context = new Context();
        }

        public void Connection()
        {
            if (!File.Exists(_databasePath))
                Create();
        }

        public void Read()
        {

        }

        public void Write()
        {
            var dic = new Dictionary();
            dic.word = "word";
            dic.wordCount = 15;

            /* все запросы на запись или чтение будут выглядеть примерно так */
            _context.dictionary.Add(dic);
            _context.SaveChanges();
        }

        public void Create()
        {
            string appPathDatabase = @".\DB";

            if (!Directory.Exists(appPathDatabase))
                Directory.CreateDirectory(appPathDatabase);

            SQLiteConnection.CreateFile(_databasePath);
            SQLiteConnection SQLConnection = new SQLiteConnection(string.Format("Data Source={0};", _databasePath));
            
            SQLiteCommand command = new SQLiteCommand();

            command.Connection = SQLConnection;
            SQLConnection.Open();

            SQLiteTransaction transaction = SQLConnection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.CommandText = _createTable;
                command.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Database: " + _databasePath + " created!");
                
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }

            SQLConnection.Close();


        }


    }
}
