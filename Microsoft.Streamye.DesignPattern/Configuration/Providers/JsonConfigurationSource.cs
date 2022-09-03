namespace Microsoft.Streamye.DesignPattern.Configuration.Providers
{
    public class JsonConfigurationSource : IConfigurationSource
    {
        public string jsonFilePath { get; set; }

        public bool Optional { get; set; }

        public bool OnReloadChange { get; set; }


        public IConfigurationProvider CreateProvider()
        {
            JsonConfigurationProvider jsonConfigurationProvider = new JsonConfigurationProvider();
            jsonConfigurationProvider.JsonConfigurationSource = this;
            return jsonConfigurationProvider;
        }
    }
}