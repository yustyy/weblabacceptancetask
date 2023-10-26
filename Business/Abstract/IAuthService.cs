using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
	public interface IAuthService
	{

		IDataResult<User> Login(UserForLoginDto userForLoginDto);
		IDataResult<User> Register(UserForRegisterDto userForRegisterDto);

		IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult IsAuthenticated(string userMail, List<string> requiredRoles);



    }
}

