using System;
using System.Collections.Generic;
using Berry.Cache;
using Berry.Extension;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Berry.Util.JWT
{
    /// <summary>
    /// JWT操作帮助类
    /// </summary>
    public sealed class JWTHelper
    {
        /// <summary>
        /// 签发Token
        /// </summary>
        /// <param name="playload">载荷</param>
        /// <returns></returns>
        public static string GetToken(JWTPlayloadInfo playload)
        {
            string token = String.Empty;

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            //设置过期时间
            DateTime time = DateTime.Now.AddMinutes(60);
            playload.exp = DateTimeHelper.GetTimeStamp(time).ToString();
            Dictionary<string, object> dict = playload.Object2Dictionary();
            //获取私钥
            string secret = GetSecret();
            //将Token保存在缓存中
            if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals("guest"))
            {
                //计算公用Token
                token = CacheFactory.GetCacheInstance().GetCache("JWT_TokenCacheKey:Guest", () =>
                {
                    return encoder.Encode(dict, secret);
                });
            }
            else
            {
                //计算Token
                token = CacheFactory.GetCacheInstance().GetCache($"JWT_TokenCacheKey:{playload.aud}", () =>
                {
                    return encoder.Encode(dict, secret);
                });
            }
            return token;
        }

        /// <summary>
        /// Token校验
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static JWTPlayloadInfo CheckToken(string token)
        {
            if (string.IsNullOrEmpty(token)) return null;

            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);

            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            //获取私钥
            string secret = GetSecret();
            JWTPlayloadInfo playloadInfo = decoder.DecodeToObject<JWTPlayloadInfo>(token, secret, true);
            if (playloadInfo != null)
            {
                if (!string.IsNullOrEmpty(playloadInfo.aud) && playloadInfo.aud.Equals("guest"))
                {
                    string cacheToken = CacheFactory.GetCacheInstance().GetCache<string>("JWT_TokenCacheKey:Guest");

                    return Check(playloadInfo, cacheToken, token) ? playloadInfo : null;
                }
                else
                {
                    string cacheToken = CacheFactory.GetCacheInstance().GetCache<string>($"JWT_TokenCacheKey:{playloadInfo.aud}");
                    return Check(playloadInfo, cacheToken, token) ? playloadInfo : null;
                }
            }
            return null;
        }

        private static bool Check(JWTPlayloadInfo info, string cacheToken,string token)
        {
            if (string.IsNullOrEmpty(cacheToken)) return false;
            if (string.IsNullOrEmpty(token)) return false;
            if (!cacheToken.Equals(token)) return false;

            //Token过期
            DateTime exp = DateTimeHelper.GetDateTime(info.exp);
            if (DateTime.Now > exp)
            {
                if (!string.IsNullOrEmpty(info.aud) && info.aud.Equals("guest"))
                {
                    CacheFactory.GetCacheInstance().RemoveCache("JWT_TokenCacheKey:Guest");
                }
                else
                {
                    CacheFactory.GetCacheInstance().RemoveCache($"_JWT_TokenCacheKey:{info.aud}");
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取私钥
        /// </summary>
        /// <returns></returns>
        private static string GetSecret()
        {
            //TODO 从文件中去读真正的私钥
            return "{5E094D22-1849-46A9-A253-41DAAD244252}";
        }
    }
}