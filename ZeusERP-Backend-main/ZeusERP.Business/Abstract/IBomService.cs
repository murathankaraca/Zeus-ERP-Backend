using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IBomService
    {
        // Bill of Materials
        IDataResult<BillOfMaterials> GetById(int id);
        Task<IDataResult<BillOfMaterials>> GetByIdAsync(int id);
        IDataResult<IList<BillOfMaterials>> GetList();
        Task<IDataResult<IList<BillOfMaterials>>> GetListAsync();
        IResult Add(BillOfMaterials bom);
        Task<IResult> AddAsync(BillOfMaterials bom);
        IResult Update(BillOfMaterials bom);
        Task<IResult> UpdateAsync(BillOfMaterials bom);
        IResult Delete(BillOfMaterials bom);
        Task<IResult> DeleteAsync(BillOfMaterials bom);

        // DTOS

        IDataResult<BomDetailsDto> GetBomDetailsDtoById(int bomId);
        Task<IDataResult<BomDetailsDto>> GetBomDetailsDtoByIdAsync(int bomId);
        IDataResult<IList<BomListDto>> GetBomListDto();
        Task<IDataResult<IList<BomListDto>>> GetBomListDtoAsync();


    }
}
