using FilterByTags.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FilterByTags.Utils
{
    internal class FileHelper
    {
        public static void StoreOutputToFile(string fileName, List<Book> books)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Identifier}\t{book.Title}");
                    }
                }

                Console.WriteLine($"Output successfully stored to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing output to file: {ex.Message}");
            }
        }
    }
}
