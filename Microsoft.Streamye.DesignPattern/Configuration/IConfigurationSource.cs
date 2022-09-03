namespace Microsoft.Streamye.DesignPattern.Configuration
{
    public interface IConfigurationSource
    {
        public IConfigurationProvider CreateProvider();
    }
}