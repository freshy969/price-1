using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Web
{
    internal class SetUserLanguageAttribute: FilterAttribute, IActionFilter
    {
        private static readonly string[] supportedLanguages = new []{ "lt", "en" };

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = GetLanguage(filterContext);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
        }

        private static string GetLanguage(ActionExecutingContext filterContext)
        {
            var languages = filterContext.HttpContext.Request.UserLanguages;
            foreach (string languageString in languages)
            {
                return ExtractLanguageName(languageString);
            }
            return "lt";
        }

        private static string ExtractLanguageName(string languageString)
        {
            var index = languageString.IndexOf(";");
            if (index >= 0)
            {
                languageString = languageString.Substring(0, index);
            }
            return languageString;
        }
    }
}