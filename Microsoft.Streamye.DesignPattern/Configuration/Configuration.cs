using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Streamye.DesignPattern.Configuration
{
    public class Configuration
    {
        // public IDictionary<string, string> dics { get; } = new Dictionary<string, string>();
        
        public List<IConfigurationProvider> configurationProviders { set; get; } = new List<IConfigurationProvider>();  


        // public void Set(string key, string value)
        // {
        //     dics[key] = value;
        // }
        
        //索引器
        public string this[string key]
        {
            get
            {
                foreach (var configurationProvider in configurationProviders)
                {
                    string value = configurationProvider.Get(key);
                    if (value != null)
                    {
                        return value;
                    }
                }
                return null;
            }
        }

    }
}