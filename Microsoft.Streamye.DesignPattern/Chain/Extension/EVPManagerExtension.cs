using Microsoft.Streamye.DesignPattern.Chain.Manager;

namespace Microsoft.Streamye.DesignPattern.Chain
{
    public static class EVPManagerExtension
    {
        public static void AddEVPManager(this ProductAuditBuilder productAuditBuilder)
        {
            productAuditBuilder.AddManager(new EVPManager());
        }
    }
}