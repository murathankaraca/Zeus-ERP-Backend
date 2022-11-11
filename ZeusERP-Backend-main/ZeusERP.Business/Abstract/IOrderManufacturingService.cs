using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderManufacturingService
    {
        IDataResult<Manufacturing> GetById(int id);
        Task<IDataResult<Manufacturing>> GetByIdAsync(int id);
        IDataResult<IList<Manufacturing>> GetList();
        Task<IDataResult<IList<Manufacturing>>> GetListAsync();
        IDataResult<IList<Manufacturing>> GetListByBomId(int bomId);
        Task<IDataResult<IList<Manufacturing>>> GetListByBomIdAsync(int bomId);
        IResult Add(Manufacturing manufacturing);
        Task<IResult> AddAsync(Manufacturing manufacturing);
        IResult Update(Manufacturing manufacturing);
        Task<IResult> UpdateAsync(Manufacturing manufacturing);
        IResult Delete(Manufacturing manufacturing);
        Task<IResult> DeleteAsync(Manufacturing manufacturing);

        // DTOS

        IDataResult<ManufacturingDetailsDto> GetManufacturingDetailsDtoById(int manufacturingId);
        Task<IDataResult<ManufacturingDetailsDto>> GetManufacturingDetailsDtoByIdAsync(int manufacturingId);
        IDataResult<IList<ManufacturingListDto>> GetManufacturingListDto();
        Task<IDataResult<IList<ManufacturingListDto>>> GetManufacturingListDtoAsync();
    }
}
