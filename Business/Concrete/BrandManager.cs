﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;
		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}
		public IResult Add(Brand brand)
		{
			if (brand.Name.Length <= 2)
			{
				return new ErrorResult(Messages.NameInvalid);
			}

			_brandDal.Add(brand);

			return new Result(true, Messages.BrandAdded);
		}

		public IResult Delete(Brand brand)
		{
			_brandDal.Delete(brand);

			return new Result(true);
		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
		}

		public IDataResult<Brand> GetById(int brandId)
		{
			return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
		}

		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new Result(true);
		}
	}
}
