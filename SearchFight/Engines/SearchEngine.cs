using System;
using System.IO;
using System.Net;
using System.Text;

using SearchFight.Services;

namespace SearchFight.Engines
{
    class SearchEngine
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string RegexPattern { get; set; }

        public SearchEngine(string name, string url, string regexPattern)
        {
            Name = name;
            URL = url;
            RegexPattern = regexPattern;
        }

        public ResultService Search(string language)
        {
            StreamReader reader;
            ParserService ps = new ParserService();
            SanitizerService ss = new SanitizerService();
            string queryURL = string.Format(URL, ss.SanitizeInput(language));
            string html, numResultsStr;
            long numResults;

            try
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(queryURL);
                request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; .NET CLR 1.0.3705;)";
                request.Timeout = 60000;
                request.Method = "GET";
                WebResponse response = request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    reader = new StreamReader(dataStream, Encoding.ASCII);
                    html = reader.ReadToEnd();
                    numResultsStr = ps.Parse(html, RegexPattern);
                }
                reader.Close();
                response.Close();

                numResults = ss.SanitizeOutput(numResultsStr);

                if (numResults == -1)
                {
                    throw new System.InvalidCastException();
                }
                return new ResultService { EngineName = Name, Language = language, NumResults = numResults };
            }
            catch (WebException e)
            {
                Console.WriteLine("SearchFight | error: {0} on {1} search: \"{2}\". Please try again.", e.Status, Name, language);
                return new ResultService { EngineName = Name, Language = language, NumResults = -1 };
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("SearchFight | error: Result could not be parsed. The term entered had 0 results or check App.config for configuration of engine {0}", Name);
                return new ResultService { EngineName = Name, Language = language, NumResults = -1 };
            }        
        }
    }
}
