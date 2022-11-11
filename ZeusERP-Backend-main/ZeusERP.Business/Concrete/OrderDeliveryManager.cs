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
    public class OrderDeliveryManager : IOrderDeliveryService
    {
        private IOrderDeliveryDao _deliveryDao;
        public OrderDeliveryManager(IOrderDeliveryDao deliveryDao)
        {
            _deliveryDao = deliveryDao;
        }
        public IDataResult<IList<Delivery>> GetList()
        {
            return new SuccessDataResult<IList<Delivery>>(_deliveryDao.GetList());
        }

        public async Task<IDataResult<IList<Delivery>>> GetListAsync()
        {
            var result = await _deliveryDao.GetListAsync();
            return new SuccessDataResult<IList<Delivery>>(result);
        }

        public IDataResult<Delivery> GetById(int id)
        {
            return new SuccessDataResult<Delivery>(_deliveryDao.Get(d => d.Id == id));
        }

        public async Task<IDataResult<Delivery>> GetByIdAsync(int id)
        {
            var result = await _deliveryDao.GetAsync(d => d.Id == id);
            return new SuccessDataResult<Delivery>(result);
        }

        public IResult Add(Delivery delivery)
        {
            _deliveryDao.Add(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderAdded);
        }

        public async Task<IResult> AddAsync(Delivery delivery)
        {
            await _deliveryDao.AddAsync(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderAdded);
        }

        public IResult Update(Delivery delivery)
        {
            _deliveryDao.Update(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Delivery delivery)
        {
            await _deliveryDao.UpdateAsync(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderUpdated);
        }

        public IResult Delete(Delivery delivery)
        {
            _deliveryDao.Delete(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Delivery delivery)
        {
            await _deliveryDao.DeleteAsync(delivery);
            return new SuccessResult(true, ResultMessages.DeliveryOrderDeleted);
        }

        public IDataResult<DeliveryDetailsDto> GetDeliveryDetailsDtoById(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<DeliveryDetailsDto>> GetDeliveryDetailsDtoByIdAsync(int deliveryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<DeliveryListDto>> GetDeliveryListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<DeliveryListDto>>> GetDeliveryListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
