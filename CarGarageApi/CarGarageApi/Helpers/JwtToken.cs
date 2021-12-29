using CarGarageApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarGarageApi.Helpers
{
    public class JwtToken
    {
        private readonly string _secretKey;

        public JwtToken(IOptions<JwtSettings> JwtSettings)
        {
            _secretKey = JwtSettings.Value.SecretKey;
        }        

        public string GenerateJwtToken()
        {
            SymmetricSecurityKey SIGNING_KEY = new(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.UtcNow.AddDays(1);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"sub", "testSubject" },
                {"Name", "George" },
                {"email", "fr33k3r@yahoo.com" },
                {"exp", ts },
                {"iss", "https://localhost:7072" }, //Client
                {"aud", "https://localhost:7072" } //Server
            };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();   
            var tokenString = handler.WriteToken(secToken);

            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;

        }
    }
}
