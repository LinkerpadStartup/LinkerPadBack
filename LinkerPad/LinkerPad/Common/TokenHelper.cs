using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using LinkerPad.Data;
using LinkerPad.Models.UserInfo;

namespace LinkerPad.Common
{
    public class TokenHelper : JwtSecurityTokenHandler, ITokenHelper
    {
        private string UserToken => HttpContext.Current.Request.Cookies["UID"]?.Value;

        public bool IsTokenValid(string token)
        {
            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();

            try
            {
                var result = ValidateSignature(token, tokenValidationParameters);

                if (result.ValidTo <= DateTime.UtcNow)
                {
                    //expired token
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                //token is not valid!
                return false;
            }
        }

        public CurrentUserInfo GetUserInfo()
        {
            try
            {
                TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
                Dictionary<string, string> userDataDictionary = ValidateSignature(UserToken, tokenValidationParameters).Payload.ToDictionary(pair => pair.Key, pair => pair.Value.ToString());

                return new CurrentUserInfo
                {
                    Id = Guid.Parse(userDataDictionary["nameid"]),
                    FirstName = userDataDictionary["unique_name"],
                    LastName = userDataDictionary["family_name"],
                    Username = userDataDictionary["given_name"],
                    Email = userDataDictionary["email"],
                    MobileNumber = userDataDictionary["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone"],
                    FaraUserToken = userDataDictionary["primarysid"],
                    FaraUserId = userDataDictionary["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"]
                };
            }
            catch (Exception)
            {
                //igonre exception 
                return null;
            }
        }

        public void CreateCookie(UserData userData)
        {
            HttpContext.Current.Response.Cookies["UID"].Value = CreateToken(userData);
            HttpContext.Current.Response.Cookies["UID"].Expires = DateTime.Now.AddHours(2);
            HttpContext.Current.Response.Cookies["UID"].HttpOnly = true;
        }

        public void ExpireUserCookie()
        {
            if (HttpContext.Current.Request.Cookies["UID"] == null)
                return;

            HttpCookie c = new HttpCookie("UID")
            {
                Expires = DateTime.Now.AddDays(-1)
            };

            HttpContext.Current.Response.Cookies.Add(c);
        }

        private string CreateToken(UserData userData)
        {
            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtPrivateKey"]));

            var signingCredentials = new SigningCredentials(signingKey,
                SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userData.UserId.ToString()),
                new Claim(ClaimTypes.Surname, userData.LastName),
                new Claim(ClaimTypes.Name, userData.FirstName),
                new Claim(ClaimTypes.GivenName, userData.Username),
                new Claim(ClaimTypes.Email, userData.Email),
                new Claim(ClaimTypes.MobilePhone, userData.MobileNumber),
                new Claim(ClaimTypes.PrimarySid , userData.FaraUserToken),
                new Claim(ClaimTypes.Sid , userData.FaraUserId)
            }, "normalUser");

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                AppliesToAddress = ConfigurationManager.AppSettings["ValidAudience"],
                TokenIssuerName = ConfigurationManager.AppSettings["ValidIssuer"],
                Subject = claimsIdentity,
                SigningCredentials = signingCredentials,
                Lifetime = new Lifetime(DateTime.UtcNow, DateTime.UtcNow.AddHours(2))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(plainToken);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["JwtPrivateKey"]));

            return new TokenValidationParameters
            {
                ValidAudience = ConfigurationManager.AppSettings["ValidAudience"],

                ValidIssuer = ConfigurationManager.AppSettings["ValidIssuer"],

                IssuerSigningKey = signingKey
            };
        }
    }
}