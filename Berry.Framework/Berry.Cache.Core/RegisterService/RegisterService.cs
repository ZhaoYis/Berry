namespace Berry.Cache.Core.RegisterService
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public class RegisterService : IRegisterService
    {
        private RegisterService()
        {
        }

        /// <summary>
        /// 开始注册
        /// </summary>
        /// <returns></returns>
        public static IRegisterService Start()
        {
            return new RegisterService();
        }
    }
}