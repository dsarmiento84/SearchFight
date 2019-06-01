using System.Text.RegularExpressions;

namespace SearchFight.Services
{
    class ParserService
    {
        public string Parse(string html, string regexPattern)
        {
            var regex = new Regex(regexPattern);
            var match = regex.Match(html);
            return match.Groups[1].Value.Length > 0 ? match.Groups[1].Value : "-1";
        }
    }
}
