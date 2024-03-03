using System;
using System.Collections.Generic;
using System.Data;
using FilterByTags.Models;
using FilterByTags.Services.Interfaces;

namespace FilterByTags.Services
{
    public class BookProcessor : IBookProcessor
    {
        private readonly IInputReader _reader;
        private readonly IBookFilter _filter;
        private readonly ITagLoader _loader;

        public BookProcessor(IInputReader reader, IBookFilter filter, ITagLoader loader)
        {
            _reader = reader;
            _filter = filter;
            _loader = loader;
        }

        public List<Book> Process(string filePath, string taglistPath, List<string>? tagLists = null)
        {
            try
            {
                DataTable books = _reader.Read(filePath);

                List<string> filterTags = !string.IsNullOrWhiteSpace(taglistPath) ? _loader.Load(taglistPath) : new List<string>();

                List<Book> filteredBooks = _filter.Filter(books, tagLists ?? filterTags);

                return filteredBooks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing books: {ex.Message}");
                return new List<Book>(); // Return an empty list in case of an error
            }
        }
    }
}
