using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PM2E1201810060245.Data
{
    class DataBase
    {
        public const string DatabaseFilename = "UserSQLite.db3";

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite | // open the database in read/write mode
            SQLiteOpenFlags.Create |    // create the database if it doesn't exist
            SQLiteOpenFlags.SharedCache;// enable multi-threaded database access

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

    }
}