using learn_programming_services.Apis.Authentications.Dtos;
using learn_programming_services.Businesses.Functions.Authentications;
using learn_programming_services.Database.Entity;
using learn_programming_services.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace learn_programming_services.Businesses.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly ICommonUtil _commonUtil;
        private readonly IUsersServices _usersServices;
        private readonly IUserPermissionsServices _userPermissionsServices;
        private readonly IUserTokensServices _userTokensServices;
        private readonly IConfiguration _configuration;

        public AuthenticationServices(ICommonUtil commonUtil,
            IUsersServices usersServices,
            IUserPermissionsServices userPermissionsServices,
            IUserTokensServices userTokensServices,
            IConfiguration configuration)
        {
            _commonUtil = commonUtil;
            _usersServices = usersServices;
            _userPermissionsServices = userPermissionsServices;
            _userTokensServices = userTokensServices;
            _configuration = configuration;
        }

        public async Task<IRegisterFunction.Response> Register(IRegisterFunction.Request request)
        {
            List<string> errorMessages = new List<string>();

            if ((request.register.firstName != null && request.register.firstName.Trim() != "") &&
                (request.register.lastName != null && request.register.lastName.Trim() != "") &&
                (request.register.userName != null && request.register.userName.Trim() != "") &&
                (request.register.email != null && request.register.email.Trim() != "") &&
                (request.register.password != null && request.register.password.Trim() != "") &&
                (request.register.rePassword != null && request.register.rePassword.Trim() != ""))
            {
                if (checkUserNameValidation(request.register.userName.Trim()))
                {
                    if (checkPasswordValidation(request.register.password))
                    {
                        request.register.userName = request.register.userName.Trim().ToLower();
                        request.register.email = request.register.email.Trim().ToLower();
                        if (request.register.password.Equals(request.register.rePassword))
                        {
                            var userList = await _usersServices.GetAllUsers();

                            foreach (var user in userList)
                            {
                                if (user.UserName.ToLower().Equals(request.register.userName))
                                {
                                    errorMessages.Add("Username already exists");
                                }
                                if (user.Email.ToLower().Equals(request.register.email))
                                {
                                    errorMessages.Add("Email already exists");
                                }
                            }
                        }
                        else
                        {
                            errorMessages.Add("Password and Re-Password do not match");
                        }
                    }
                    else
                    {
                        errorMessages.Add("Invalid password. Password must have at least 8 characters, at least one uppercase letter, one lowercase letter, one number and one special character such as: # ? ! @ $ % ^ & * - , . _");
                    }
                }
                else
                {
                    errorMessages.Add("Invalid username. Username must have at least 8 characters, contain only lowercase letters a-z, numbers 0-9 and special characters such as: - , . _");
                }
            }
            else
            {
                errorMessages.Add("First Name, Last Name, Username, Email, Password and Re-Password cannot be blank");
            }

            if(errorMessages.Count > 0 && errorMessages != null)
            {
                return new IRegisterFunction.Response(false, errorMessages.ToList());
            }
            else
            {
                Users newUser = new Users() {
                    FirstName = request.register.firstName.Trim(),
                    LastName = request.register.lastName.Trim(),
                    UserName = request.register.userName,
                    Email = request.register.email,
                    Password = passwordEncryption(request.register.password),
                    IsDeleted = false,
                    RoleId = 3,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _usersServices.CreateNewUser(newUser);

                var latestUser = await _usersServices.FindLatestUser();

                UserPermissions newUserPermission1 = new UserPermissions()
                {
                    UserId = latestUser.Id,
                    PermissionId = 5,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                UserPermissions newUserPermission2 = new UserPermissions()
                {
                    UserId = latestUser.Id,
                    PermissionId = 6,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                

                await _userPermissionsServices.CreateNewUserPermissions(newUserPermission1);
                await _userPermissionsServices.CreateNewUserPermissions(newUserPermission2);

                return new IRegisterFunction.Response(true, null);
            }
        }

        public async Task<ILoginFunction.Response> Login(ILoginFunction.Request request)
        {
            if ((request.login.userName != null && request.login.userName != "") && (request.login.password != null && request.login.password != ""))
            {
                request.login.userName.Trim();
                request.login.password = passwordEncryption(request.login.password);

                var userList = await _usersServices.GetAllUsers();

                var user = userList.Where(p => p.UserName.Equals(request.login.userName))
                                   .Where(p => p.Password.Equals(request.login.password))
                                   .Where(p => p.IsDeleted.Equals(false))
                                   .SingleOrDefault();

                if (user != null)
                {
                    return new ILoginFunction.Response(true, null, user.Id, user.UserName, await generateToken(user));
                }

                return new ILoginFunction.Response(false, "Invalid username or password", 0, null, null);
            }

            return new ILoginFunction.Response(false, "Username or Password cannot be blank", 0, null, null);
        }

        public async Task<IRefreshTokenFunction.Response> RefreshToken(IRefreshTokenFunction.Request request)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var tokenValidateParam = new TokenValidationParameters()
            {
                //Tu cap Token
                ValidateIssuer = false,
                ValidateAudience = false,

                //Ky vao Token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:secretKey"))),

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false
            };

            try
            {
                //Check AccessToken valid Format
                var tokenInVerification = jwtTokenHandler.ValidateToken(request.token.accessToken, tokenValidateParam, out var validatedToken);

                //Check Althorigm
                if(validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return new IRefreshTokenFunction.Response(false, "Invalid token", null);
                    }
                }

                //Check accessToken expire
                var utcExpireDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = convertUnixTimeToDateTime(utcExpireDate);

                if(expireDate > DateTime.UtcNow)
                {
                    return new IRefreshTokenFunction.Response(false, "Access token has not expired", null);
                }

                //Check refreshToken exist in DB
                var userTokens = await _userTokensServices.GetAllUserTokens();
                var storedToken = userTokens.FirstOrDefault(x => x.RefreshToken.Equals(request.token.refreshToken) && x.AccessToken.Equals(request.token.accessToken));

                if (storedToken == null) 
                {
                    return new IRefreshTokenFunction.Response(false, "Refresh token does not exist", null);
                }

                //Check refreshToken is used/revoked
                if (storedToken.IsUsed)
                {
                    return new IRefreshTokenFunction.Response(false, "Refresh token has been used", null);
                }
                if (storedToken.IsRevoked)
                {
                    return new IRefreshTokenFunction.Response(false, "Refresh token has been revoked", null);
                }

                //Check refreshToken expire
                if(storedToken.ExpiredDate < DateTime.UtcNow)
                {
                    return new IRefreshTokenFunction.Response(false, "Refresh token has expired", null);
                }

                //Check user exist
                var user = await _usersServices.FindUserById(storedToken.UserId);
                if(user == null || user.IsDeleted.Equals(true))
                {
                    return new IRefreshTokenFunction.Response(false, "User does not exist", null);
                }

                //Update refreshToken is used
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                await _userTokensServices.UpdateUserToken(storedToken);

                //Create a new token
                return new IRefreshTokenFunction.Response(true, null, await generateToken(user));
            }
            catch (Exception ex)
            {
                return new IRefreshTokenFunction.Response(false, "Something went wrong", null);
            }
        }

        public async Task<ILogoutFunction.Response> Logout(ILogoutFunction.Request request)
        {
            var userTokens = await _userTokensServices.GetAllUserTokens();
            var storedToken = userTokens.FirstOrDefault(x => x.RefreshToken.Equals(request.token.refreshToken) && x.AccessToken.Equals(request.token.accessToken));

            if (storedToken != null)
            {
                storedToken.IsRevoked = true;
                await _userTokensServices.UpdateUserToken(storedToken);

                return new ILogoutFunction.Response(true, null);
            }

            return new ILogoutFunction.Response(false, "Token does not exist");
        }

        private DateTime convertUnixTimeToDateTime(long utcExpireDate)
        {
            DateTime dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();

            return dateTimeInterval;
        }

        private bool checkPasswordValidation(string password)
        {
            string passwordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#?!@$%^&*-.,_])[A-Za-z\\d#?!@$%^&*-.,_]{8,}$";
            return Regex.IsMatch(password, passwordRegex);
        }

        private bool checkUserNameValidation(string userName)
        {
            string userNameRegex = "^[a-z\\d-.,_]{8,}$";
            return Regex.IsMatch(userName, userNameRegex);
        }

        private string passwordEncryption(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Hashing:key")));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(password);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        private async Task<TokenDto> generateToken(Users user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(JwtRegisteredClaimNames.Name, user.FirstName + " " + user.LastName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Id", user.Id.ToString()),

                    //Roles
                }),

                Expires = DateTime.UtcNow.AddHours(4).AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:secretKey"))), SecurityAlgorithms.HmacSha512Signature)
            };

            TokenDto token = new TokenDto()
            {
                accessToken = jwtTokenHandler.WriteToken(jwtTokenHandler.CreateToken(tokenDescription)),
                refreshToken = generateRefreshToken(user)
            };

            UserTokens userTokens = new UserTokens()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                RefreshToken = token.refreshToken,
                AccessToken = token.accessToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedDate = DateTime.UtcNow,
                ExpiredDate = DateTime.UtcNow.AddHours(5),
            };

            await _userTokensServices.CreateNewUserToken(userTokens);

            return token;
        }

        private string generateRefreshToken(Users user)
        {
            var random = new byte[256];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }
    }
}
