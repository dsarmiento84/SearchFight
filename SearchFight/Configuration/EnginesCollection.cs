using System.Configuration;

namespace SearchFight.Configuration
{
    [ConfigurationCollection(typeof(EngineElement))]
    public class EnginesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EngineElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EngineElement)(element)).EngineName;
        }

        public EngineElement this[int idx]
        {
            get { return (EngineElement)BaseGet(idx); }
        }
    } 
}
