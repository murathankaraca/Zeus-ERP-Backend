using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderDeliveryService
    {
        IDataResult<IList<Delivery>> GetList();
        Task<IDataResult<IList<Delivery>>> GetListAsync();
        IDataResult<Delivery> GetById(int id);
        Task<IDataResult<Delivery>> GetByIdAsync(int id);
        IResult Add(Delivery delivery);
        Task<IResult> AddAsync(Delivery delivery);

        IResult Update(Delivery delivery);
        Task<IResult> UpdateAsync(Delivery delivery);

        IResult Delete(Delivery delivery);
        Task<IResult> DeleteAsync(Delivery delivery);

        // DTOS

        IDataResult<DeliveryDetailsDto> GetDeliveryDetailsDtoById(int deliveryId);
        Task<IDataResult<DeliveryDetailsDto>> GetDeliveryDetailsDtoByIdAsync(int deliveryId);
        IDataResult<IList<DeliveryListDto>> GetDeliveryListDto();
        Task<IDataResult<IList<DeliveryListDto>>> GetDeliveryListDtoAsync();
    }
}
