﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShop.Website.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string? Address { get; set; }
        public string? Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"mailto:{Address}");
            output.Content.SetContent(Content);   
        }
    }
}
