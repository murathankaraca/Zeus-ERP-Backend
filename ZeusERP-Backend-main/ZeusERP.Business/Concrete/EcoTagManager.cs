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
    public class EcoTagManager : IEcoTagService
    {
        private IECOTagDao _ecoTagDao;

        public EcoTagManager(IECOTagDao ecoTagDao)
        {
            _ecoTagDao = ecoTagDao;
        }
        public IDataResult<IList<ECOTag>> GetList()
        {
            return new SuccessDataResult<IList<ECOTag>>(_ecoTagDao.GetList());
        }

        public async Task<IDataResult<IList<ECOTag>>> GetListAsync()
        {
            var ecoTags = await _ecoTagDao.GetListAsync();
            return new SuccessDataResult<IList<ECOTag>>(ecoTags);
        }

        public IDataResult<ECOTag> GetById(int id)
        {
            return new SuccessDataResult<ECOTag>(_ecoTagDao.Get(p => p.Id == id));
        }

        public async Task<IDataResult<ECOTag>> GetByIdAsync(int id)
        {
            var ecoTag = await _ecoTagDao.GetAsync(p => p.Id == id);
            return new SuccessDataResult<ECOTag>(ecoTag);
        }

        public IResult Add(ECOTag ecoTag)
        {
            _ecoTagDao.Add(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public async Task<IResult> AddAsync(ECOTag ecoTag)
        {
            await _ecoTagDao.AddAsync(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public IResult Update(ECOTag ecoTag)
        {
            _ecoTagDao.Update(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public async Task<IResult> UpdateAsync(ECOTag ecoTag)
        {
            await _ecoTagDao.UpdateAsync(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public IResult Delete(ECOTag ecoTag)
        {
            _ecoTagDao.Delete(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }

        public async Task<IResult> DeleteAsync(ECOTag ecoTag)
        {
            await _ecoTagDao.DeleteAsync(ecoTag);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
    }
}
