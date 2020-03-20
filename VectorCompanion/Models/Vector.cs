using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using VectorCompanion.Storage;

namespace VectorCompanion.Models
{
    public class Vector
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        private static VectorDatabase database;
        private static VectorDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new VectorDatabase();
                }
                return database;
            }
        }
        public Task<List<Vector>> ListVector {
            get
            {
                return database.GetItemsAsync();
            }
        }
    }
}
