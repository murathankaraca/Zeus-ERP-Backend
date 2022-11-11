using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderDeliveryOperationService
    {
        IDataResult<DeliveryOperation> GetById(int id);
        Task<IDataResult<DeliveryOperation>> GetByIdAsync(int id);
        IDataResult<IList<DeliveryOperation>> GetList();
        Task<IDataResult<IList<DeliveryOperation>>> GetListAsync();
        IResult Add(DeliveryOperation deliveryOperation);
        Task<IResult> AddAsync(DeliveryOperation deliveryOperation);

        IResult Update(DeliveryOperation deliveryOperation);
        Task<IResult> UpdateAsync(DeliveryOperation deliveryOperation);

        IResult Delete(DeliveryOperation deliveryOperation);
        Task<IResult> DeleteAsync(DeliveryOperation deliveryOperation);

        // DTOS

        IDataResult<IList<DeliveryDetailsDto>> GetDeliveryOperationDetailsDtoByOrderId(int deliveryId);
        Task<IDataResult<IList<DeliveryDetailsDto>>> GetDeliveryOperationDetailsDtoByOrderIdAsync(int deliveryId);
    }
}
