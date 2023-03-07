using BrewTracker.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewTracker.Database
{
    public class BrewDatabase
    {
        SQLiteAsyncConnection Database;

        public BrewDatabase()
        {

        }

        async Task Init() 
        { 
            if(Database != null)
            {
                return;
            }


            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<Brew>();
        }

        public async Task<List<Brew>> GetBrewsAsync()
        {
            await Init();
            return await Database.Table<Brew>().ToListAsync();
        }

        public async Task<List<Brew>> GetFermentingBrewsAsync()
        {
            await Init();
            return await Database.Table<Brew>().Where(b => b.BrewingState == BrewingState.Fermenting).ToListAsync();
        }

        public async Task<List<Brew>> GetFinishedBrewsAsync()
        {
            await Init();
            return await Database.Table<Brew>().Where(b => b.BrewingState == BrewingState.Done).ToListAsync();
        }

        public async Task<List<Brew>> GetBottledBrewsAsync()
        {
            await Init();
            return await Database.Table<Brew>().Where(b => b.BrewingState == BrewingState.Aging).ToListAsync();
        }

        public async Task<int> SaveBrewAsync(Brew brew)
        {
            await Init();

            if(brew.Id != 0)
            {
                return await Database.UpdateAsync(brew);
            }
            else
            {
                return await Database.InsertAsync(brew);
            }
        }

        public async Task<int> DelteBrewAsync(Brew brew)
        {
            await Init();
            return await Database.DeleteAsync(brew);
        }
    }
}
