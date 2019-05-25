using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.Infrastructure.FileHandlers
{
    public class FileReader
    {
        public IEnumerable<string> ReadAllRows(string path)
        {
            return File.ReadLines(path).Aggregate(new List<string>(),(aggr,curr)=> {
                aggr.Add(curr);
                return aggr;
            });
            
        }
    }
}
