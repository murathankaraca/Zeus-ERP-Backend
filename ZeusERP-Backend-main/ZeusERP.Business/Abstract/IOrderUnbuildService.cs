using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderUnbuildService
    {
        IDataResult<IList<Unbuild>> GetList();
        Task<IDataResult<IList<Unbuild>>> GetListAsync();
        IDataResult<Unbuild> GetById(int id);
        Task<IDataResult<Unbuild>> GetByIdAsync(int id);
        IResult Add(Unbuild unbuild);
        Task<IResult> AddAsync(Unbuild unbuild);

        IResult Update(Unbuild unbuild);
        Task<IResult> UpdateAsync(Unbuild unbuild);

        IResult Delete(Unbuild unbuild);
        Task<IResult> DeleteAsync(Unbuild unbuild);

        // DTOS

        IDataResult<UnbuildDetailsDto> GetUnbuildDetailsDtoById(int unbuildId);
        Task<IDataResult<UnbuildDetailsDto>> GetUnbuildDetailsDtoByIdAsync(int unbuildId);
        IDataResult<IList<UnbuildListDto>> GetUnbuildListDto();
        Task<IDataResult<IList<UnbuildListDto>>> GetUnbuildListDtoAsync();
    }
}
