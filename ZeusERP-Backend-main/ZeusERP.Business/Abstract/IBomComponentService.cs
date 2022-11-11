using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IBomComponentService
    {
        IDataResult<BillOfMaterialsComponent> GetById(int id);
        Task<IDataResult<BillOfMaterialsComponent>> GetByIdAsync(int id);
        IDataResult<IList<BillOfMaterialsComponent>> GetListByOrderId(int orderId);
        Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListByOrderIdAsync(int orderId);
        IDataResult<IList<BillOfMaterialsComponent>> GetList();
        Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListAsync();
        IDataResult<IList<BillOfMaterialsComponent>> GetListByBomId(int bomId);
        Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListByBomIdAsync(int bomId);
        IResult Add(BillOfMaterialsComponent bomComponent);
        Task<IResult> AddAsync(BillOfMaterialsComponent bomComponent);
        IResult Update(BillOfMaterialsComponent bomComponent);
        Task<IResult> UpdateAsync(BillOfMaterialsComponent bomComponent);
        IResult Delete(BillOfMaterialsComponent bomComponent);
        Task<IResult> DeleteAsync(BillOfMaterialsComponent bomComponent);

        // DTOS

        IDataResult<BomComponentDetailsDto> GetBomComponentDetailsDtoById(int bomComponentId);
        Task<IDataResult<BomComponentDetailsDto>> GetBomComponentDetailsDtoByIdAsync(int bomComponentId);

        IDataResult<IList<BomComponentDetailsDto>> GetBomComponentDetailsDtoByOrderId(int orderId);
        Task<IDataResult<IList<BomComponentDetailsDto>>> GetBomComponentDetailsDtoByOrderIdAsync(int orderId);


    }
}
