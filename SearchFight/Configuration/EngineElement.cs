using System.Configuration;

namespace SearchFight.Configuration
{
    public class EngineElement : ConfigurationElement
    {
        [ConfigurationProperty("engineName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string EngineName
        {
            get { return ((string)(base["engineName"])); }
            set { base["engineName"] = value; }
        }

        [ConfigurationProperty("engineURL", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string EngineURL
        {
            get { return ((string)(base["engineURL"])); }
            set { base["engineURL"] = value; }
        }

        [ConfigurationProperty("engineRegexPattern", DefaultValue = "", IsKey = false, IsRequired = true)]
        public string EngineRegexPattern
        {
            get { return ((string)(base["engineRegexPattern"])); }
            set { base["engineRegexPattern"] = value; }
        }
    }
}
