using HelperMethods07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelperMethods07.Infrastructure
{
    public static class CustomHelper
    {
        public static MvcHtmlString ListItems(this HtmlHelper html, string[] items)
        {
            TagBuilder tag = new TagBuilder("ul");

            foreach (string item in items)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(item);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        {
            string result = string.Format("This is the message: <p>{0} </ p > ", msg);

            return new MvcHtmlString(result);
        }

        public static string DisplayMessage2(this HtmlHelper html, string msg)
        {
            return string.Format("This is the message: <p>{0} </ p > ", msg);
        }

        public static MvcHtmlString DisplayMessage3(this HtmlHelper html, string msg)
        {
            string encoded = html.Encode(msg);
            string result = string.Format("This is the message: <p>{0} </ p > ", encoded);

            return new MvcHtmlString(result);
        }
    }
}