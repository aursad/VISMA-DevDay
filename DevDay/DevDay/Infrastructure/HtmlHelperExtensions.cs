using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevDay.Infrastructure
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        ///     Creates an AngularJS template with the given ID
        /// </summary>
        /// <param name="helper"><see cref="HtmlHelper"/> class</param>
        /// <param name="templateId">Id of template</param>
        /// <returns></returns>
        public static AngularTemplate AngularTemplate(this HtmlHelper helper, string templateId)
        {
            var tagBuilder = new TagBuilder("script");
            tagBuilder.Attributes.Add("type", "text/ng-template");
            tagBuilder.Attributes.Add("id", templateId);
            helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            return new AngularTemplate(helper.ViewContext);
        }
    }
}