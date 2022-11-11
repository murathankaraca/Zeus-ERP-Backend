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
    public class OrderUnbuildManager : IOrderUnbuildService
    {
        private IOrderUnbuildDao _unbuildDao;
        public OrderUnbuildManager(IOrderUnbuildDao unbuildDao)
        {
            _unbuildDao = unbuildDao;
        }
        public IDataResult<IList<Unbuild>> GetList()
        {
            return new SuccessDataResult<IList<Unbuild>>(_unbuildDao.GetList());
        }

        public async Task<IDataResult<IList<Unbuild>>> GetListAsync()
        {
            var orders = await _unbuildDao.GetListAsync();
            return new SuccessDataResult<IList<Unbuild>>(orders);
        }

        public IDataResult<Unbuild> GetById(int id)
        {
            return new SuccessDataResult<Unbuild>(_unbuildDao.Get(u => u.Id == id));
        }

        public async Task<IDataResult<Unbuild>> GetByIdAsync(int id)
        {
            var order = await _unbuildDao.GetAsync(u => u.Id == id);
            return new SuccessDataResult<Unbuild>(order);
        }

        public IResult Add(Unbuild unbuild)
        {
            _unbuildDao.Add(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderAdded);
        }

        public async Task<IResult> AddAsync(Unbuild unbuild)
        {
            await _unbuildDao.AddAsync(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderAdded);
        }

        public IResult Update(Unbuild unbuild)
        {
            _unbuildDao.Update(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Unbuild unbuild)
        {
            await _unbuildDao.UpdateAsync(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderUpdated);
        }

        public IResult Delete(Unbuild unbuild)
        {
            _unbuildDao.Delete(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Unbuild unbuild)
        {
            await _unbuildDao.DeleteAsync(unbuild);
            return new SuccessResult(true, ResultMessages.UnbuildOrderDeleted);
        }

        public IDataResult<UnbuildDetailsDto> GetUnbuildDetailsDtoById(int unbuildId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<UnbuildDetailsDto>> GetUnbuildDetailsDtoByIdAsync(int unbuildId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<UnbuildListDto>> GetUnbuildListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<UnbuildListDto>>> GetUnbuildListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
