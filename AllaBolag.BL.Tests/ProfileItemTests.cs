using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AllaBolag.BL.Models;
using AllaBolag.BL.Services;
using AllaBolag.BL.Builders;
using AllaBolag.BL.CustomExceptions;

namespace AllaBolag.BL.Tests
{
    /// <summary>
    /// Summary description for ProfileItemTests
    /// </summary>
    [TestClass]
    public class ProfileItemTests
    {
        HtmlService _htmlService;
        ProfileBuilder _profileBuilder;

        public ProfileItemTests()
        {
            _htmlService = new HtmlService();
            _profileBuilder = new ProfileBuilder();
        }

        [TestMethod]
        public void Get_Item_By_Url_Returns_Existing_Organisation_Number()
        {
            //Arrange
            var document =  _htmlService.GetDocument("https://www.allabolag.se/5564480282/atea-sverige-ab").Result;
            var expected = new ProfileItem()
            {
                CompanyName = "Atea Sverige AB",
                OrganisationNumber = "556448-0282",
            };
            //Act
            var actual = _profileBuilder.Build(new ProfileItemStrategy(document));
            //Assert
            Assert.AreEqual(expected.OrganisationNumber, actual.Object.OrganisationNumber);
        }

        [TestMethod]
        public void Get_List_Item_By_Url_Returns_Existing_Organisation_Number()
        {
            //Arrange
            var document = _htmlService.GetDocument("https://www.allabolag.se/what/atea");
            var expected = new ProfileListItem()
            {
                Header = "Atea Sverige AB",
                OrganisationNumber = "556448-0282",
            };

            //Act
            var actual = _profileBuilder.Build(new ProfileListItemStrategy(document.Result));
            //Assert
            Assert.AreEqual(expected.OrganisationNumber, actual.Object.OrganisationNumber);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullExceptionResult<ProfileListItem>))]
        public void Get_List_Item_By_Url_Returns_Argument_Null_Exception_Result()
        {
            //Arrange
            var document = _htmlService.GetDocument("https://www.allabolag.se/5564480282/atea-sverige-ab").Result;
            //Act
            var actual = _profileBuilder.Build(new ProfileListItemStrategy(document));
        }
    }
}
