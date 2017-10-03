using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Seven.ExtendedModel
{
    public static class HtmlHelpers
    {
        public static string IdFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
        {
            string propiedad = ExpressionHelper.GetExpressionText(expression);
            return html.ViewData.TemplateInfo.GetFullHtmlFieldId(propiedad);
        }

        public static string NameFor<TModel, TProperty>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression)
        {
            string propiedad = ExpressionHelper.GetExpressionText(expression);
            return html.ViewData.TemplateInfo.GetFullHtmlFieldName(propiedad);
        }
    }
}