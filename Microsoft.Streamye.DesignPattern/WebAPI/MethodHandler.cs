using System;
using System.Reflection;

namespace Microsoft.Streamye.DesignPattern.WebAPI
{
    public class MethodHandler
    {
        public Object HandlerMethod(Object target,MethodInfo methodInfo,object[] args)
        {
            // //获得类型
            // Type type = typeof(CanaryCheckController);
            // //创建对象
            // Object o = Activator.CreateInstance(type);
            // //获得方法
            // MethodInfo methodInfo = type.GetMethod("CheckVM");
            // //调用方法
            // methodInfo.Invoke(o, new object[] { });
            return methodInfo.Invoke(target, args);
        }
        
        public Object HandlerMethod(Endpoint endpoint,object[] args)
        {
            Object result = endpoint.methodInfo.Invoke(endpoint.Controller, args);
            
            //格式化数据输出: 根据result.dataType
            return result;
        }
        
        
        
    }
}