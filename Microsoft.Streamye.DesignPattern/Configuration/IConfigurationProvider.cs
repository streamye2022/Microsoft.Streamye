namespace Microsoft.Streamye.DesignPattern.Configuration
{
    public interface IConfigurationProvider
    {
        public void Load();
        public string Get(string key);
    }
}