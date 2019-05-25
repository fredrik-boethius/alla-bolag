using AllaBolag.BL.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.BL.Services
{
    public class HtmlService
    {
        public async Task<HtmlResult> GetDocument(string url)
        {
            var result = new HtmlResult();
            
            var document = await new HtmlWeb().LoadFromWebAsync(url, Encoding.UTF8);
            if (document != null)
            {
                result.Object = document;
                result.Message = "Document successfully loaded";
            }
            else
            {
                result.Message = "Document failed to load";
            }
            return result;

        }
        
    }
}
