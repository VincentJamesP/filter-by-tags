using FilterByTags.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByTags.Services.Interfaces
{
    public interface IBookProcessor
    {
        List<Book> Process(string filePath, string taglistPath = "", List<string>? tagLists = null);
    }
}
