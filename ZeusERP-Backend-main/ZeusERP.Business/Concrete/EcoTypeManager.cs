using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Concrete
{
    public class EcoTypeManager : IEcoTypeService
    {
        private IECOTypeDao _ecoTypeDao;

        public EcoTypeManager(IECOTypeDao ecoTypeDao)
        {
            _ecoTypeDao = ecoTypeDao;
        }
        public IDataResult<IList<ECOType>> GetList()
        {
            return new SuccessDataResult<IList<ECOType>>(_ecoTypeDao.GetList());
        }

        public async Task<IDataResult<IList<ECOType>>> GetListAsync()
        {
            var ecoTypes = await _ecoTypeDao.GetListAsync();
            return new SuccessDataResult<IList<ECOType>>(ecoTypes);
        }

        public IDataResult<ECOType> GetById(int id)
        {
            return new SuccessDataResult<ECOType>(_ecoTypeDao.Get(p => p.Id == id));
        }

        public async Task<IDataResult<ECOType>> GetByIdAsync(int id)
        {
            var ecoType = await _ecoTypeDao.GetAsync(p => p.Id == id);
            return new SuccessDataResult<ECOType>(ecoType);
        }

        public IResult Add(ECOType ecoType)
        {
            _ecoTypeDao.Add(ecoType);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public async Task<IResult> AddAsync(ECOType ecoType)
        {
            await _ecoTypeDao.AddAsync(ecoType);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public IResult Update(ECOType ecoType)
        {
            _ecoTypeDao.Update(ecoType);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public async Task<IResult> UpdateAsync(ECOType ecoType)
        {
            await _ecoTypeDao.UpdateAsync(ecoType);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public IResult Delete(ECOType ecoType)
        {
            _ecoTypeDao.Delete(ecoType);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }

        public async Task<IResult> DeleteAsync(ECOType ecoType)
        {
            await _ecoTypeDao.DeleteAsync(ecoType);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
    }
}
