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
    public class OrderDeliveryOperationManager : IOrderDeliveryOperationService
    {
        private IOrderDeliveryOperationsDao _deliveryOperationDao;
        private IOrderDeliveryDao _deliveryDao;
        public OrderDeliveryOperationManager(IOrderDeliveryOperationsDao deliveryOperationDao, IOrderDeliveryDao deliveryDao)
        {
            _deliveryOperationDao = deliveryOperationDao;
            _deliveryDao = deliveryDao;
        }
        public IDataResult<DeliveryOperation> GetById(int id)
        {
            var deliveryOperation = _deliveryOperationDao.Get(deliveryOp => deliveryOp.Id == id);
            
            return new SuccessDataResult<DeliveryOperation>(deliveryOperation);
        }

        public async Task<IDataResult<DeliveryOperation>> GetByIdAsync(int id)
        {
            var deliveryOperation = await _deliveryOperationDao.GetAsync(deliveryOp => deliveryOp.Id == id);

            return new SuccessDataResult<DeliveryOperation>(deliveryOperation);
        }

        public IDataResult<IList<DeliveryOperation>> GetList()
        {
            var deliveryOperations = _deliveryOperationDao.GetList();

            return new SuccessDataResult<IList<DeliveryOperation>>(deliveryOperations);
        }

        public async Task<IDataResult<IList<DeliveryOperation>>> GetListAsync()
        {
            var deliveryOperations = await _deliveryOperationDao.GetListAsync();

            return new SuccessDataResult<IList<DeliveryOperation>>(deliveryOperations);
        }

        public IResult Add(DeliveryOperation deliveryOperation)
        {
            _deliveryOperationDao.Add(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderAdded);
        }

        public async Task<IResult> AddAsync(DeliveryOperation deliveryOperation)
        {
            await _deliveryOperationDao.AddAsync(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderAdded);
        }

        public IResult Update(DeliveryOperation deliveryOperation)
        {
            _deliveryOperationDao.Update(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(DeliveryOperation deliveryOperation)
        {
            await _deliveryOperationDao.UpdateAsync(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderUpdated);
        }

        public IResult Delete(DeliveryOperation deliveryOperation)
        {
            _deliveryOperationDao.Add(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(DeliveryOperation deliveryOperation)
        {
            await _deliveryOperationDao.DeleteAsync(deliveryOperation);
            return new SuccessResult(true, ResultMessages.DeliveryOrderDeleted);
        }

        public IDataResult<IList<DeliveryDetailsDto>> GetDeliveryOperationDetailsDtoByOrderId(int deliveryId)
        {
            var delivery = _deliveryDao.Get(d => d.Id == deliveryId);
            var deliveryOperation = _deliveryOperationDao.GetList(op => op.DeliveryOrderId == deliveryId);

            foreach(var operation in deliveryOperation)
            {
                var deliveryOperationDetailsDto = new DeliveryOperationDetailsDto
                {
                    Id = operation.Id,
                };
            }

           
            throw new NotImplementedException();
        }

        public async Task<IDataResult<IList<DeliveryDetailsDto>>> GetDeliveryOperationDetailsDtoByOrderIdAsync(int deliveryId)
        {
            throw new NotImplementedException();
        }
    }
}
