using FilterByTags.Services.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByTags.Services
{
    internal class CSVInputReader : IInputReader
    {
        public bool ReadFirstRowAsHeader { get; set; }

        public CSVInputReader() { }

        public DataTable Read(string file)
        {
            using var parser = new TextFieldParser(file)
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new string[] { "," }
            };
            try
            {
                var table = new DataTable();

                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields() ?? new string[0];
                    if (table.Columns.Count == 0)
                    {
                        table.Columns.AddRange(fields
                            .Select((f, idx) => ReadFirstRowAsHeader ?
                                            new DataColumn(f, typeof(string)) :
                                            new DataColumn($"Col_{idx}", typeof(string)))
                            .ToArray());

                        if (ReadFirstRowAsHeader) continue;
                    }

                    var row = table.NewRow();
                    row.ItemArray = fields;
                    table.Rows.Add(row);
                }

                return table;
            }
            finally
            {
                parser.Close();
            }
        }
    }
}
