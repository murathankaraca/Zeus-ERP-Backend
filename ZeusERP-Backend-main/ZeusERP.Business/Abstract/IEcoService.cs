using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IECOService
    {
        IDataResult<IList<EngineeringChangeOrder>> GetList();
        Task<IDataResult<IList<EngineeringChangeOrder>>> GetListAsync();
        IDataResult<EngineeringChangeOrder> GetById(int id);
        Task<IDataResult<EngineeringChangeOrder>> GetByIdAsync(int id);

        IResult Add(EngineeringChangeOrder eco);
        Task<IResult> AddAsync(EngineeringChangeOrder eco);

        IResult Update(EngineeringChangeOrder eco);
        Task<IResult> UpdateAsync(EngineeringChangeOrder eco);

        IResult Delete(EngineeringChangeOrder eco);
        Task<IResult> DeleteAsync(EngineeringChangeOrder eco);

        // DTOs

        IDataResult<ECODetailsDto> GetEcoDetailsById(int ecoId);
        Task<IDataResult<ECODetailsDto>> GetEcoDetailsByIdAsync(int ecoId);
    }
}
