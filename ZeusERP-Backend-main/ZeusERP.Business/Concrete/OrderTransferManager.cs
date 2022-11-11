using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class OrderTransferManager : IOrderTransferService
    {
        private IOrderTransferDao _transferDao;
        private ILocationDao _locationDao;
        public OrderTransferManager(IOrderTransferDao transferDao, ILocationDao locationDao)
        {
            _transferDao = transferDao;
            _locationDao = locationDao;
        }
        public IDataResult<IList<Transfer>> GetList()
        {
            var transfers = _transferDao.GetList();
            return new SuccessDataResult<IList<Transfer>>(transfers);
        }

        public async Task<IDataResult<IList<Transfer>>> GetListAsync()
        {
            var transfers = await _transferDao.GetListAsync();
            return new SuccessDataResult<IList<Transfer>>(transfers);
        }

        public IDataResult<Transfer> GetById(int transferId)
        {
            var transfer = _transferDao.Get(t => t.Id == transferId);
            return new SuccessDataResult<Transfer>(transfer);
        }

        public async Task<IDataResult<Transfer>> GetByIdAsync(int transferId)
        {
            var transfer = await _transferDao.GetAsync(t => t.Id == transferId);
            return new SuccessDataResult<Transfer>(transfer);
        }

        public IResult Add(Transfer transfer)
        {
            _transferDao.Add(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderAdded);
        }

        public async Task<IResult> AddAsync(Transfer transfer)
        {
            await _transferDao.AddAsync(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderAdded);
        }

        public IResult Update(Transfer transfer)
        {
            _transferDao.Update(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Transfer transfer)
        {
            await _transferDao.UpdateAsync(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderUpdated);
        }

        public IResult Delete(Transfer transfer)
        {
            _transferDao.Delete(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Transfer transfer)
        {
            await _transferDao.DeleteAsync(transfer);
            return new SuccessResult(true, ResultMessages.TransferOrderDeleted);
        }

        public IDataResult<TransferDetailsDto> GetTransferDetailsDtoById(int transferId)
        {
            var transfer = _transferDao.Get(t => t.Id == transferId);
            var receiveFrom = _locationDao.Get(l => l.Id == transfer.ReceiveFromId);
            var destinationLoc = _locationDao.Get(l => l.Id == transfer.DestinationLocationId);
            var transferDetailsDto = new TransferDetailsDto
            {
                Id = transfer.Id,
                Reference = transfer.Reference,
                OperationTypeId = transfer.OperationTypeId,
                ReceiveFromId = receiveFrom.Id,
                ReceiveFromName = receiveFrom.Name,
                ScheduledDate = transfer.ScheduledDate,
                EffectiveDate = transfer.EffectiveDate,
                ResponsibleId = transfer.ResponsibleId,
                DestinationLocationId = destinationLoc.Id,
                DestinationLocationName = destinationLoc.Name,
                TransferProductsId = transfer.TransferProductsId,
            };
            return new SuccessDataResult<TransferDetailsDto>(transferDetailsDto);
        }

        public Task<IDataResult<TransferDetailsDto>> GetTransferDetailsDtoByIdAsync(int transferId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<TransferListDto>> GetTransferListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<TransferListDto>>> GetTransferListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}
