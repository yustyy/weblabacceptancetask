using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
	public interface IUserOperationClaimService
	{

        IDataResult<UserOperationClaim> GetById(int id);

        IDataResult<List<UserOperationClaim>> GetAll();

        IResult AddUserClaim(User user);

        IResult Add(UserOperationClaim userOperationClaim);

        IResult Update(UserOperationClaim userOperationClaim);

        IResult Delete(UserOperationClaim userOperationClaim);

    }
}

