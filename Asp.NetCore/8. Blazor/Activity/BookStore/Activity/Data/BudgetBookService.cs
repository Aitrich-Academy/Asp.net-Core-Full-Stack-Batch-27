
namespace Activity.Data
{
    public class BudgetBookService
    {
        private static List<Entry> BookList = new List<Entry>();
        

        public async Task<bool> AddEntry(Entry newEntry)
        {
            BookList.Add(newEntry);
            return true;
        }

        public async Task<List<Entry>> GetAllEntries()
        {
            return BookList;
        }

    }
}
