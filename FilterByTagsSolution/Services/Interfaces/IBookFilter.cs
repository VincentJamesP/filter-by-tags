using FilterByTags.Models;
using System.Data;

namespace FilterByTags.Services.Interfaces
{
    public interface IBookFilter
    {
        List<Book> Filter(DataTable books, List<string> filterTags);
    }
}
