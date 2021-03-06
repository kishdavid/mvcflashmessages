﻿using System;
using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Mvc;

namespace MvcFlashMessages
{
    public static class HtmlHelperExtensions
    {
        private readonly static string closeTag = string.Format("<span class=\"close\" onclick=\"javascript:{0}\">&times;</span>", Config.Instance.CloseClickEvent);

        /// <summary>
        /// Renders the HTML containing the flash messages.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns>HTML string</returns>
        public static IHtmlString RenderFlash(this HtmlHelper htmlHelper)
        {
            Contract.Requires<ArgumentNullException>(htmlHelper != null);

            TagBuilder outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass(Config.Instance.OuterCssClass);

            FlashMessageCollection flashMessageCollection = new FlashMessageCollection(htmlHelper.ViewContext.TempData);
            foreach (FlashMessage flashMessage in flashMessageCollection)
            {
                TagBuilder innerDiv = new TagBuilder("div");
                innerDiv.AddCssClass(Config.Instance.InnerCssClass + "-" + flashMessage.Key); 
                innerDiv.AddCssClass(Config.Instance.InnerCssClass);
                innerDiv.InnerHtml = "";
                innerDiv.InnerHtml += AddCloseTag();
                innerDiv.InnerHtml += flashMessage.Message;
                outerDiv.InnerHtml += innerDiv.ToString(TagRenderMode.Normal);
            }

            return MvcHtmlString.Create(outerDiv.ToString(TagRenderMode.Normal));
        }

        private static string AddCloseTag()
        {
            return Config.Instance.IsClosable ? closeTag : "";
        }
    }
}
