using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderReplenishmentService
    {
        IDataResult<IList<Replenishment>> GetList();
        Task<IDataResult<IList<Replenishment>>> GetListAsync();
        IDataResult<Replenishment> GetById(int id);
        Task<IDataResult<Replenishment>> GetByIdAsync(int id);

        IResult Add(Replenishment replenishment);
        Task<IResult> AddAsync(Replenishment replenishment);

        IResult Update(Replenishment replenishment);
        Task<IResult> UpdateAsync(Replenishment replenishment);

        IResult Delete(Replenishment replenishment);
        Task<IResult> DeleteAsync(Replenishment replenishment);


        // DTOS

        IDataResult<ReplenishmentDetailsDto> GetReplenishmentDetailsDtoById(int replenishmentId);
        Task<IDataResult<ReplenishmentDetailsDto>> GetReplenishmentDetailsDtoByIdAsync(int replenishmentId);

        IDataResult<IList<ReplenishmentDetailsDto>> GetReplenishmentDetailsDtos();
        Task<IDataResult<IList<ReplenishmentDetailsDto>>> GetReplenishmentDetailsDtosAsync();
    }
}
