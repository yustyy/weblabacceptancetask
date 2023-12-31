﻿using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
	public interface IOperationClaimService
	{
        IDataResult<OperationClaim> GetById(int id);

        IDataResult<OperationClaim> GetByName(string name);

        IDataResult<List<OperationClaim>> GetAll();

        IResult Add(OperationClaim operationClaim);

        IResult Update(OperationClaim operationClaim);

        IResult Delete(OperationClaim operationClaim);

    }
}

