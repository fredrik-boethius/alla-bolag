using AllaBolag.BL.CustomExceptions;
using AllaBolag.BL.Models;
using HtmlAgilityPack;
using System;
using System.Linq;
using static AllaBolag.BL.Utils.ProfileItemListIdentifiers;

namespace AllaBolag.BL.Builders
{
    public class ProfileListItemStrategy : IBuildStrategy<Result<ProfileListItem>>
    {
        private HtmlDocument _htmlDocument;
        public ProfileListItemStrategy(HtmlResult result)
        {
            _htmlDocument = result.Object;
        }
        public Result<ProfileListItem> Build()
        {
            var result = new Result<ProfileListItem>();
            ProfileListItem item = null;
            HtmlNode container = null;
            try
            {
                container = _htmlDocument?.DocumentNode.SelectNodes(ListItemContainer).FirstOrDefault();
                item = new ProfileListItem
                {
                    Header = container?.SelectSingleNode(Header).InnerHtml,
                    OrganisationNumber = container?.SelectSingleNode(OrganizationNumber).InnerHtml,
                    SubTitle = container?.SelectSingleNode(SubTitle).InnerHtml,
                    BusinessArea = container?.SelectSingleNode(BusinessArea).InnerHtml,
                    ProfileLink = container?.SelectSingleNode(ProfileLink).Attributes[0].Value
                };
            }
            catch (ArgumentNullException)
            {
                result.Object = item;
                result.Message = $"Failed to populate ProfileListItem";

                throw new ArgumentNullExceptionResult<ProfileListItem>(result);
            }
            result.Object = item;
            result.Message = "Successfully populated ProfileListItem";
            return result;
        }
    }
}
