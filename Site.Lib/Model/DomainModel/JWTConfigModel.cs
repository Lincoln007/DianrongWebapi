using System.Security.Cryptography;

namespace Site.Lib.Model.DomainModel
{
    /// <summary>
    /// 
    /// </summary>
    public class JWTConfigModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RSA SecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Issuer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Audience { get; set; }
        
    }
}