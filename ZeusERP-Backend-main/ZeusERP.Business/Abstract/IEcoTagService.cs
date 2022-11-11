using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Abstract
{
    public interface IEcoTagService
    {
        IDataResult<IList<ECOTag>> GetList();
        Task<IDataResult<IList<ECOTag>>> GetListAsync();
        IDataResult<ECOTag> GetById(int id);
        Task<IDataResult<ECOTag>> GetByIdAsync(int id);

        IResult Add(ECOTag ecoTag);
        Task<IResult> AddAsync(ECOTag ecoTag);

        IResult Update(ECOTag ecoTag);
        Task<IResult> UpdateAsync(ECOTag ecoTag);

        IResult Delete(ECOTag ecoTag);
        Task<IResult> DeleteAsync(ECOTag ecoTag);
    }
}
