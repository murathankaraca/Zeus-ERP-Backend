using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface ILocationService
    {

        IDataResult<IList<Location>> GetList();
        Task<IDataResult<IList<Location>>> GetListAsync();
        IDataResult<Location> GetById(int id);
        Task<IDataResult<Location>> GetByIdAsync(int id);
        IResult Add(Location location);
        Task<IResult> AddAsync(Location location);
        IResult Update(Location location);
        Task<IResult> UpdateAsync(Location location);
        IResult Delete(Location location);
        Task<IResult> DeleteAsync(Location location);

        // DTOS

        IDataResult<LocationDetailsDto> GetLocationDetailsDtoById(int locationId);
        Task<IDataResult<LocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId);
        IDataResult<IList<LocationListDto>> GetLocationListDto();
        Task<IDataResult<IList<LocationListDto>>> GetLocationListDtoAsync();
    }
}
