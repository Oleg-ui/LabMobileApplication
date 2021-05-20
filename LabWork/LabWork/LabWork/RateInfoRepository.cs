using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LabWork
{
    public class RateInfoRepository
    {
        SQLiteConnection database;

        public RateInfoRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<RateInfoTable>();
        }

        public IEnumerable<RateInfoTable> GetItems()
        {
            return database.Table<RateInfoTable>().ToList();
        }

        public RateInfoTable GetItem(int id)
        {
            return database.Get<RateInfoTable>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<RateInfoTable>(id);
        }

        public int SaveItem(RateInfoTable item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
