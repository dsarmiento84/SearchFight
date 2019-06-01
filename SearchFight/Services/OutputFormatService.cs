using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight.Services
{
    class OutputFormatService
    {
        public void Format(SearchStatsService Results)
        {
            string output = "";
            string outputLanguage = "";
            string outputEngines = "";
            string outputWinners = "";
            KeyValuePair<string, long> Total = Results.StatsTotal.Aggregate((k, v) => k.Value > v.Value ? k : v);

            foreach (KeyValuePair<string, Dictionary<string, long>> languageStats in Results.Stats)
            {
                outputLanguage = string.Format("{0}: ", languageStats.Key);
                outputEngines = "";

                foreach (KeyValuePair<string, long> engineStats in languageStats.Value)
                {
                    outputEngines += string.Format("{0}: {1} ", engineStats.Key, engineStats.Value);
                }

                output += string.Format("{0}{1}{2}", outputEngines.Length > 0 ? outputLanguage : "", outputEngines, outputEngines.Length > 0 ? Environment.NewLine : "");
            }
            Console.Write(output);

            foreach (KeyValuePair<string, KeyValuePair<string, long>> engineWinnerStats in Results.StatsWinners)
            {
                outputWinners += (engineWinnerStats.Value).Value > 0 ? string.Format("{0} winner: {1}{2}", engineWinnerStats.Key, (engineWinnerStats.Value).Key, Environment.NewLine) : "";
            }
            Console.Write(outputWinners);

            if (Total.Value > 0)
            {
                Console.WriteLine("Total winner: {0}", Total.Key);
            }
        }
    }
}
