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
    public class OrderManufacturingManager : IOrderManufacturingService
    {
        private IOrderManufacturingDao _manufacturingDao;
        public OrderManufacturingManager(IOrderManufacturingDao manufacturingDao)
        {
            this._manufacturingDao = manufacturingDao;
        }

        public IDataResult<Manufacturing> GetById(int id)
        {
            return new SuccessDataResult<Manufacturing>(_manufacturingDao.Get(m => m.Id == id));
        }

        public async Task<IDataResult<Manufacturing>> GetByIdAsync(int id)
        {
            var order = await _manufacturingDao.GetAsync(m => m.Id == id);
            return new SuccessDataResult<Manufacturing>(order);
        }

        public IDataResult<IList<Manufacturing>> GetList()
        {
            return new SuccessDataResult<IList<Manufacturing>>(_manufacturingDao.GetList());
        }

        public async Task<IDataResult<IList<Manufacturing>>> GetListAsync()
        {
            var orders = await _manufacturingDao.GetListAsync();
            return new SuccessDataResult<IList<Manufacturing>>(orders);
        }

        public IDataResult<IList<Manufacturing>> GetListByBomId(int bomId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<Manufacturing>>> GetListByBomIdAsync(int bomId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Manufacturing manufacturing)
        {
            _manufacturingDao.Add(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderAdded);
        }

        public async Task<IResult> AddAsync(Manufacturing manufacturing)
        {
            await _manufacturingDao.AddAsync(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderAdded);
        }

        public IResult Update(Manufacturing manufacturing)
        {
            _manufacturingDao.Update(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Manufacturing manufacturing)
        {
            await _manufacturingDao.UpdateAsync(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderUpdated);
        }

        public IResult Delete(Manufacturing manufacturing)
        {
            _manufacturingDao.Delete(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Manufacturing manufacturing)
        {
            await _manufacturingDao.DeleteAsync(manufacturing);
            return new SuccessResult(true, ResultMessages.ManufacturingOrderDeleted);
        }

        public IDataResult<ManufacturingDetailsDto> GetManufacturingDetailsDtoById(int manufacturingId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ManufacturingDetailsDto>> GetManufacturingDetailsDtoByIdAsync(int manufacturingId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<ManufacturingListDto>> GetManufacturingListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ManufacturingListDto>>> GetManufacturingListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
