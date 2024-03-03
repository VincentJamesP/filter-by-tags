using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterByTags.Services.Interfaces
{
    public interface IInputReader
    {
        DataTable Read(string file);
    }
}
