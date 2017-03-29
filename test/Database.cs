using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace test
{
	public class Database
	{
		/// <summary>
		/// Komunikace s DB
		/// v <> zavorkách musí byt název ukládané clasi
		/// </summary>

		private SQLiteAsyncConnection database;

		public Database(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Osoba>().Wait();
		}

		public Task<List<Osoba>> GetItemsAsync()
		{
			return database.Table<Osoba>().ToListAsync();
		}

		public Task<List<Osoba>> GetItemsNotDoneAsync(string predmet)
		{
			return database.QueryAsync<Osoba>("SELECT * FROM [Znamky.db3] WHERE [Predmet] = " + predmet);
		}

		public Task<Osoba> GetItemAsync(int id)
		{
			return database.Table<Osoba>().Where(i => i.ID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(Osoba item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else
			{
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(Osoba item)
		{
			return database.DeleteAsync(item);
		}

		public Task<List<Osoba>> GetListViewAsync()
		{
			return database.Table<Osoba>().ToListAsync();
		}

	}
}
