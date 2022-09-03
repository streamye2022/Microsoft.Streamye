using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Streamye.DesignPattern.Configuration.Providers
{
    public class JsonConfigurationProvider : IConfigurationProvider
    {
        private IDictionary<string, string> Data { get; } = new Dictionary<string, string>();

        public JsonConfigurationSource JsonConfigurationSource;

        public void Load()
        {
            using (StreamReader reader = File.OpenText(JsonConfigurationSource.jsonFilePath))
            {
                using (JsonTextReader textReader = new JsonTextReader(reader))
                {
                    JObject jObject = (JObject)JToken.ReadFrom(textReader);
                    string value = jObject["aaaa"].ToString();
                    Data["aaaa"] = value;
                }
            }
        }

        public string Get(string key)
        {
            return Data[key];
        }

        public string this[string key]
        {
            get { return Data[key]; }
        }
    }
}