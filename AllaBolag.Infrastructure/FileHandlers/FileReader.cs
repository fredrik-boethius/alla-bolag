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
            var result = new List<string>();
            try
            {
                result = File.ReadLines(path).Aggregate(new List<string>(), (aggr, curr) =>
                {
                    aggr.Add(curr);
                    return aggr;
                });
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You don't have acess to this directory");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Can't find your directory");
            }
            catch (Exception)
            {

                throw;
            }
            return result;


        }
    }
}
