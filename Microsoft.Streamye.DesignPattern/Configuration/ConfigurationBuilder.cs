using System.Collections.Generic;
using System.IO;
using Microsoft.Streamye.DesignPattern.Configuration.Providers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Streamye.DesignPattern.Configuration
{
    public class ConfigurationBuilder
    {
        private Configuration _configuration = new Configuration();

        //问题： 如果有多个数据源怎么办？
        private IList<IConfigurationSource> _sources = new List<IConfigurationSource>();


        public ConfigurationBuilder AddJsonFile(string filepath, bool optional = false, bool reloadOnChange = false)
        {
            // using (StreamReader reader = File.OpenText(filepath))
            // {
            //     using (JsonTextReader textReader = new JsonTextReader(reader))
            //     {
            //         JObject jObject = (JObject)JToken.ReadFrom(textReader);
            //         string value = jObject["aaaa"].ToString();
            //         _configuration.Set("aaaa", value);
            //     }
            // }

            // 1、创建json源对象
            JsonConfigurationSource jsonConfigurationSource = new JsonConfigurationSource();
            jsonConfigurationSource.jsonFilePath = filepath;
            jsonConfigurationSource.Optional = optional;
            jsonConfigurationSource.OnReloadChange = reloadOnChange;

            _sources.Add(jsonConfigurationSource);
            return this;
        }
        
        public Configuration Build()
        {
            foreach (var configurationSource in _sources)
            {
                //获得每个source 的provider
                IConfigurationProvider configurationProvider =  configurationSource.CreateProvider();
                
                //塞数据进去
                configurationProvider.Load();
                // 3、json数据复制
                _configuration.configurationProviders.Add(configurationProvider);
            }

            return _configuration;
        }
    }
}