using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Rusu_Maria_Smaranda_Proiect.Models;

namespace Rusu_Maria_Smaranda_Proiect.Data
{
    public class FilmsListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        
        public FilmsListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FilmList>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<ListCategory>().Wait();

        }

        public Task<List<FilmList>> GetFilmListsAsync()
        {
            return _database.Table<FilmList>().ToListAsync();
        }

        public Task<FilmList> GetFilmListAsync(int id)
        {
            return _database.Table<FilmList>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFilmListAsync(FilmList flist)
        {
            if(flist.ID != 0)
            {
                return _database.UpdateAsync(flist);
            }
            else
            {
                return _database.InsertAsync(flist);
            }
        }

        public Task<int> DeleteFilmListAsync(FilmList flist)
        {
            return _database.DeleteAsync(flist);
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            if (category.ID != 0)
            {
                return _database.UpdateAsync(category);
            }
            else
            {
                return _database.InsertAsync(category);
            }
        }

        public Task<int> DeleteCategoryAsync(Category category)
        {
            return _database.DeleteAsync(category);
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table < Category>().ToListAsync();
        }

        public Task<int> SaveListCategoryAsync(ListCategory listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<List<Category>> GetListCategoriesAsync(int filmlistid)
        {
            return _database.QueryAsync<Category>(
            "select C.ID, C.Description from Category C"
            + " inner join ListCategory LC"
            + " on C.ID = LC.CategoryID where LC.FilmListID = ?",
            filmlistid);
        }
    }
}
