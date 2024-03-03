using System;
using System.Collections.Generic;
using System.Data;
using FilterByTags.Models;
using FilterByTags.Services;
using FilterByTags.Services.Interfaces;
using FilterByTags.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace FilterByTags
{
    internal class Program
    {
        private readonly IBookProcessor _bookProcessor;

        public Program(IBookProcessor bookProcessor)
        {
            _bookProcessor = bookProcessor;
        }

        public void Run(string filePath, string taglistPath)
        {
            try
            {
                List<Book> initialFilteredBooks = _bookProcessor.Process(filePath, taglistPath);

                BookHelper bookHelper = new BookHelper();
                bookHelper.DisplayBooks(initialFilteredBooks);

                Console.Write("Input Tag List: ");
                string? tagListInput = Console.ReadLine();

                // Validate if the input is empty
                if (string.IsNullOrWhiteSpace(tagListInput))
                {
                    Console.WriteLine("Error: Please enter at least one tag.");
                    return;
                }

                List<string> tagList = tagListInput.Split(',').Select(tag => tag.Trim()).ToList();

                List<Book> filteredBooks = _bookProcessor.Process(filePath, "", tagList);

                FileHelper fileHelper = new FileHelper();
                FileHelper.StoreOutputToFile("VincentJamesDemetria.txt", filteredBooks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            // Setup Dependency Injection
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddTransient<IBookProcessor, BookProcessor>()
                .AddSingleton<IInputReader, CSVInputReader>()
                .AddSingleton<ITagLoader, TagLoader>()
                .AddSingleton<IBookFilter, BookFilter>()
                .AddSingleton<FileHelper>()
                .AddSingleton<BookHelper>()
                .AddTransient<Program>()
                .BuildServiceProvider();

            Program program = serviceProvider.GetRequiredService<Program>();

            program.Run("./books.csv", "./taglist.txt");
        }
    }
}
