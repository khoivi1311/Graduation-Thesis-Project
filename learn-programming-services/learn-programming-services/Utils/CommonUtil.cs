using learn_programming_services.Database.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace learn_programming_services.Utils
{
    public class CommonUtil : ICommonUtil
    {
        private readonly IConfiguration _configuration;

        public CommonUtil(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> totalPages(int pageSize, int totalList)
        {
            if(totalList % pageSize == 0)
            {
                return totalList / pageSize;
            }

            return (totalList / pageSize) + 1;
        }
    }
}
