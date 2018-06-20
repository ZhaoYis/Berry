using Berry.BLL.BaseManage;
using Berry.Data;
using Berry.Entity.BaseManage;
using Berry.Log;
using Berry.Util;
using Berry.Util.Stopwatch;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Berry.App.Cache;
using Berry.Cache;
using Berry.Entity;

namespace Berry.UnitTest
{
    /// <summary>
    /// 系统单元测试
    /// </summary>
    [TestClass]
    public class UnitTest : BaseStopwatch
    {
        private UserBLL _userBll = new UserBLL();

        [TestMethod]
        public void TestMethod()
        {
            Console.WriteLine("==================测试开始==================\r\n");

            bool isConn = CommonHelper.IsConnectedInternet();

            //LogTest();

            //IocTest();

            //InsertTest(2);

            //InsertListTest(5000 * 10);

            //QueryTest();

            //RsaTest();

            RedisTest();
        }

        [TestMethod]
        private void LogTest()
        {
            Console.WriteLine("开始测试日志...\r\n");
            LogHelper logHelper = new LogHelper(typeof(UnitTest));
            logHelper.Info("测试日志.");
        }

        [TestMethod]
        private void IocTest()
        {
            try
            {
                IUnityContainer _container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
                _container = new UnityContainer();
                section.Configure(_container, "DbContainer");

                //_container.RegisterType<IDatabase, Database>();

                //IDatabase database = _container.Resolve<IDatabase>();

                ResolverOverride parConnStr = new ParameterOverride("connString", "MsSqlBaseDbConnectionString");
                ResolverOverride parDbType = new ParameterOverride("dbType", "");
                IDatabase database = _container.Resolve<IDatabase>(parConnStr, parDbType);

                int res = database.ExecuteBySql("SELECT COUNT(*) FROM sys.dm_os_hosts");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod]
        private void InsertTest(int toatl = 10)
        {
            Console.WriteLine("\r\n开始测试插入数据...\r\n");

            string time = Stopwatch(() =>
            {
                for (int i = 1; i < toatl; i++)
                {
                    string time2 = Stopwatch(() =>
                    {
                        string key = Guid.NewGuid().ToString().Replace("-", "");

                        string md5 = Md5Helper.Md5("123456");

                        string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));

                        UserEntity user = new UserEntity
                        {
                            Account = "System" + i,
                            NickName = "大师兄" + i,
                            Birthday = DateTime.Now.AddDays(-1000),
                            Secretkey = key,
                            Password = realPassword,
                            Gender = 1,
                            SortCode = i
                            //RoleId = CommonHelper.GetGuid()
                        };
                        user.Create();

                        ////表名
                        //string table = EntityAttributeHelper.GetEntityTable<UserEntity>();
                        ////获取不做映射的字段
                        //List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<UserEntity>();

                        bool res = _userBll.AddUser(user);
                    });

                    Console.WriteLine("开始测试" + i + "，耗时：" + time2);
                }
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }

        [TestMethod]
        private void InsertListTest(int toatl = 10)
        {
            Console.WriteLine("\r\n开始测试批量插入数据...\r\n");

            List<UserEntity> list = new List<UserEntity>();
            for (int i = 1; i < toatl; i++)
            {
                string key = Guid.NewGuid().ToString().Replace("-", "");

                string md5 = Md5Helper.Md5("123456");

                string realPassword = Md5Helper.Md5(DESEncryptHelper.Encrypt(md5, key));

                UserEntity user = new UserEntity
                {
                    Id = Guid.NewGuid().ToString().Replace("-", ""),
                    Account = "dashixiong" + i,
                    NickName = "大师兄" + i,
                    Birthday = DateTime.Now.AddDays(-1000),
                    Secretkey = key,
                    Password = realPassword
                };
                user.Create();

                list.Add(user);
            }

            Console.WriteLine("\r\n初始化数据完成...\r\n");

            string time = Stopwatch(() =>
            {
                _userBll.AddUser(list);
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }

        [TestMethod]
        private void QueryTest()
        {
            Console.WriteLine("\r\n开始测试查询数据...\r\n");

            string time = Stopwatch(() =>
            {
                List<UserEntity> res = _userBll.QueryUserList(u => u.DeleteMark == false);

                Console.WriteLine("共得到数据：" + res.Count + "条");
            });

            Console.WriteLine("执行结束，耗时：" + time);
        }

        [TestMethod]
        private void RsaTest()
        {
            var key = RSAEncryptHelper.GetRSAKey();
            Console.WriteLine("PublicKey：" + key.PublicKey + "\r\n");
            Console.WriteLine("PrivateKey：" + key.PrivateKey + "\r\n");

            string source = @"RSAEncryptHelper";
            if (RSAEncryptHelper.CheckSourceValidate(source))
            {
                string e = RSAEncryptHelper.EncryptString(source, key.PublicKey);
                Console.WriteLine("加密后：" + e + "\r\n");

                string d = RSAEncryptHelper.DecryptString(e, key.PrivateKey);
                Console.WriteLine("解密后：" + d);
            }
        }

        [TestMethod]
        private void RedisTest()
        {
            RedisHelper redis = new RedisHelper();
            List<string> keys = redis.GetKeys();

            Console.WriteLine("__TestBaseEntityKey是否存储：" + redis.KeyExists("__TestBaseEntityKey") + "\r\n");

            keys.ForEach(k =>
            {
                bool e = redis.KeyExists(k);
                Console.WriteLine(k + "是否存储：" + e + "\r\n");
            });
            Console.WriteLine("===========================");

            DataItemCache dataItem = new DataItemCache();
            var res = dataItem.GetDataItemList();
            Console.WriteLine("res:" + res.Count());

            Console.WriteLine("===========================");
            BaseEntity cache = CacheFactory.GetCacheInstance().GetCache<BaseEntity>("__TestBaseEntityKey");
            if (cache == null)
            {
                cache = new BaseEntity
                {
                    Id = "123",
                    PK = 1
                };
                CacheFactory.GetCacheInstance().WriteCache<BaseEntity>(cache, "__TestBaseEntityKey");
            }
            Console.WriteLine(cache.Id);
        }
    }
}