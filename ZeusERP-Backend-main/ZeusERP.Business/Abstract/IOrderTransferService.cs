using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IOrderTransferService
    {
        IDataResult<IList<Transfer>> GetList();
        Task<IDataResult<IList<Transfer>>> GetListAsync();
        IDataResult<Transfer> GetById(int id);
        Task<IDataResult<Transfer>> GetByIdAsync(int id);

        IResult Add(Transfer transfer);
        Task<IResult> AddAsync(Transfer transfer);

        IResult Update(Transfer transfer);
        Task<IResult> UpdateAsync(Transfer transfer);

        IResult Delete(Transfer transfer);
        Task<IResult> DeleteAsync(Transfer transfer);


        // DTOS

        IDataResult<TransferDetailsDto> GetTransferDetailsDtoById(int transferId);
        Task<IDataResult<TransferDetailsDto>> GetTransferDetailsDtoByIdAsync(int transferId);
        IDataResult<IList<TransferListDto>> GetTransferListDto();
        Task<IDataResult<IList<TransferListDto>>> GetTransferListDtoAsync();
    }
}
