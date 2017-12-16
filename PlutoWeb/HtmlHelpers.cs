using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace PlutoWeb
{
    public static class HtmlHelpers
    {
        public static HtmlString AlphabeticalPager(this HtmlHelper html, string selectedLetter, IEnumerable<string> firstLetters, Func<string, string> pageLink)
        {
            var sb = new StringBuilder();
            var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());
            var alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList();
            alphabet.Insert(0, "All");
            alphabet.Insert(1, "0-9");
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            ul.AddCssClass("alpha");
            foreach (var letter in alphabet)
            {
                var li = new TagBuilder("li");
                if (firstLetters.Contains(letter) || (firstLetters.Intersect(numbers).Any() && letter == "0-9") || letter == "All")
                {
                    if (selectedLetter == letter || string.IsNullOrEmpty(selectedLetter) && letter == "All")
                    {
                        li.AddCssClass("active");
                        var span = new TagBuilder("span");
                        span.SetInnerText(letter);
                        li.InnerHtml = span.ToString();
                    }
                    else
                    {
                        var a = new TagBuilder("a");
                        a.MergeAttribute("href", pageLink(letter));
                        a.InnerHtml = letter;
                        li.InnerHtml = a.ToString();
                    }
                }
                else
                {
                    li.AddCssClass("inactive");
                    var span = new TagBuilder("span");
                    span.SetInnerText(letter);
                    li.InnerHtml = span.ToString();
                }
                sb.Append(li.ToString());
            }
            ul.InnerHtml = sb.ToString();
            return new HtmlString(ul.ToString());
        }

    }


}