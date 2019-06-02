using System;
using System.Threading.Tasks;

using SearchFight.Engines;
using SearchFight.Services;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            SanitizerService Sanitizer = new SanitizerService();
            string[] CheckedArgs = Sanitizer.SanitizeArgs(args);
            SearchEngineGroup EngineGroup = new SearchEngineGroup();
            SearchStatsService SearchResults = new SearchStatsService(CheckedArgs, EngineGroup.SearchEngines);
            OutputFormatService Output = new OutputFormatService();

            if(CheckedArgs.Length < 1)
            {
                Console.WriteLine("SearchFight | error: You must enter at least 1 language");
                return;
            }

            Parallel.ForEach(EngineGroup.SearchEngines, engine =>
            {
                foreach (string language in CheckedArgs)
                {
                    SearchResults.UpdateStat(engine.Search(language));
                }
            });

            Output.Format(SearchResults);
        }
    }
}