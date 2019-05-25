using AllaBolag.BL.CustomExceptions;
using AllaBolag.BL.Models;
using AllaBolag.Common;
using HtmlAgilityPack;
using System;
using static AllaBolag.BL.Utils.ProfileItemIdentifiers;

namespace AllaBolag.BL.Builders
{
    public class ProfileItemStrategy : IBuildStrategy<Result<ProfileItem>>
    {
        private HtmlDocument _htmlDocument;
        public ProfileItemStrategy(HtmlResult result)
        {
            _htmlDocument = result.Object;
        }

        public Result<ProfileItem> Build()
        {
            Result<ProfileItem> result = new Result<ProfileItem>();
            ProfileItem item = null;
            try
            {
                item = new ProfileItem
                {
                    OrganisationNumber = _htmlDocument?.DocumentNode.SelectSingleNode(OrganisationNumber).InnerHtml.Transform((s) => s.Trim()),
                    CompanyName = _htmlDocument?.DocumentNode.SelectSingleNode(CompanyName)?.InnerHtml
                };
                item.CompanyInformation = new CompanyInformation
                {
                    OrganisationNumber = item.OrganisationNumber,
                    CEO = _htmlDocument?.DocumentNode.SelectSingleNode(CEO)?.InnerHtml,
                    Phone = _htmlDocument?.DocumentNode.SelectSingleNode(Phone)?.InnerHtml
                };
                item.CompanyFinances = new CompanyFinances
                {
                    OrganisationNumber = item.OrganisationNumber,
                    NumberOfEmployees = _htmlDocument?.DocumentNode.SelectSingleNode(NumberOfEmployees)?.InnerHtml,
                    AnnualRevenue = _htmlDocument?.DocumentNode.SelectSingleNode(AnnualRevenue)?.InnerHtml,
                    BottomLine = _htmlDocument?.DocumentNode.SelectSingleNode(BottomLine)?.InnerHtml,
                    Liquidity = _htmlDocument?.DocumentNode.SelectSingleNode(Liquidity)?.InnerHtml,
                    NetEarnings = _htmlDocument?.DocumentNode.SelectSingleNode(NetEarnings)?.InnerHtml,
                    Solidity = _htmlDocument?.DocumentNode.SelectSingleNode(Solidity)?.InnerHtml
                };
            }
            catch (ArgumentNullException)
            {
                result.Object = item;
                result.Message = $"Failed to populate ProfileItem";
                throw new ArgumentNullExceptionResult<ProfileItem>(result);
            }
            result.Object = item;
            result.Message = "Successfully populated ProfileItem";
            return result;
        }
    }
}
