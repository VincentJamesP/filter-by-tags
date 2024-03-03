using System;
using System.Collections.Generic;
using FilterByTags.Models;

namespace FilterByTags.Utils
{
    internal class BookHelper
    {
        public void DisplayBooks(List<Book> books, int maxRowTitleWidth = 20, int maxRowTagWidth = 80)
        {
            try
            {
                int maxIdentifierWidth = books.Max(book => Math.Min(book.Title.Length, maxRowTitleWidth));
                int maxTagsWidth = books.Max(book => Math.Min(string.Join(",", book.Tags).Length, maxRowTagWidth));

                Console.WriteLine($"{PadRight("BOOKS", maxIdentifierWidth)}\t{PadRight("TAGS", maxTagsWidth)}");

                foreach (Book book in books)
                {
                    string truncatedTitle = TruncateIfNeeded(book.Title, maxRowTitleWidth);
                    string truncatedTags = TruncateIfNeeded(string.Join(",", book.Tags), maxRowTagWidth);

                    Console.Write($"{PadRight(truncatedTitle, maxIdentifierWidth)}\t");
                    Console.Write($"{PadRight(truncatedTags, maxTagsWidth)}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying books: {ex.Message}");
            }
        }

        private string PadRight(string input, int width)
        {
            return $"{input.PadRight(width)} ";
        }

        private string TruncateIfNeeded(string input, int maxLength)
        {
            if (input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                return input.Substring(0, maxLength - 3) + "..."; // Display "..." after the limit
            }
        }
    }
}
