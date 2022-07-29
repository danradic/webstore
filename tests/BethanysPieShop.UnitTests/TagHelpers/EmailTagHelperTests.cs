using BethanysPieShop.Website.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.UnitTests.TagHelpers
{
    public class EmailTagHelperTests
    {
        [Fact]
        public void Process_ShouldGenerateEmailLink () 
        {
            // Arrange
            EmailTagHelper emailTagHelper = new()
            { 
                Address = "test@bethanyspieshop.com", 
                Content = "Email" 
            };

            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                String.Empty);
            var content = new Mock<TagHelperContent>();

            var tagHelperOutput = new TagHelperOutput("a", 
                new TagHelperAttributeList(), 
                (cache, encoder) => Task.FromResult(content.Object));

            // Act
            emailTagHelper.Process(tagHelperContext, tagHelperOutput);

            // Assert
            Assert.Equal("Email", tagHelperOutput.Content.GetContent());
            Assert.Equal("a", tagHelperOutput.TagName);
            Assert.Equal("href", tagHelperOutput.Attributes[0].Name);
            Assert.Equal("mailto:test@bethanyspieshop.com", tagHelperOutput.Attributes[0].Value);
        }
    }
}
