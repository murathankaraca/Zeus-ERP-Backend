using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IWarehouseService
    {
        IDataResult<IList<Warehouse>> GetList();
        Task<IDataResult<IList<Warehouse>>> GetListAsync();
        IDataResult<Warehouse> GetById(int warehouseId);
        Task<IDataResult<Warehouse>> GetByIdAsync(int warehouseId);
        IResult Add(Warehouse warehouse);
        Task<IResult> AddAsync(Warehouse warehouse);

        IResult Update(Warehouse warehouse);
        Task<IResult> UpdateAsync(Warehouse warehouse);

        IResult Delete(Warehouse warehouse);
        Task<IResult> DeleteAsync(Warehouse warehouse);

        // DTOS
        IDataResult<WarehouseDetailsDto> GetWarehouseDetailsDtoById(int warehouseId);
        Task<IDataResult<WarehouseDetailsDto>> GetWarehouseDetailsDtoByIdAsync(int warehouseId);
        IDataResult<IList<WarehouseListDto>> GetWarehouseListDto();
        Task<IDataResult<IList<WarehouseListDto>>> GetWarehouseListDtoAsync();
    }
}
