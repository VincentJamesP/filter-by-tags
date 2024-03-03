using FilterByTags.Models;
using FilterByTags.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FilterByTags.Services
{
    internal class BookFilter : IBookFilter
    {
        public BookFilter() { }

        public List<Book> Filter(DataTable books, List<string> filterTags)
        {
            try
            {
                return books.AsEnumerable()
                    .Where(row => filterTags.Any(filterTag =>
                        row.Field<string>("Col_2").Split('\n').Select(tag => tag.Trim())
                            .Any(tag => String.Equals(tag, filterTag, StringComparison.OrdinalIgnoreCase))))
                    .Select(row => new Book
                    {
                        Identifier = row.Field<string>("Col_0"),
                        Title = row.Field<string>("Col_1"),
                        Tags = row.Field<string>("Col_2").Split('\n').Select(tag => tag.Trim()).ToList()
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error filtering books: {ex.Message}");
                return new List<Book>();
            }
        }
    }
}
