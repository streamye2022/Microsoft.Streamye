using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    public class Endpoint
    {
        //方法信息
        public MethodInfo methodInfo { set; get; }
        
        //控制器，也就是被调用的对象
        public object Controller { set; get; }

        //方法参数信息
        public IList<ParameterInfo> parameterInfos { set; get; }

        //方法的返回值
        public object returnValue { set; get; }
        
        // 数据输出格式（json,xml）
        public string dataType { set; get; }
    }
}