using FilterByTags.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilterByTags.Services
{
    internal class TagLoader : ITagLoader
    {
        public TagLoader() { }

        public List<string> Load(string tagListFile)
        {
            try
            {
                return File.ReadAllLines(tagListFile)
                           .SelectMany(line => line.Split(','))
                           .Select(tag => tag.Trim())
                           .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tags: {ex.Message}");
                return new List<string>(); // Return an empty list in case of an error
            }
        }
    }
}
