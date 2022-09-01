using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Streamye.DesignPattern.IOC.Attribute;

namespace Microsoft.Streamye.DesignPattern.IOC
{
    public class IOCFactory
    {
        //1. 容器
        private IDictionary<string, Object> iocContainer = new Dictionary<string, Object>();

        private IDictionary<string, Object> iocEarlyContainer = new Dictionary<string, Object>();
        
        //iocservice 的type 容器
        private IDictionary<string, Type> iocTypeContainer = new Dictionary<string, Type>();
        
        //scope容器
        private IDictionary<string, Object> iocScopeContainer = new Dictionary<string, Object>();
        public IOCFactory()
        {
            //2. 获得所有对象，并创建类型
            Assembly assembly = Assembly.Load("Microsoft.Streamye.DesignPattern");
            Type[] types = assembly.GetTypes();
            // foreach (var type in types)
            // {
            //     Object _object = Activator.CreateInstance(type);
            //     
            //     //更进一步：
            //     var properties = type.GetProperties();
            //     foreach (var propertyInfo in properties)
            //     {
            //         Type type1 = propertyInfo.PropertyType;
            //         Object _objectValue = Activator.CreateInstance(type1);
            //         propertyInfo.SetValue(_object,_objectValue);
            //     }
            //     //问题：循环3层，太多，而且没法解决递归嵌套着的属性
            //     
            //     
            //     iocContainer.Add(type.FullName, _object);
            // }
            foreach (var type in types)
            {
                IOCService iocService = type.GetCustomAttribute<IOCService>();
                if(iocService!=null)
                {

                    iocTypeContainer[type.FullName] = type;
                    // Object _object = CreateObject(type,types);
                    // iocContainer.Add(type.FullName, _object);
                }
            }
            // 问题：1. 如果对象中还有其他需要注入的属性怎么办？ 这儿只有一层 
            // 问题: 2. 性能太差， 过滤：只有特定attribute的才创建
            
            
        }

        public Object CreateObject(Type type)
        {
            if (iocContainer.ContainsKey(type.FullName))
            {
                return iocContainer[type.FullName];
            }

            //解决循环问题：
            if (iocEarlyContainer.ContainsKey(type.FullName))
            {
                return iocEarlyContainer[type.FullName];
            }

            Object _object = Activator.CreateInstance(type);
            iocEarlyContainer[type.FullName] = _object;
            
            //aop方法塞进去

            //更进一步：
            var properties = type.GetProperties();
            foreach (var propertyInfo in properties)
            {
                Type type1 = propertyInfo.PropertyType;
                // Object _objectValue = Activator.CreateInstance(type1);
                Object _objectValue = CreateObject(type1); //递归调用
                
                propertyInfo.SetValue(_object,_objectValue);
            }
            
            //问题： 循环依赖，这个递归就无法停止

            return _object;
        }

        //问题：如果有几百万的对象一次性创建会非常慢 =》 懒加载
        //问题：循环依赖：半成品的方式强制截断
        //问题：生命周期：单例(这种存储起来的方式就实现了单例)，scope（每次用完就释放了）, transient(不存dict)
        //问题：想有选择的注入属性，
        //问题：AOP 
        public Object GetObject<T>()
        {
            string fullname = typeof(T).FullName;
            if (iocContainer.ContainsKey(fullname))
            {
                return iocContainer[fullname];
            }

            if (iocTypeContainer.ContainsKey(fullname))
            {
                Object o= CreateObject(typeof(T));
                iocContainer[fullname] = o;
            }
            
            //删除半成品
            if (iocEarlyContainer.ContainsKey(fullname))
            {
                iocEarlyContainer.Remove(fullname);
            }
            
            //AOP 增加一个函数
            
            
            //如果还是没有则返回空
            if (!iocContainer.ContainsKey(fullname))
            {
                return null;
            }

            return iocContainer[fullname];
        }

        public void AddAOPMethod(Type type)
        {
            var methodInfos = type.GetMethods();
            // methodInfos.
        }

        public void ReleaseObject<T>()
        {
            string fullname = typeof(T).FullName;
            if (iocScopeContainer.ContainsKey(fullname))
            {
                iocScopeContainer.Remove(fullname);
            }
        }
    }
}