namespace Berry.App.CacheRefresh.Job
{
    public class JobHelper
    {
        protected RedisRefreshHelper reHelper;

        protected JobHelper()
        {
            reHelper = new RedisRefreshHelper();
        }
    }
}