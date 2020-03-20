using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SQLite;
using VectorCompanion.Models;
using VectorCompanion.Services;


namespace VectorCompanion.Storage
{
    public class VectorDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public VectorDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async System.Threading.Tasks.Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Vector).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Vector)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public Task<List<Vector>> GetItemsAsync()
        {
            return Database.Table<Vector>().ToListAsync();
        }

        public Task<List<Vector>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Vector>("SELECT * FROM [Vector]");
        }

        public Task<Vector> GetItemAsync(string name)
        {
            return Database.Table<Vector>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Vector item)
        {
                return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Vector item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
