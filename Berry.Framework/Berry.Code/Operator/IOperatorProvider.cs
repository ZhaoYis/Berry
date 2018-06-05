namespace Berry.Code.Operator
{
    /// <summary>
    /// 当前操作者会话接口
    /// </summary>
    public interface IOperatorProvider
    {
        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        void AddCurrent(OperatorEntity user);

        /// <summary>
        /// 获取当前用户基础信息
        /// </summary>
        /// <returns></returns>
        OperatorEntity Current();
        
        /// <summary>
        /// 删除当前用户
        /// </summary>
        void EmptyCurrent();

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        bool IsOverdue();

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        int IsOnLine();
    }
}