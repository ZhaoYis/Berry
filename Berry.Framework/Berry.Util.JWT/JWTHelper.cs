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
        /// 私钥
        /// </summary>
        private static string TokenPrivateKey;
        static JWTHelper()
        {
            string path = DirFileHelper.MapPath("SecretKey\\token.privateKey.key");
            string key = DirFileHelper.ReadAllText(path);
            TokenPrivateKey = key;
        }

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
            DateTime time = DateTime.Now.AddMinutes(120);
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
                }, time);
            }
            else
            {
                //计算Token
                token = CacheFactory.GetCacheInstance().GetCache(string.Format("JWT_TokenCacheKey:{0}", playload.aud), () =>
                {
                    return encoder.Encode(dict, secret);
                }, time);
            }
            return token;
        }

        /// <summary>
        /// 如果Token过期，则马上重新计算
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="account"></param>
        public static void CheckTokenHasExpiry(string userId, string account)
        {
            if (!string.IsNullOrEmpty(userId) && userId.Equals("guest"))
            {
                bool has = CacheFactory.GetCacheInstance().HasExpire("JWT_TokenCacheKey:Guest");
                if (has)
                {
                    JWTPlayloadInfo playload = new JWTPlayloadInfo
                    {
                        iss = "S_COMMON_TOKTN",
                        sub = account,
                        aud = userId,
                        userid = CommonHelper.GetGuid(),
                        extend = "PUBLIC_TOKTN"
                    };
                    GetToken(playload);
                }
            }
            else
            {
                bool has = CacheFactory.GetCacheInstance().HasExpire(string.Format("JWT_TokenCacheKey:{0}", userId));
                if (has)
                {
                    JWTPlayloadInfo playload = new JWTPlayloadInfo
                    {
                        iss = "S_USER_TOKTN",
                        sub = account,
                        aud = userId,
                        userid = CommonHelper.GetGuid(),
                        extend = "USER_TOKTN"
                    };
                    GetToken(playload);
                }
            }
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
            try
            {
                JWTPlayloadInfo playload = decoder.DecodeToObject<JWTPlayloadInfo>(token, secret, true);
                if (playload != null)
                {
                    if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals("guest"))
                    {
                        string cacheToken = CacheFactory.GetCacheInstance().GetCache<string>("JWT_TokenCacheKey:Guest");

                        return Check(playload, cacheToken, token) ? playload : null;
                    }
                    else
                    {
                        string cacheToken = CacheFactory.GetCacheInstance().GetCache<string>(string.Format("JWT_TokenCacheKey:{0}", playload.aud));
                        return Check(playload, cacheToken, token) ? playload : null;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        private static bool Check(JWTPlayloadInfo playload, string cacheToken, string token)
        {
            if (string.IsNullOrEmpty(cacheToken)) return false;
            if (string.IsNullOrEmpty(token)) return false;
            if (!cacheToken.Equals(token)) return false;

            //Token过期
            DateTime exp = DateTimeHelper.GetDateTime(playload.exp);
            if (DateTime.Now > exp)
            {
                if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals("guest"))
                {
                    CacheFactory.GetCacheInstance().RemoveCache("JWT_TokenCacheKey:Guest");
                }
                else
                {
                    CacheFactory.GetCacheInstance().RemoveCache(string.Format("JWT_TokenCacheKey:{0}", playload.aud));
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
            return TokenPrivateKey;
        }
    }
}