using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CarGarageApi.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "q8lKoxA5b1fSq3pfNx3 - sOXr9W_piOj6tRULw5hU8lhKbFSqx4xFuJ4YsFMAgVvZuE1VSZQ2toVhkKRUIL9pHzWP__OczZxrut5etH3s_UfxRSEKufDJmdUjF3KynwT2TeVkRQlEfyd4MkL67BmCo5wZe_wYJt4qi85ECYKZVzKuV90PLPVA3mDWAXViRNVa_cXP2IpRSgUpS4wSZgeGps--VE - zuj6gJuh0YEYUyXDMnrIUsEEXo31RBYYT9fNec3TifZzOECWFmeEp6fqMU9U5p527RVp1ioSXORXd0oZ2MnlnYsRUPvIz5Z21 - r9_j6fajruyWmjDH7NP1tBOWw";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

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
