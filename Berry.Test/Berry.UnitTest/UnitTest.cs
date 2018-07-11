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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using AutoMapper;
using Berry.App.Cache;
using Berry.Cache;
using Berry.Entity;
using Berry.Extension;
using Berry.UnitTest.Model;

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

            //RedisTest();

            MapToTest();
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

        [TestMethod]
        private void MapToTest()
        {
            UserInfo userInfo = new UserInfo
            {
                PK = 1,
                UserId = "2018001",
                RealName = "大师兄",
                DepartmentId = "001",
                DepartmentName = "技术部",
                Sex = 1,
                UserOnLine = 1,
                CreateTime = DateTime.Now,
                Age = 10
            };

            IEnumerable<UserInfo> userInfos = new List<UserInfo>
            {
                new UserInfo
                {
                    PK = 1,
                    UserId = "2018001",
                    RealName = "MrZhaoYi",
                    DepartmentId = "001",
                    DepartmentName = "技术部",
                    Sex = 1,
                    UserOnLine = 1,
                    CreateTime = DateTime.Now
                },
                new UserInfo
                {
                    PK = 2,
                    UserId = "2018002",
                    RealName = "MrZhaoYi2",
                    DepartmentId = "002",
                    DepartmentName = "技术部",
                    Sex = 1,
                    UserOnLine = 1,
                    CreateTime = DateTime.Now
                }
            };

            DataTable dataTable = new DataTable("MyTable");
            DataColumn column = new DataColumn("UserId", typeof(string));
            dataTable.Columns.Add(column);

            DataRow dr = dataTable.NewRow();
            dr["UserId"] = "003";
            dataTable.Rows.Add(dr);

            UserInfoDTO dto1 = userInfo.MapTo<UserInfoDTO>();

            UserInfoDTO dto2 = userInfo.MapTo<UserInfo, UserInfoDTO>();

            List<UserInfoDTO> userInfoDtos1 = userInfos.MapTo<UserInfo, UserInfoDTO>();

            List<UserInfoDTO> userInfoDtos2 = userInfos.MapTo<UserInfoDTO>();

            List<UserInfoDTO> userInfoDtos3 = dataTable.MapTo<UserInfoDTO>();

            //viewmodel与实体字段名字没有全部对应，只有几个字段的名字和源实体中的字段名字是一样的，其他的字段是通过实体中的几个字段组合或者是格式或者是类型转化而来的
            //var config2 = new MapperConfiguration(
            //    cfg => cfg.CreateMap<UserInfo, UserInfoDTO>()
            //        .ForMember(d => d.UID, opt => opt.MapFrom(s => s.PK))  //指定字段一一对应
            //        .ForMember(d => d.AddTime, opt => opt.MapFrom(src => src.CreateTime.ToString("yy-MM-dd")))//指定字段，并转化指定的格式
            //        .ForMember(d => d.Age, opt => opt.Condition(src => src.Age > 5))//条件赋值
            //        .ForMember(d => d.DepartmentName, opt => opt.Ignore())//忽略该字段，不给该字段赋值
            //        .ForMember(d => d.RealName, opt => opt.NullSubstitute("Default Value"))//如果源字段值为空，则赋值为 Default Value
            //        .ForMember(d => d.Ex, opt => opt.MapFrom(src => src.PK + "_" + src.UserId + "_" + src.RealName)));//可以自己随意组合赋值
            //var mapper2 = config2.CreateMapper();
            //UserInfoDTO dto1 = mapper2.Map<UserInfoDTO>(userInfo);

            //Console.WriteLine(dto1.RealName);
        }
    }
}