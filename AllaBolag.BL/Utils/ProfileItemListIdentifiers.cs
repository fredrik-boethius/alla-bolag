using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.BL.Utils
{
    public static class ProfileItemListIdentifiers
    {
        public const string ListItemContainer = "//div[@class='search-results__item']";
        public const string Header = "//header/h2/a";
        public const string ProfileLink = "//div[@class='search-results__item']/div/header/h2/a";
        public const string SubTitle = "//div[@class='search-resuladeritem__subtitle']";
        public const string OrganizationNumber = "//dl[@class='search-results__item__details']/dd[1]";
        public const string BusinessArea = "//dl[@class='search-results__item__details']/dd[2]";
        
    }
}
