using System.Configuration;

namespace SearchFight.Configuration
{
    public class EnginesConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Engines")]
        public EnginesCollection EngineItems
        {
            get { return ((EnginesCollection)(base["Engines"])); }
        }
    }
}
