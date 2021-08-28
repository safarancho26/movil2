using PM2E1201810060245.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E1201810060245.Data
{
    class UserDB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DataBase.DatabasePath, DataBase.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public UserDB()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(User).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(User)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        #region metodos login
        public IEnumerable<User> whereUser(string strEmail, string strPwd)
        {
            var result = Database.QueryAsync<User>("Select * from User Where email=? and password=?", strEmail, strPwd);

            return result.Result;
        }
        public bool InsertUser(string strEmail, string strPwd, string strName, string strPhone)
        {
            Database.QueryAsync<User>("INSERT INTO  User(email,name,password,phone) VALUES(?,?,?,?)", strEmail, strName, strPwd, strPhone);

            return true;
        }
        #endregion
    }
}