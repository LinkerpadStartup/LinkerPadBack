using System;
using HtmlAgilityPack;

namespace LinkerPad.Common
{
    public class HtmlManipulation
    {
        private static Ganss.XSS.HtmlSanitizer _sanitizer;

        public HtmlManipulation()
        {
            InitializeSanitizor();
        }

        public static string AddIdToHtmlElement(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return "";

            InitializeSanitizor();
            html = SanitizeHtml(html);
            HtmlDocument htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            Random random = new Random();
            foreach (var childNode in htmlDoc.DocumentNode.ChildNodes)
            {
                double randomNumber = random.Next(100000, 999999);
                if (string.IsNullOrWhiteSpace(childNode.Attributes["id"]?.Value))
                    childNode.Attributes.Add("id", $"text_{randomNumber}");
                randomNumber = 0;
            }

            return htmlDoc.DocumentNode.OuterHtml;
        }

        public static string SanitizeHtml(string html)
        {
            InitializeSanitizor();
            return string.IsNullOrWhiteSpace(html) ? "" : _sanitizer.Sanitize(html);
        }

        private static void InitializeSanitizor()
        {
            _sanitizer = new Ganss.XSS.HtmlSanitizer();
            _sanitizer.AllowedAttributes.Clear();

            _sanitizer.AllowedAttributes.UnionWith(new[] { "src", "alt", "href", "style", "id", "class", "target", "rel" });
        }
    }
}
