using System;
using System.Data;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;

        private ITokenHelper _tokenHelper;

        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;

            _tokenHelper = tokenHelper;

            _userOperationClaimService = userOperationClaimService;
        }



        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }


        public IResult IsAuthenticated(string userMail, List<string> requiredRoles)
        {
            if (requiredRoles != null)
            {
                var user = _userService.GetByMail(userMail).Data;
                var userClaims = _userService.GetClaims(user).Data;
                var doesUserHaveRequiredRoles = requiredRoles.All(r => userClaims.Select(userClaim => userClaim.Name).Contains(r));
                if (!doesUserHaveRequiredRoles)
                {
                    return new ErrorResult(Messages.AuthorizationDenied);
                }
            }

            return new SuccessResult();
        }



        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {

                return new ErrorDataResult<User>(Messages.UserNotFound);

            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var newUser = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt

            };

            _userService.Add(newUser);
            var user = _userService.GetByMail(newUser.Email).Data;
            //userclaims will be added here with user
            _userOperationClaimService.AddUserClaim(user);

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult(Messages.UserDoesntExists);
        }
    }
}

