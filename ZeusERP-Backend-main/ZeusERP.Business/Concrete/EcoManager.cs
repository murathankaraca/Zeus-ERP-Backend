using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class EcoManager : IECOService
    {
        private IECODao _ecoDao;
        //private IUserService _userManager;

        public EcoManager(IECODao ecoDao)
        {
            _ecoDao = ecoDao;
        }

        public IDataResult<IList<EngineeringChangeOrder>> GetList()
        {
            return new SuccessDataResult<IList<EngineeringChangeOrder>>(_ecoDao.GetList());
        }

        public async Task<IDataResult<IList<EngineeringChangeOrder>>> GetListAsync()
        {
            var ecos = await _ecoDao.GetListAsync();
            return new SuccessDataResult<IList<EngineeringChangeOrder>>(ecos);
        }

        public IDataResult<EngineeringChangeOrder> GetById(int id)
        {
            return new SuccessDataResult<EngineeringChangeOrder>(_ecoDao.Get(p => p.Id == id));
        }

        public async Task<IDataResult<EngineeringChangeOrder>> GetByIdAsync(int id)
        {
            var eco = await _ecoDao.GetAsync(p => p.Id == id);
            return new SuccessDataResult<EngineeringChangeOrder>(eco);
        }

        public IResult Add(EngineeringChangeOrder eco)
        {
            _ecoDao.Add(eco);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public async Task<IResult> AddAsync(EngineeringChangeOrder eco)
        {
            await _ecoDao.AddAsync(eco);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public IResult Update(EngineeringChangeOrder eco)
        {
            _ecoDao.Update(eco);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public async Task<IResult> UpdateAsync(EngineeringChangeOrder eco)
        {
            await _ecoDao.UpdateAsync(eco);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public IResult Delete(EngineeringChangeOrder eco)
        {
            _ecoDao.Delete(eco);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }

        public async Task<IResult> DeleteAsync(EngineeringChangeOrder eco)
        {
            await _ecoDao.DeleteAsync(eco);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }

        public IDataResult<ECODetailsDto> GetEcoDetailsById(int ecoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<ECODetailsDto>> GetEcoDetailsByIdAsync(int ecoId)
        {
            throw new NotImplementedException();
        }
    }
}
