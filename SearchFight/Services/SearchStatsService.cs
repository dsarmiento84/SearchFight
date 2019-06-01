using System.Collections.Generic;

using SearchFight.Engines;

namespace SearchFight.Services
{
    class SearchStatsService
    {
        public Dictionary<string, Dictionary<string, long>> Stats = new Dictionary<string, Dictionary<string, long>>();
        public Dictionary<string, KeyValuePair<string, long>> StatsWinners = new Dictionary<string, KeyValuePair<string, long>>();
        public Dictionary<string, long> StatsTotal = new Dictionary<string, long>();

        public SearchStatsService(string[] languages, List<SearchEngine> engines)
        {
            foreach (string language in languages)
            {
                Stats.Add(language, new Dictionary<string, long>());
                StatsTotal.Add(language, 0);
                
                foreach (SearchEngine engine in engines)
                {
                    Stats[language].Add(engine.Name, 0);
                }
            }

            foreach (SearchEngine engine in engines)
            {
                StatsWinners.Add(engine.Name, new KeyValuePair<string, long>());
            }
        }

        public void UpdateStat(ResultService result)
        {
            // Language stats
            if (result.NumResults > -1)
            {
                Stats[result.Language][result.EngineName] = result.NumResults;
                StatsTotal[result.Language] += result.NumResults;
            }
            else
            {
                Stats[result.Language].Remove(result.EngineName);
            }

            // Engine stats
            if (result.NumResults >= StatsWinners[result.EngineName].Value)
            {
                StatsWinners[result.EngineName] = new KeyValuePair<string, long>(result.Language, result.NumResults);
            }
        }
    }
}
