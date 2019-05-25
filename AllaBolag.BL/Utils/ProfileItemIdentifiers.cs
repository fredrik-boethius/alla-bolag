using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.BL.Utils
{
    public static class ProfileItemIdentifiers
    {
        public const string CompanyName = "//h1[@class='p-name']";
        public const string OrganisationNumber = "//span[@class='organisation__number']";

        public const string CEO = "//div[@class='flex-grid__cell']//dd[1]//a";
        public const string Phone = "//a[@class='p-tel']//span[@class='no-wrap']";

        public const string NumberOfEmployees = "//td[@class='number--positive data-pager__page data-pager__page--0'][1]";
        public const string AnnualRevenue = "//tbody/tr[2]/td[@class='number--positive data-pager__page data-pager__page--0'][1]";
        public const string NetEarnings = "//div[@class='flex-grid']//div[@class='flex-grid__cell'][1]//p";
        public const string Liquidity = "//div[@class='flex-grid']//div[@class='flex-grid__cell'][2]//p";
        public const string Solidity = "//div[@class='flex-grid']//div[@class='flex-grid__cell'][3]//p";
        public const string BottomLine = "//div[@class='flex-grid']//div[@class='flex-grid__cell'][4]//p";
    }
}
