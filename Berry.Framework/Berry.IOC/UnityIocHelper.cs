using Berry.Util;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;

namespace Berry.IOC
{
    /// <summary>
    /// 描 述：UnityIoc
    /// </summary>
    public sealed class UnityIocHelper : IServiceProvider
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// 获取DbContainer
        /// </summary>
        private static readonly UnityIocHelper Dbinstance = new UnityIocHelper("DbContainer");

        /// <summary>
        /// 获取DbContainer对象
        /// </summary>
        public static UnityIocHelper DbInstance => Dbinstance;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="containerName"></param>
        private UnityIocHelper(string containerName)
        {
            try
            {
                UnityConfigurationSection section = ConfigHelper.GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
                _container = new UnityContainer();
                section.Configure(_container, containerName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //section.Configure(_container);
        }

        /// <summary>
        /// 获取配置节点的mapTo
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="itype"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetmapToByName(string containerName, string itype, string name = "")
        {
            try
            {
                UnityConfigurationSection section = ConfigHelper.GetSection<UnityConfigurationSection>(UnityConfigurationSection.SectionName);
                ContainerElementCollection containers = section.Containers;

                foreach (var container in containers)
                {
                    if (container.Name == containerName)
                    {
                        RegisterElementCollection registrations = container.Registrations;
                        foreach (var registration in registrations)
                        {
                            if (name == "" && string.IsNullOrEmpty(registration.Name) && registration.TypeName == itype)
                            {
                                string mapToName = registration.MapToName;
                                return mapToName;
                            }
                        }
                        break;
                    }
                }
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }

        public T GetService<T>(params ResolverOverride[] parameter)
        {
            T res = _container.Resolve<T>(parameter);
            return res;
        }

        public T GetService<T>(string name, params ResolverOverride[] obj)
        {
            return _container.Resolve<T>(name, obj);
        }
    }
}