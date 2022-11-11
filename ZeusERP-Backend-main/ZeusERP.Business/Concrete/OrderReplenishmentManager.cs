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
    public class OrderReplenishmentManager : IOrderReplenishmentService
    {
        private IOrderReplenishmentDao _replenishmentDao;
        private IProductDao _productDao;
        private ILocationDao _locationDao;
        public OrderReplenishmentManager(IOrderReplenishmentDao replenishmentDao, IProductDao productDao, ILocationDao locationDao)
        {
            _replenishmentDao = replenishmentDao;
            _productDao = productDao;
            _locationDao = locationDao;
        }

        public IDataResult<IList<Replenishment>> GetList()
        {
            return new SuccessDataResult<IList<Replenishment>>(_replenishmentDao.GetList());
        }

        public async Task<IDataResult<IList<Replenishment>>> GetListAsync()
        {
            var orders = await _replenishmentDao.GetListAsync();
            return new SuccessDataResult<IList<Replenishment>>(orders);
        }

        public IDataResult<Replenishment> GetById(int id)
        {
            return new SuccessDataResult<Replenishment>(_replenishmentDao.Get(r => r.Id == id));
        }

        public async Task<IDataResult<Replenishment>> GetByIdAsync(int id)
        {
            var orders = await _replenishmentDao.GetAsync(r => r.Id == id);
            return new SuccessDataResult<Replenishment>(orders);
        }

        public IResult Add(Replenishment replenishment)
        {
            _replenishmentDao.Add(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderAdded);
        }

        public async Task<IResult> AddAsync(Replenishment replenishment)
        {
            await _replenishmentDao.AddAsync(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderAdded);
        }

        public IResult Update(Replenishment replenishment)
        {
            _replenishmentDao.Update(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Replenishment replenishment)
        {
           await _replenishmentDao.UpdateAsync(replenishment);
           return new SuccessResult(true, ResultMessages.ReplenishmentOrderUpdated);
        }

        public IResult Delete(Replenishment replenishment)
        {
            _replenishmentDao.Delete(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Replenishment replenishment)
        {
            await _replenishmentDao.DeleteAsync(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderDeleted);
        }

        public IDataResult<ReplenishmentDetailsDto> GetReplenishmentDetailsDtoById(int replenishmentId)
        {
            var replenishment = _replenishmentDao.Get(r => r.Id == replenishmentId);
            var prodToReplenish = _productDao.Get(p => p.Id == replenishment.ProductToReplenishId);
            var replenishmentLocation = _locationDao.Get(l => l.Id == replenishment.LocationId);

            var replenishmentDetailsDto = new ReplenishmentDetailsDto
            {
                Id = replenishment.Id,
                Reference = replenishment.Reference,
                ProductToReplenishId = prodToReplenish.Id,
                ProductToReplenishName = prodToReplenish.Name,
                LocationId = replenishmentLocation.Id,
                LocationName = replenishmentLocation.Name,
                OnHandQuantity = replenishment.OnHandQuantity,
                OrderQuantity = replenishment.OrderQuantity,
                Status = replenishment.Status
            };

            return new SuccessDataResult<ReplenishmentDetailsDto>(replenishmentDetailsDto);
        }

        public async Task<IDataResult<ReplenishmentDetailsDto>> GetReplenishmentDetailsDtoByIdAsync(int replenishmentId)
        {
            var replenishment = await _replenishmentDao.GetAsync(r => r.Id == replenishmentId);
            var prodToReplenish = await _productDao.GetAsync(p => p.Id == replenishment.ProductToReplenishId);
            var replenishmentLocation = await _locationDao.GetAsync(l => l.Id == replenishment.LocationId);

            var replenishmentDetailsDto = new ReplenishmentDetailsDto
            {
                Id = replenishment.Id,
                Reference = replenishment.Reference,
                ProductToReplenishId = prodToReplenish.Id,
                ProductToReplenishName = prodToReplenish.Name,
                LocationId = replenishmentLocation.Id,
                LocationName = replenishmentLocation.Name,
                OnHandQuantity = replenishment.OnHandQuantity,
                OrderQuantity = replenishment.OrderQuantity,
                Status = replenishment.Status
            };

            return new SuccessDataResult<ReplenishmentDetailsDto>(replenishmentDetailsDto);
        }

        public IDataResult<IList<ReplenishmentDetailsDto>> GetReplenishmentDetailsDtos()
        {
            List<ReplenishmentDetailsDto> dtos = new List<ReplenishmentDetailsDto>();
            var replenishments = _replenishmentDao.GetList();

            foreach(var replenishment in replenishments)
            {
                var prodToReplenish = _productDao.Get(p => p.Id == replenishment.ProductToReplenishId);
                var replenishmentLocation = _locationDao.Get(l => l.Id == replenishment.LocationId);

                var replenishmentDetailsDto = new ReplenishmentDetailsDto
                {
                    Id = replenishment.Id,
                    Reference = replenishment.Reference,
                    ProductToReplenishId = prodToReplenish.Id,
                    ProductToReplenishName = prodToReplenish.Name,
                    LocationId = replenishmentLocation.Id,
                    LocationName = replenishmentLocation.Name,
                    OnHandQuantity = replenishment.OnHandQuantity,
                    OrderQuantity = replenishment.OrderQuantity,
                    Status = replenishment.Status
                };
                dtos.Add(replenishmentDetailsDto);
            }
            

            return new SuccessDataResult<IList<ReplenishmentDetailsDto>>(dtos);
        }

        public async Task<IDataResult<IList<ReplenishmentDetailsDto>>> GetReplenishmentDetailsDtosAsync()
        {
            List<ReplenishmentDetailsDto> dtos = new List<ReplenishmentDetailsDto>();
            var replenishments = await _replenishmentDao.GetListAsync();

            foreach (var replenishment in replenishments)
            {
                var prodToReplenish = await _productDao.GetAsync(p => p.Id == replenishment.ProductToReplenishId);
                var replenishmentLocation = await _locationDao.GetAsync(l => l.Id == replenishment.LocationId);

                var replenishmentDetailsDto = new ReplenishmentDetailsDto
                {
                    Id = replenishment.Id,
                    Reference = replenishment.Reference,
                    ProductToReplenishId = prodToReplenish.Id,
                    ProductToReplenishName = prodToReplenish.Name,
                    LocationId = replenishmentLocation.Id,
                    LocationName = replenishmentLocation.Name,
                    OnHandQuantity = replenishment.OnHandQuantity,
                    OrderQuantity = replenishment.OrderQuantity,
                    Status = replenishment.Status
                };
                dtos.Add(replenishmentDetailsDto);
            }


            return new SuccessDataResult<IList<ReplenishmentDetailsDto>>(dtos);
        }
    }
}
