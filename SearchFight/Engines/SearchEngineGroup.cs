using System.Configuration;
using System.Collections.Generic;

using SearchFight.Configuration;

namespace SearchFight.Engines
{
    class SearchEngineGroup
    {
        public List<SearchEngine> SearchEngines = new List<SearchEngine>();
        private EnginesConfigSection EnginesSection = (EnginesConfigSection)ConfigurationManager.GetSection("EnginesConfiguration");

        public SearchEngineGroup()
        {
            foreach (EngineElement engine in EnginesSection.EngineItems)
            {
                SearchEngines.Add(new SearchEngine(engine.EngineName, engine.EngineURL, engine.EngineRegexPattern));
            }
        }
    }
}
