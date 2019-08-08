using AllaBolag.BL.Builders;
using AllaBolag.BL.Models;
using AllaBolag.BL.Services;
using AllaBolag.Infrastructure.FileHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FileReader handler = new FileReader();

            HtmlService htmlService = new HtmlService();

            Console.WriteLine("Enter full path to file...");
            string path = Console.ReadLine();
            IEnumerable<string> companies = handler.ReadAllRows(path);
            decimal counter = 0;

            var itemList = new List<ProfileListItem>();
            foreach (var companyName in companies.Take(5))
            {
                Thread.Sleep(2000);
                var html = await htmlService.GetDocument($"https://www.allabolag.se/what/{companyName}");
                try
                {
                    Result<ProfileListItem> item = new ProfileBuilder().Build(new ProfileListItemStrategy(html));
                    counter++;
                    Console.Clear();

                    Console.WriteLine($"{(counter / companies.Count()):P2}");
                }
                catch (AggregateException)
                {

                    itemList.Add(new ProfileListItem { Header = companyName });
                }
            }

            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\F.Boethius-Fjarem\\source\\repos\\AllaBolag\\AllaBolag.Infrastructure.Tests\\Companies_Output.csv"))
            {
                outputFile.WriteLine($"Bolagsnamn\tOrg.Nr\tCEO\tTelefon\tAntal Anställda\tOmsättning(tkr)\tBRUTTOVINSTMARGINAL\tVINSTMARGINAL\tKASSALIKVIDITET\tSOLIDITET");
                counter = 0;
                foreach (ProfileListItem item in itemList.Where(i => !string.IsNullOrEmpty(i.ProfileLink)))
                {
                    counter++;
                    Console.Clear();
                    Console.WriteLine($"{counter / itemList.Count:P4}");
                    try
                    {
                        Task<HtmlResult> document = htmlService.GetDocument(item.ProfileLink);
                        string result = new ProfileBuilder().Build(new ProfileItemStrategy(document.Result)).ToString();
                        outputFile.WriteLine(result);
                    }
                    catch (Exception)
                    {

                        outputFile.WriteLine(new ProfileItem { CompanyName = item.Header }.ToString());
                    }

                    Thread.Sleep(2000);

                }
            }
        }
    }
}
