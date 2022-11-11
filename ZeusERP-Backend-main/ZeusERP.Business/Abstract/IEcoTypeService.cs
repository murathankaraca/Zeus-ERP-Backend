using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Abstract
{
    public interface IEcoTypeService
    {
        IDataResult<IList<ECOType>> GetList();
        Task<IDataResult<IList<ECOType>>> GetListAsync();
        IDataResult<ECOType> GetById(int id);
        Task<IDataResult<ECOType>> GetByIdAsync(int id);

        IResult Add(ECOType ecoType);
        Task<IResult> AddAsync(ECOType ecoType);

        IResult Update(ECOType ecoType);
        Task<IResult> UpdateAsync(ECOType ecoType);

        IResult Delete(ECOType ecoType);
        Task<IResult> DeleteAsync(ECOType ecoType);
    }
}
