using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByTags.Services.Interfaces
{
    public interface ITagLoader
    {
        List<string> Load(string tagListFile);
    }
}
